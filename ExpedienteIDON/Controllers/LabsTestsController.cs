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
    [Authorize(Roles = "Administrador,Doctor")]
    public class LabsTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LabsTests
        public ActionResult Index()
        {
            var labsTests = db.LabsTests.Include(l => l.MedicalRecord);
            return View(labsTests.ToList());
        }

        // GET: LabsTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabsTest labsTest = db.LabsTests.Find(id);
            if (labsTest == null)
            {
                return HttpNotFound();
            }
            return View(labsTest);
        }

        // GET: LabsTests/Create
        public ActionResult Create()
        {
            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id");
            return View();
        }

        // POST: LabsTests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,HemoglobinaGlucosilada,GlucosaSerica,GlucosaAyuno,GlucosaCasual,MedicalRecordId")] LabsTest labsTest)
        {
            if (ModelState.IsValid)
            {
                db.LabsTests.Add(labsTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id", labsTest.MedicalRecordId);
            return View(labsTest);
        }

        // GET: LabsTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabsTest labsTest = db.LabsTests.Find(id);
            if (labsTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id", labsTest.MedicalRecordId);
            return View(labsTest);
        }

        // POST: LabsTests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,HemoglobinaGlucosilada,GlucosaSerica,GlucosaAyuno,GlucosaCasual,MedicalRecordId")] LabsTest labsTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labsTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicalRecordId = new SelectList(db.MedicalRecords, "Id", "Id", labsTest.MedicalRecordId);
            return View(labsTest);
        }

        // GET: LabsTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabsTest labsTest = db.LabsTests.Find(id);
            if (labsTest == null)
            {
                return HttpNotFound();
            }
            return View(labsTest);
        }

        // POST: LabsTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabsTest labsTest = db.LabsTests.Find(id);
            db.LabsTests.Remove(labsTest);
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
