using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpedienteIDON.Models;

namespace ExpedienteIDON.Controllers
{
    public class SymptomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Symptoms
        public ActionResult Index()
        {
            var symptoms = db.Symptoms.Include(s => s.MedicalRecord);
            return View(symptoms.ToList());
        }

        // GET: Symptoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            return View(symptom);
        }

        // GET: Symptoms/Create
        public ActionResult Create()
        {
            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id");
            return View();
        }

        // POST: Symptoms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Severity,StartDate,EndDate,MedicalRecordId")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                db.Symptoms.Add(symptom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id", symptom.MedicalRecordId);
            return View(symptom);
        }

        // GET: Symptoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id", symptom.MedicalRecordId);
            return View(symptom);
        }

        // POST: Symptoms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Severity,StartDate,EndDate,MedicalRecordId")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symptom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id", symptom.MedicalRecordId);
            return View(symptom);
        }

        // GET: Symptoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            return View(symptom);
        }

        // POST: Symptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Symptom symptom = db.Symptoms.Find(id);
            db.Symptoms.Remove(symptom);
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
