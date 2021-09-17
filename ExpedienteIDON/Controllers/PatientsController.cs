using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;

namespace ExpedienteIDON.Controllers
{
    [Authorize(Roles = "Administrador,Doctor,Asistente")]
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public async Task<ActionResult> Index()
        {
            var patient = await db.Patients.ToListAsync();
            List<PatientRecordProfile> patientList = new List<PatientRecordProfile>();
            foreach (var item in patient)
            {
                var patientRecordProfile = new PatientRecordProfile
                {
                    Patient = item
                };
                var record = await db.MedicalRecords.Where(a => a.PatientId == item.Id).FirstOrDefaultAsync();
                if (record == null)
                {
                    patientRecordProfile.Record = false;
                }
                else
                {
                    patientRecordProfile.Record = true;
                }
                var relativePath = "~/Content/UploadedFiles/" + patientRecordProfile.Patient.Photo;
                var absolutePath = HttpContext.Server.MapPath(relativePath);
                if (!System.IO.File.Exists(absolutePath))
                {
                    patientRecordProfile.Patient.Photo = "patient1.jpg";
                }
                patientList.Add(patientRecordProfile);
            }

            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                return View("ReadOnlyList",patientList);
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            return View(patientList);
        }

        [Authorize(Roles = "Administrador,Doctor")]
        // GET: Patients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            var patient = await db.Patients.FindAsync(id);
            var evolutionNote = await db.EvolutionNotes.OrderByDescending(e => e.CreatedDate).Include(m => m.Others).Where(a => a.PatientId == id).ToListAsync();
            var record = await db.MedicalRecords.Where(a => a.PatientId == id).FirstOrDefaultAsync();
            var prescriptions = await db.Prescriptions.Where(p => p.PatientId == id).ToListAsync();
            
