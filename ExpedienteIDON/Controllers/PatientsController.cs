using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;

namespace ExpedienteIDON.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
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

        // GET: Patients/Create
        public ActionResult Create()
        {
            var historyRecord = new HistoryRecordViewModel
            {

                BloodTypes = db.BloodTypes.ToList(),
                FamilyRecord = new FamilyRecord(),
                GynecoRecord = new GynecoRecord(),
                MedicalRecord = new MedicalRecord(),
                NonPathologicalRecord = new NonPathologicalRecord(),
                OtherFamilyRecord = new OtherFamilyRecord(),
                OtherPathologicRecord = new OtherPathologicRecord(),
                PathologicRecord = new PathologicRecord(),
                Patient = new Patient(),
                Symptom=new Symptom(),
                VitalSigns=new VitalSigns(),
                PhysicalExploration=new PhysicalExploration(),
                MedicalTest=new MedicalTest(),
                LabsTest=new LabsTest(),
                Others= new Others(),
                BiometriaHematica=new BiometriaHematica(),
                PerfilHepatico=new PerfilHepatico(),
                QuimicaSanguinea=new QuimicaSanguinea(),
                PerfilTiroideo=new PerfilTiroideo(),
                Hormonas=new Hormonas(),
                GeneralOrina=new GeneralOrina(),
                OtrosLabs=new OtrosLabs()

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
        FamilyRecord familyRecord, OtherFamilyRecord otherFamilyRecord, GynecoRecord gynecoRecord, NonPathologicalRecord nonPathologicalRecord
            , Patient patient, PathologicRecord pathologicRecord, OtherPathologicRecord otherPathologicRecord, MedicalRecord medicalRecord
            ,Symptom symptom, VitalSigns vitalSigns, PhysicalExploration physicalExploration, MedicalTest medicalTest, LabsTest labsTest
            , Others others, BiometriaHematica biometriaHematica, QuimicaSanguinea quimicaSanguinea, Hormonas hormonas, PerfilHepatico perfilHepatico
            , PerfilTiroideo perfilTiroideo, GeneralOrina generalOrina, OtrosLabs otrosLabs)
        {
            var historyRecord = new HistoryRecordViewModel
            {

                BloodTypes = db.BloodTypes.ToList(),
                FamilyRecord = familyRecord,
                GynecoRecord = gynecoRecord,
                MedicalRecord = medicalRecord,
                NonPathologicalRecord = nonPathologicalRecord,
                OtherFamilyRecord = otherFamilyRecord,
                OtherPathologicRecord = otherPathologicRecord,
                PathologicRecord = pathologicRecord,
                Patient = patient,
                Symptom = symptom,
                VitalSigns = vitalSigns,
                PhysicalExploration = physicalExploration,
                MedicalTest = medicalTest,
                LabsTest = labsTest,
                Others = others,
                BiometriaHematica = biometriaHematica,
                PerfilHepatico = perfilHepatico,
                QuimicaSanguinea = quimicaSanguinea,
                PerfilTiroideo = perfilTiroideo,
                Hormonas = hormonas,
                GeneralOrina = generalOrina,
                OtrosLabs = otrosLabs

            };
            if (ModelState.IsValid)
            {
                medicalRecord.Created = DateTime.Now;
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
