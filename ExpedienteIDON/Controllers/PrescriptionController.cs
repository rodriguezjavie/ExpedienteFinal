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
    public class PrescriptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Prescription
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            var list = await db.Prescriptions.ToListAsync();
            return View(list);
        }

        // GET: Prescription/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                if (User.IsInRole("Administrador"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                else if (User.IsInRole("Asistente"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                else
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

                var prescription = await db.Prescriptions.SingleOrDefaultAsync(d => d.Id == id);
                if (prescription == null)
                    return HttpNotFound();
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
            catch (Exception)
            {

                return HttpNotFound();
            }
           
        }

        // GET: Prescription/Create
        [Route("Prescription/Create/{patientId}")]
        public async Task<ActionResult> Create(int patientId)
        {
            try
            {
                if (User.IsInRole("Administrador"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                else if (User.IsInRole("Asistente"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                else
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

                string currentUserId = User.Identity.GetUserId();
                var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                var patient = await db.Patients.SingleOrDefaultAsync(p => p.Id == patientId);
                if (patient == null)
                    return HttpNotFound();

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
                            PatientId = patientId
                        }
                    },
                    MedicinesPrescriptions = new List<MedicinesPrescription>()
                {
                    new MedicinesPrescription { }
                }
                };
                return View(prescriptVM);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
            
        }

        // POST: Prescription/Create
        [HttpPost]
        [Route("Prescription/Create/{patientId}")]
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
                    return RedirectToAction("Details", new { id = prescription.Id });
               
                    
                
                
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

        // GET: Prescription/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                if (User.IsInRole("Administrador"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                else if (User.IsInRole("Asistente"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                else
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

                var prescription = await db.Prescriptions.SingleOrDefaultAsync(d => d.Id == id);
                if (prescription == null)
                    return HttpNotFound();
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
            catch (Exception)
            {

                return HttpNotFound();
            }
            
        }

        // POST: Prescription/Edit/5
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
                if (ModelState.IsValid)
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
                    return RedirectToAction("Details", new { id = prescription.Id });
                }
                else
                {
                    var pres = await db.Prescriptions.SingleOrDefaultAsync(d => d.Id == prescription.Id);
                    if (prescription == null)
                        return HttpNotFound();
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
            }
            catch
            {
                return HttpNotFound();
            }

        }

        // GET: Prescription/PatientPrescriptions/5
        public async Task<ActionResult> PatientPrescriptions(int id)
        {
            try
            {
                if (User.IsInRole("Administrador"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                else if (User.IsInRole("Asistente"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                else
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

                var list = await db.Prescriptions.Include(p => p.ApplicationUser).Include(p => p.Patient).Where(s => s.PatientId == id).ToListAsync();
                var patient = await db.Patients.SingleOrDefaultAsync(p => p.Id == id);
                if (patient == null)
                    return HttpNotFound();

                var patientPrescriptionViewModel = new PatientPrescriptionViewModel
                {
                    Id = id,
                    Patient = patient.Name + " " + patient.LastName,
                    Prescriptions = list
                };
                return View(patientPrescriptionViewModel);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
            
        }
    }
}