            if (patient == null)
            {
                return HttpNotFound();
            }
            List<EvolutionNote> evolutionNotes = new List<EvolutionNote>();
            evolutionNotes = await db.EvolutionNotes.OrderByDescending(e => e.CreatedDate).Where(e => e.PatientId == id).Include(v => v.VitalSigns).Take(5).ToListAsync();
            List<String> dates = new List<String>();
            List<String> weight = new List<String>();
            List<String> glucose = new List<String>();
            List<String> TASistBI = new List<String>();
            List<String> TADiastBI = new List<String>();
            if (evolutionNotes.Count > 0)
            {
                foreach (var item in evolutionNotes)
                {
                    weight.Add(""+item.VitalSigns.Weight);
                    dates.Add(item.CreatedDate.ToString("dd/MM/yyyy"));
                    glucose.Add("" + item.VitalSigns.Glucose);
                    TASistBI.Add("" + item.VitalSigns.TASistBI);
                    TADiastBI.Add("" + item.VitalSigns.TADiastBI);
                }
            }
            await db.Patients.ToListAsync();
            var relativePath = "~/Content/UploadedFiles/" + patient.Photo;
            var absolutePath = HttpContext.Server.MapPath(relativePath);
            if (!System.IO.File.Exists(absolutePath))
            {
                patient.Photo = "patient1.jpg";
            }
            var perfilPatient = new PerfilPatientVM
            {
                TASistBI = TASistBI,
                TADiastBI = TADiastBI,
                Dates = dates,
                Glucose = glucose,
                Weight = weight,
                Patient = patient,
                MedicalRecord = record,
                EvolutionNotes = evolutionNote,
                Prescriptions=prescriptions
            };
            return View(perfilPatient);
        }

        [Authorize(Roles = "Administrador,Doctor")]
        // GET: Patients/DetailsMedicalRecord/5
        public async Task<ActionResult> DetailsMedicalRecord(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            
            MedicalRecord record = await db.MedicalRecords.Include(p => p.Patient)
                                                    .Include(d=>d.Doctor)
                                                    .Include(u=>u.ApplicationUser)
                                                    .Include(b=>b.BiometriaHematica)
                                                    .Include(m => m.FamilyRecord)
                                                    .Include(m => m.GeneralOrina)
                                                    .Include(m => m.GynecoRecord)
                                                    .Include(m => m.Hormonas)
                                                    .Include(m => m.MedicalTest)
                                                    .Include(m => m.NonPathologicalRecord)
                                                    .Include(m => m.Others)
                                                    .Include(m => m.OtrosLabs)
                                                    .Include(m => m.PathologicRecord)
                                                    .Include(m => m.PerfilHepatico)
                                                    .Include(m => m.PerfilTiroideo)
                                                    .Include(m => m.PhysicalExploration)
                                                    .Include(m => m.QuimicaSanguinea)
                                                    .Include(m => m.VitalSigns)
                                                    .SingleOrDefaultAsync(r => r.PatientId == id);
            var user = db.Users.FirstOrDefault(x => x.Id == record.ApplicationUserId);
            var historyRecordViewModel = new HistoryRecordViewModel
            {
                Doctor = await db.Doctors.FindAsync(record.DoctorId),
                OtherFamilyRecord = await db.OtherFamilyRecords.Include(o => o.FamilyRecord).SingleOrDefaultAsync(o => o.FamilyRecordId == record.FamilyRecordId),
                OtherPathologicRecord = await db.OtherPathologicRecords.Include(o => o.PathologicRecord).SingleOrDefaultAsync(o => o.PathologicRecordId == record.PathologicRecordId),
                MedicalRecord = record,
                Symptoms = await db.Symptoms.Include(s => s.MedicalRecord).Where(s => s.MedicalRecordId == record.Id).ToListAsync(),
                LabsTest = await db.LabsTests.Include(s => s.MedicalRecord).SingleOrDefaultAsync(s => s.MedicalRecordId == record.Id),
                BloodTypes = await db.BloodTypes.ToListAsync(),
                Prescription = await db.Prescriptions.Include(s => s.MedicalRecord).SingleOrDefaultAsync(s => s.MedicalRecordId == record.Id),
                UserDataViewModel = new UserDataViewModel
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Cedula = user.Cedula
                }
            };
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(historyRecordViewModel);
        }

        // GET: Patients/CreateRecordAlone
        [Authorize(Roles = "Administrador,Doctor")]
        [Route("Patients/CreateRecordAlone/{patientId}")]
        public async Task<ActionResult> CreateRecordAlone(int patientId)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            var patient = await db.Patients.SingleAsync(p => p.Id == patientId);
            string currentUserId = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var historyRecord = new HistoryRecordViewModelWithPatient
            {
                UserDataViewModel = new UserDataViewModel
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Cedula = user.Cedula
                },
                Patient = patient,
                BloodTypes = await db.BloodTypes.ToListAsync(),
                Estados = await db.Estadoes.ToListAsync(),
                MedicalRecord = new MedicalRecord
                { 
                VitalSigns = new VitalSigns
                {
                    OxygenSaturation = 98,
                    FC = 60,
                    FR = 20
                    ,
                    Glucose = 100,
                    Hip = 0.0d,
                    Size = 160,
                    TADiastBD = 60,
                    TADiastBI = 60
                    ,
                    TASistBD = 120,
                    TASistBI = 120,
                    Waist = 0.0d,
                    Weight = 0.0d
                }
                },
                OtherFamilyRecord = new OtherFamilyRecord(),
                OtherPathologicRecord = new OtherPathologicRecord(),
                Symptoms = new List<Symptom>()
                {
                  new Symptom { }
                },
                LabsTest = new LabsTest(),

            };
            return View(historyRecord);
        }
        // POST: Patients/CreateRecordAlone
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Doctor")]
        [Route("Patients/CreateRecordAlone/{patientId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRecordAlone(
             OtherFamilyRecord otherFamilyRecord, OtherPathologicRecord otherPathologicRecord, MedicalRecord medicalRecord, 
             List<Symptom> symptoms, LabsTest labsTest, string Type,  String idPatient)
        {
            if (ModelState.IsValid)
            {
                medicalRecord.Created = DateTime.Now;
                medicalRecord.DoctorId = 1;
                medicalRecord.ApplicationUserId = User.Identity.GetUserId();
                medicalRecord.PatientId = int.Parse(idPatient);
                var imc = (medicalRecord.VitalSigns.Weight / (medicalRecord.VitalSigns.Size * medicalRecord.VitalSigns.Size)) * 10000;
                medicalRecord.VitalSigns.IMC = imc;
                db.MedicalRecords.Add(medicalRecord);
                var idMD = medicalRecord.Id;
                var idFR = medicalRecord.FamilyRecordId;
                var idPR = medicalRecord.PathologicRecordId;
                otherFamilyRecord.FamilyRecordId = idFR;
                otherPathologicRecord.PathologicRecordId = idPR;
                labsTest.MedicalRecordId = idMD;
                foreach (var item in symptoms)
                {
                    item.MedicalRecordId = idMD;
                    db.Symptoms.Add(item);
                }
                db.OtherFamilyRecords.Add(otherFamilyRecord);
                db.OtherPathologicRecords.Add(otherPathologicRecord);
                //db.LabsTests.Add(labsTest);
                db.SaveChanges();
                if (Type == "Guardar sin Receta")
                    return RedirectToAction("DetailsMedicalRecord", "Patients", new { id = medicalRecord.PatientId });
                else
                    return RedirectToAction("Create", "MedicalRecordPrescription", new { patientId = medicalRecord.PatientId, medicalRecordId = medicalRecord.Id });

            }
            else
            {
                string currentUserId = User.Identity.GetUserId();
                var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                var historyRecord = new HistoryRecordViewModelWithPatient
                {
                    UserDataViewModel = new UserDataViewModel
                    {
                        Name = user.Name,
                        LastName = user.LastName,
                        Phone = user.Phone,
                        Cedula = user.Cedula
                    },
                    Patient = await db.Patients.FindAsync(int.Parse(idPatient)),
                    BloodTypes = await db.BloodTypes.ToListAsync(),
                    Estados = await db.Estadoes.ToListAsync(),
                    MedicalRecord = medicalRecord,
                    OtherFamilyRecord = otherFamilyRecord,
                    OtherPathologicRecord = otherPathologicRecord,
                    Symptoms = symptoms,
                    LabsTest = labsTest,

                };
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (User.IsInRole("Administrador"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                else if (User.IsInRole("Asistente"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                else
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
                return View(historyRecord);
            }
            
        }

        // GET: Patients/Create
        [Authorize(Roles = "Administrador,Doctor")]
        public async Task<ActionResult> Create()
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            string currentUserId = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var historyRecord = new HistoryRecordViewModel
            {
                UserDataViewModel = new UserDataViewModel
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Cedula = user.Cedula
                },
                BloodTypes = await db.BloodTypes.ToListAsync(),
                Estados = await db.Estadoes.ToListAsync(),
                Municipios = await db.Municipios.ToListAsync(),
                MedicalRecord = new MedicalRecord
                {
                    VitalSigns = new VitalSigns
                    {
                        OxygenSaturation = 98,
                        FC = 60,
                        FR = 20
                    ,
                        Glucose = 100,
                        Hip = 0.0d,
                        Size = 160,
                        TADiastBD = 60,
                        TADiastBI = 60
                    ,
                        TASistBD = 120,
                        TASistBI = 120,
                        Waist = 0.0d,
                        Weight = 0.0d
                    }
                },
                OtherFamilyRecord = new OtherFamilyRecord(),
                OtherPathologicRecord = new OtherPathologicRecord(),
                Symptoms = new List<Symptom>()
                {
                  new Symptom { }  
                },
                LabsTest = new LabsTest(),

            };
            return View(historyRecord);
        }

        // POST: Patients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create
            (OtherFamilyRecord otherFamilyRecord, OtherPathologicRecord otherPathologicRecord, MedicalRecord medicalRecord, 
             List<Symptom> symptoms, LabsTest labsTest, string Type, HttpPostedFileBase file)

        {
            if (ModelState.IsValid)
            {
                medicalRecord.Created = DateTime.Now;
                medicalRecord.Patient.Created = DateTime.Now;
                medicalRecord.DoctorId = 1;
                medicalRecord.ApplicationUserId = User.Identity.GetUserId();
                var imc = (medicalRecord.VitalSigns.Weight / (medicalRecord.VitalSigns.Size * medicalRecord.VitalSigns.Size)) * 10000;
                medicalRecord.VitalSigns.IMC = imc;
                if (file == null)
                {
                    medicalRecord.Patient.Photo = "patient1.jpg";
                }
                else
                {
                    WebImage img = new WebImage(file.InputStream);
                    if (img.Width > 300)
                        img.Resize(300, 300, true);
                    string path = Path.Combine(Server.MapPath("~/Content/UploadedFiles"), Path.GetFileName(file.FileName));
                    img.Save(path);
                    medicalRecord.Patient.Photo = file.FileName;
                    
                }

                db.MedicalRecords.Add(medicalRecord);
                db.SaveChanges();
                var idMD = medicalRecord.Id;
                var idFR = medicalRecord.FamilyRecordId;
                var idPR = medicalRecord.PathologicRecordId;
                otherFamilyRecord.FamilyRecordId = idFR;
                otherPathologicRecord.PathologicRecordId = idPR;
                labsTest.MedicalRecordId = idMD;
                foreach (var item in symptoms)
                {
                    item.MedicalRecordId = idMD;
                    db.Symptoms.Add(item);
                }
                db.OtherFamilyRecords.Add(otherFamilyRecord);
                db.OtherPathologicRecords.Add(otherPathologicRecord);
                //db.LabsTests.Add(labsTest);
                db.SaveChanges();

                //db.Symptoms.Add(symptom);
                //db.LabsTests.Add(labsTest);

                if (Type == "Guardar sin Receta")
                {
                    return RedirectToAction("DetailsMedicalRecord", "Patients", new { id = medicalRecord.PatientId });
                }
                else
                {
                    return RedirectToAction("Create", "MedicalRecordPrescription", new { patientId = medicalRecord.PatientId, medicalRecordId = medicalRecord.Id });
                }

            }
            else
            {
                string currentUserId = User.Identity.GetUserId();
                var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                var historyRecord = new HistoryRecordViewModel
                {
                    UserDataViewModel = new UserDataViewModel
                    {
                        Name = user.Name,
                        LastName = user.LastName,
                        Phone = user.Phone,
                        Cedula = user.Cedula
                    },
                    BloodTypes = await db.BloodTypes.ToListAsync(),
                    Municipios = await db.Municipios.ToListAsync(),
                    Estados = await db.Estadoes.ToListAsync(),
                    MedicalRecord = medicalRecord,
                    OtherFamilyRecord = otherFamilyRecord,
                    OtherPathologicRecord = otherPathologicRecord,
                    Symptoms = symptoms,
                    LabsTest = labsTest,

                };
                if (User.IsInRole("Administrador"))
                {
                    ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                }
                else if (User.IsInRole("Asistente"))
                {
                    ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                }
                else
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
                return View(historyRecord);
            }
        }

        // GET: Patients/CreateNoRecord
        public ActionResult CreateNoRecord()
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            var patient = new Patient();
            return View(patient);
        }

        // POST: Patients/CreateNoRecord
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNoRecord(Patient patient, HttpPostedFileBase file)
        {
           
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    patient.Photo = "patient1.jpg";
                }
                else
                {
                    WebImage img = new WebImage(file.InputStream);
                    if (img.Width > 300)
                        img.Resize(300, 300, true);
                    string path = Path.Combine(Server.MapPath("~/Content/UploadedFiles"), Path.GetFileName(file.FileName));
                    img.Save(path);
                    patient.Photo = file.FileName;
                }
                patient.Created = DateTime.Now;
                db.Patients.Add(patient);
                await db.SaveChangesAsync();
                int lastId = patient.Id;
                return RedirectToAction("Details", "Patients", new { id = lastId });
            }
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View(patient);
        }

        // GET: Patients/Edit/5
        [Authorize(Roles = "Administrador,Doctor")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(     
                Patient patient, 
                HttpPostedFileBase file,
                string photoFile)
        {
            
            if (ModelState.IsValid)
            {
                var patientInDb = db.Patients.SingleOrDefault(p => p.Id == patient.Id);
                if (file != null)
                {
                    WebImage img = new WebImage(file.InputStream);
                    if (img.Width > 300)
                        img.Resize(300, 300, true);
                    string path = Path.Combine(Server.MapPath("~/Content/UploadedFiles"), Path.GetFileName(file.FileName));
                    img.Save(path);
                    patient.Photo = file.FileName;
                    
                }
                else
                    patient.Photo = patientInDb.Photo;

                Mapper.Map(patient, patientInDb);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Patients", new { id = patient.Id });
            }
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View(patient);
        }
        [Authorize(Roles = "Administrador,Doctor")]
        // GET: Patients/EditMedicalRecord/5
        public async Task<ActionResult> EditMedicalRecord(int? id)
        {
            if (User.IsInRole("Administrador"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            else if (User.IsInRole("Asistente"))
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MedicalRecord record = await db.MedicalRecords.Include(p => p.Patient)
                                                    .Include(m => m.FamilyRecord)
                                                    .Include(m => m.ApplicationUser)
                                                    .Include(m => m.BiometriaHematica)
                                                    .Include(m => m.GeneralOrina)
                                                    .Include(m => m.GynecoRecord)
                                                    .Include(m => m.Hormonas)
                                                    .Include(m => m.MedicalTest)
                                                    .Include(m => m.NonPathologicalRecord)
                                                    .Include(m => m.Others)
                                                    .Include(m => m.OtrosLabs)
                                                    .Include(m => m.PathologicRecord)
                                                    .Include(m => m.PerfilHepatico)
                                                    .Include(m => m.PerfilTiroideo)
                                                    .Include(m => m.PhysicalExploration)
                                                    .Include(m => m.QuimicaSanguinea)
                                                    .Include(m => m.VitalSigns)
                                                    .Where(a => a.PatientId == id)
                                                    .SingleAsync();
            var user = record.ApplicationUser;
            var historyRecordViewModel = new HistoryRecordViewModelWithPatient
            {
                UserDataViewModel = new UserDataViewModel
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Cedula = user.Cedula
                },
                Doctor = await db.Doctors.SingleOrDefaultAsync(d => d.Id == record.DoctorId),
                Patient = await db.Patients.SingleOrDefaultAsync(p => p.Id == record.PatientId),
                OtherFamilyRecord = await db.OtherFamilyRecords.Include(o => o.FamilyRecord).SingleOrDefaultAsync(o => o.FamilyRecordId == record.FamilyRecordId),
                OtherPathologicRecord = await db.OtherPathologicRecords.Include(o => o.PathologicRecord).SingleOrDefaultAsync(o => o.PathologicRecordId == record.PathologicRecordId),
                MedicalRecord = record,
                Symptoms = await db.Symptoms.Include(s => s.MedicalRecord).Where(s => s.MedicalRecordId == record.Id).ToListAsync(),
                LabsTest = await db.LabsTests.SingleOrDefaultAsync(l => l.MedicalRecordId == record.Id),
                BloodTypes = await db.BloodTypes.ToListAsync(),
            };
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(historyRecordViewModel);
        }
        [Authorize(Roles = "Administrador,Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMedicalRecord(
            MedicalRecord medicalRecord, List<Symptom> symptoms,
            OtherPathologicRecord otherPathologicRecord, OtherFamilyRecord otherFamilyRecord
            )
        {
            
            var pat = await db.Patients.SingleOrDefaultAsync(p => p.Id == medicalRecord.PatientId);
            var doc = await db.Doctors.SingleOrDefaultAsync(d => d.Id == medicalRecord.DoctorId);
            var UserApp = await db.MedicalRecords.SingleOrDefaultAsync(m=>m.Id== medicalRecord.Id);
            var user = await db.Users.SingleOrDefaultAsync(d => d.Id == UserApp.ApplicationUserId);

            medicalRecord.Patient = pat;
            medicalRecord.Doctor = doc;
            medicalRecord.ApplicationUser = user;
            medicalRecord.ApplicationUserId = user.Id;
            var imc = (medicalRecord.VitalSigns.Weight / (medicalRecord.VitalSigns.Size * medicalRecord.VitalSigns.Size)) * 10000;
            medicalRecord.VitalSigns.IMC = imc;

            if (ModelState.IsValid)
            {
                var medicalInDb = db.MedicalRecords
                        .Include(d=>d.Doctor)
                        .Include(p=>p.Patient)
                        .Include(u=>u.ApplicationUser)
                        .Include(v => v.VitalSigns)
                        .Include(b => b.BiometriaHematica)
                        .Include(g => g.GeneralOrina)
                        .Include(h => h.Hormonas)
                        .Include(ph => ph.PerfilHepatico)
                        .Include(pt => pt.PerfilTiroideo)
                        .Include(q => q.QuimicaSanguinea)
                        .Include(ol => ol.OtrosLabs)
                        .Include(q => q.Patient)
                        .Include(q => q.Doctor)
                        .Include(q => q.FamilyRecord)
                        .Include(q => q.GynecoRecord)
                        .Include(q => q.MedicalTest)
                        .Include(q => q.NonPathologicalRecord)
                        .Include(q => q.Others)
                        .Include(q => q.PathologicRecord)
                        .Include(q => q.PhysicalExploration)
                        .SingleOrDefault(m => m.Id == medicalRecord.Id);

                var otherpathInDb = await db.OtherPathologicRecords.Include(o => o.PathologicRecord).SingleOrDefaultAsync(o => o.PathologicRecordId == medicalRecord.PathologicRecordId);
                var otherFamInDb = db.OtherFamilyRecords.Include(o => o.FamilyRecord).SingleOrDefault(o => o.FamilyRecordId == medicalRecord.FamilyRecordId);
                var familyRecInDb = await db.FamilyRecords.SingleOrDefaultAsync(f => f.Id == medicalRecord.FamilyRecordId);
                var nonPathRecordInDb = await db.NonPathologicalRecords.SingleOrDefaultAsync(f => f.Id == medicalRecord.NonPathologicalRecordId);
                var gynecoRecordInDb = await db.GynecoRecords.SingleOrDefaultAsync(f => f.Id == medicalRecord.GynecoRecordId);
                var pathRecordInDb = await db.PathologicRecords.SingleOrDefaultAsync(f => f.Id == medicalRecord.PathologicRecordId);
                var medicalTestInDb = await db.MedicalTests.SingleOrDefaultAsync(f => f.Id == medicalRecord.MedicalTestId);
                var physicalExplorationInDb = await db.PhysicalExplorations.SingleOrDefaultAsync(f => f.Id == medicalRecord.PhysicalExplorationId);
                var othersInDb = await db.Others.SingleOrDefaultAsync(o => o.Id == medicalRecord.OthersId);
                var vitalSignsInDb = await db.VitalSigns.SingleOrDefaultAsync(v => v.Id == medicalRecord.VitalSignsId);
                var biomInDb = await db.BiometriaHematicas.SingleOrDefaultAsync(b => b.Id == medicalRecord.BiometriaHematicaId);
                var hormInDb = await db.Hormonas.SingleOrDefaultAsync(b => b.Id == medicalRecord.HormonasId);
                var quimInDb = await db.QuimicaSanguineas.SingleOrDefaultAsync(b => b.Id == medicalRecord.QuimicaSanguineaId);
                var perfHepInDb = await db.PerfilHepaticos.SingleOrDefaultAsync(b => b.Id == medicalRecord.PerfilHepaticoId);
                var perfTirInDb = await db.PerfilTiroideos.SingleOrDefaultAsync(b => b.Id == medicalRecord.PerfilTiroideoId);
                var genOrInDb = await db.GeneralOrinas.SingleOrDefaultAsync(b => b.Id == medicalRecord.GeneralOrinaId);
                var otroslabInDb = await db.OtrosLabs.SingleOrDefaultAsync(b => b.Id == medicalRecord.OtrosLabsId);

                var nonPathRecord = medicalRecord.NonPathologicalRecord;
                var gynecoRecord = medicalRecord.GynecoRecord;
                var pathRecord = medicalRecord.PathologicRecord;
                var medicalTest = medicalRecord.MedicalTest;
                var physicalExploration = medicalRecord.PhysicalExploration;
                var others = medicalRecord.Others;
                var vitalSigns = medicalRecord.VitalSigns;
                var biom = medicalRecord.BiometriaHematica;
                var horm = medicalRecord.Hormonas;
                var quim = medicalRecord.QuimicaSanguinea;
                var perfHep = medicalRecord.PerfilHepatico;
                var perfTir = medicalRecord.PerfilTiroideo;
                var genOr = medicalRecord.GeneralOrina;
                var otroslab = medicalRecord.OtrosLabs;
                var familyRecord = medicalRecord.FamilyRecord;
               
                Mapper.Map(familyRecord, familyRecInDb);
                Mapper.Map(nonPathRecord, nonPathRecordInDb);
                Mapper.Map(gynecoRecord, gynecoRecordInDb);
                Mapper.Map(pathRecord, pathRecordInDb);
                Mapper.Map(medicalTest, medicalTestInDb);
                Mapper.Map(physicalExploration, physicalExplorationInDb);
                Mapper.Map(others, othersInDb);
                Mapper.Map(vitalSigns, vitalSignsInDb);
                Mapper.Map(biom, biomInDb);
                Mapper.Map(genOr, genOrInDb);
                Mapper.Map(horm, hormInDb);
                Mapper.Map(quim, quimInDb);
                Mapper.Map(perfHep, perfHepInDb);
                Mapper.Map(perfTir, perfTirInDb);
                Mapper.Map(otroslab, otroslabInDb);
                foreach (var item in symptoms)
                {
                    if (item != null)
                    {
                        if (item.Id != 0)
                        {
                            var sympthomInDb = await db.Symptoms.Include(s => s.MedicalRecord).SingleOrDefaultAsync(s => s.Id == item.Id);
                            item.MedicalRecordId = medicalRecord.Id;
                            item.MedicalRecord = medicalRecord;
                            Mapper.Map(item, sympthomInDb);
                            await db.SaveChangesAsync();
                        }
                        else
                        {
                            item.MedicalRecordId = medicalRecord.Id;
                            db.Symptoms.Add(item);
                        }
                        
                    }
                }
                otherPathologicRecord.PathologicRecord = medicalRecord.PathologicRecord;
                Mapper.Map(otherPathologicRecord, otherpathInDb);
                otherFamilyRecord.FamilyRecord = medicalRecord.FamilyRecord;
                Mapper.Map(otherFamilyRecord, otherFamInDb);
                db.SaveChanges();
                return RedirectToAction("DetailsMedicalRecord", new { id = medicalRecord.PatientId });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View();
        }

        public ActionResult GetMunicipios(int estadoId)
        {
            var selecList = db.Municipios.Where(m => m.EstadoId == estadoId);
            ViewBag.Municipio = new SelectList(selecList, "Id", "Name");
            return PartialView("_DisplayMunicipio");
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
