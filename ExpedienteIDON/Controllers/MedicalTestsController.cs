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
    public class MedicalTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalTests
        public ActionResult Index()
        {
            return View(db.MedicalTests.ToList());
        }

        // GET: MedicalTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            if (medicalTest == null)
            {
                return HttpNotFound();
            }
            return View(medicalTest);
        }

        // GET: MedicalTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalTests/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RadiographTorax,RadiographToraxDate,RadiographToraxNormal,Ultrasound,UltrasoundDate,UltrasoundType,Observations,Electrocardiography,ElectrocardiographyDate,ElectrocardiographyNormal,ElectrocardiographyObservations,Others")] MedicalTest medicalTest)
        {
            if (ModelState.IsValid)
            {
                db.MedicalTests.Add(medicalTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalTest);
        }

        // GET: MedicalTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            if (medicalTest == null)
            {
                return HttpNotFound();
            }
            return View(medicalTest);
        }

        // POST: MedicalTests/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RadiographTorax,RadiographToraxDate,RadiographToraxNormal,Ultrasound,UltrasoundDate,UltrasoundType,Observations,Electrocardiography,ElectrocardiographyDate,ElectrocardiographyNormal,ElectrocardiographyObservations,Others")] MedicalTest medicalTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalTest);
        }

        // GET: MedicalTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            if (medicalTest == null)
            {
                return HttpNotFound();
            }
            return View(medicalTest);
        }

        // POST: MedicalTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            db.MedicalTests.Remove(medicalTest);
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
