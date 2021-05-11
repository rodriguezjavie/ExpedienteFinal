using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExpedienteIDON.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            var patient = db.MedicalRecords.Include(m => m.Patient).Include(m => m.NonPathologicalRecord.BloodType).Include(m => m.Others).ToList();
            return View(patient);
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        public ActionResult DetailsMedicalRecord(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalRecord record = db.MedicalRecords.Include(p => p.Patient).Where(a => a.PatientId == id).Single();
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            var historyRecord = new HistoryRecordViewModel
            {

                BloodTypes = db.BloodTypes.ToList(),
                Estados = db.Estadoes.ToList(),
                Municipios = db.Municipios.ToList(),
                MedicalRecord = new MedicalRecord(),
                OtherFamilyRecord = new OtherFamilyRecord(),
                OtherPathologicRecord = new OtherPathologicRecord(),
                Symptom = new Symptom(),
                LabsTest = new LabsTest(),

            };
            return View(historyRecord);
        }

        // POST: Patients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create
            ([Bind(Include = "Id,Name,LastName,Birthday,PatientGender,Phone,Cellphone,Email,Photo,Ocupation,PatientStudies,PatientCivilStatus,Address")]
             OtherFamilyRecord otherFamilyRecord, OtherPathologicRecord otherPathologicRecord, MedicalRecord medicalRecord
            , Symptom symptom, LabsTest labsTest)
            
        {
            var historyRecord = new HistoryRecordViewModel
            {

                BloodTypes = db.BloodTypes.ToList(),
                Municipios = db.Municipios.ToList(),
                Estados = db.Estadoes.ToList(),
                MedicalRecord = medicalRecord,
                OtherFamilyRecord = otherFamilyRecord,
                OtherPathologicRecord = otherPathologicRecord,
                Symptom = symptom,
                LabsTest = labsTest,

            };
            if (ModelState.IsValid)
            {
                medicalRecord.Created = DateTime.Now;
                if (medicalRecord.Patient.PatientGender == Gender.Masculino)
                    medicalRecord.GynecoRecord = null;
                db.MedicalRecords.Add(medicalRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historyRecord);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Birthday,PatientGender,Phone,Cellphone,Email,Photo,Ocupation,PatientStudies,PatientCivilStatus,Address")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
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
