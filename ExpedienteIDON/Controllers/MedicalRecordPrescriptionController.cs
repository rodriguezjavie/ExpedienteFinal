using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace ExpedienteIDON.Controllers
{
    [Authorize(Roles = "Administrador,Doctor")]
    public class MedicalRecordPrescriptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalRecordPrescription
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicalRecordPrescription/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            var prescription = await db.Prescriptions.SingleOrDefaultAsync(d => d.MedicalRecordId == id);
            var patient = await db.Patients.SingleOrDefaultAsync(p => p.Id == prescription.PatientId);
            var user = db.Users.FirstOrDefault(x => x.Id == prescription.ApplicationUserId);
            var listMedicinesPrescriptions = await db.MedicinesPrescriptions.Where(p => p.PrescriptionId == prescription.Id).ToListAsync();

            var prescriptionViewModel = new PrescriptionViewModel
            {
                Patient = prescription.Patient,
                Prescription = prescription,
                MedicinesPrescriptions = listMedicinesPrescriptions,
                UserDataViewModel = new UserDataViewModel
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Cedula = user.Cedula
                }
            };
            return View(prescriptionViewModel);
        }

        // GET: MedicalRecordPrescription/Create/patientId/medicalRecordId
        [Route("MedicalRecordPrescription/Create/{patientId}/{medicalRecordId}")]
        public async Task<ActionResult> Create(int patientId, int medicalRecordId)
        {
            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            //Valida que no exista una receta ligada al historial
            var record = db.Prescriptions.SingleOrDefault(r => r.MedicalRecordId == medicalRecordId);
            if (record != null)
                return RedirectToAction("Details", "MedicalRecordPrescription", new { id = medicalRecordId });

            string currentUserId = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var patient = await db.Patients.SingleOrDefaultAsync(p => p.Id == patientId);
            var prescriptVM = new PrescriptionViewModel
            {
                UserDataViewModel = new UserDataViewModel
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Cedula = user.Cedula
                },
                Patient = patient,
                Prescription = new Prescription(),
                MedicinesPrescription = new MedicinesPrescription
                {
                    Prescription = new Prescription
                    {
                        PatientId = patientId,
                        MedicalRecordId = medicalRecordId
                    }
                },
                MedicinesPrescriptions = new List<MedicinesPrescription>()
                {
                    new MedicinesPrescription { }
                }
            };

            return View(prescriptVM);
        }

        // POST: MedicalRecordPrescription/Create/patientId/medicalRecordId
        [Route("MedicalRecordPrescription/Create/{patientId}/{medicalRecordId}")]
        [HttpPost]
        public async Task<ActionResult> Create(MedicinesPrescription medicinesPrescription, List<MedicinesPrescription> medicinesPrescriptions, Prescription prescription, String idPatient)
        {
            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            try
            {
                prescription.CratedDate = DateTime.Now;
                prescription.PatientId = int.Parse(idPatient);
                prescription.DoctorId = 1;
                prescription.ApplicationUserId = User.Identity.GetUserId();
                db.Prescriptions.Add(prescription);
                await db.SaveChangesAsync();
                int lastId = prescription.Id;
                foreach (var item in medicinesPrescriptions)
                {
                    item.PrescriptionId = lastId;
                    db.MedicinesPrescriptions.Add(item);
                    await db.SaveChangesAsync();
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("Details", "MedicalRecordPrescription", new { id = prescription.MedicalRecordId });
            }
            catch
            {
                string currentUserId = User.Identity.GetUserId();
                var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                var patient = await db.Patients.SingleAsync(p => p.Id == prescription.PatientId);

                var prescriptVM = new PrescriptionViewModel
                {
                    UserDataViewModel = new UserDataViewModel
                    {
                        Name = user.Name,
                        LastName = user.LastName,
                        Phone = user.Phone,
                        Cedula = user.Cedula
                    },
                    Patient = patient,
                    Prescription = prescription,
                    MedicinesPrescription = medicinesPrescription,
                    MedicinesPrescriptions = medicinesPrescriptions
                };
                return View(prescriptVM);
            }
        }

        // GET: MedicalRecordPrescription/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            var prescription = await db.Prescriptions.SingleOrDefaultAsync(d => d.MedicalRecordId == id);
            var patient = await db.Patients.SingleOrDefaultAsync(p => p.Id == prescription.PatientId);
            var user = db.Users.FirstOrDefault(x => x.Id == prescription.ApplicationUserId);
            var listMedicinesPrescriptions = await db.MedicinesPrescriptions.Where(p => p.PrescriptionId == prescription.Id).ToListAsync();

            var prescriptionViewModel = new PrescriptionViewModel
            {
                MedicinesPrescriptions = listMedicinesPrescriptions,
                UserDataViewModel = new UserDataViewModel
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Cedula = user.Cedula
                },
                Patient = patient,
                Prescription = prescription
            };
            return View(prescriptionViewModel);
        }

        // POST: MedicalRecordPrescription/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(MedicinesPrescription medicinesPrescription, Prescription prescription, List<MedicinesPrescription> medicinesPrescriptions)
        {
            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            try
            {
                foreach (var item in medicinesPrescriptions)
                {
                    if (item.Medicine != null)
                    {
                        if (item.Id != 0)
                        {
                            var itemdb = db.MedicinesPrescriptions.SingleOrDefault(o => o.Id == item.Id);
                            Mapper.Map(item, itemdb);
                        }
                        else
                        {
                            db.MedicinesPrescriptions.Add(item);
                        }
                        await db.SaveChangesAsync();
                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("Details", new { id = prescription.MedicalRecordId });
            }
            catch
            {
                var patient = await db.Patients.SingleOrDefaultAsync(p => p.Id == prescription.PatientId);
                var user = db.Users.FirstOrDefault(x => x.Id == prescription.ApplicationUserId);
                var prescriptionViewModel = new PrescriptionViewModel
                {
                    Patient = patient,
                    Prescription = prescription,
                    MedicinesPrescription = medicinesPrescription,
                    UserDataViewModel = new UserDataViewModel
                    {
                        Name = user.Name,
                        LastName = user.LastName,
                        Phone = user.Phone,
                        Cedula = user.Cedula
                    },
                    MedicinesPrescriptions = medicinesPrescriptions
                };
                return View(prescriptionViewModel);
            }
        }
    }
}

