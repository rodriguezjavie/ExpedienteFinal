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
    public class OtrosLabsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OtrosLabs
        public ActionResult Index()
        {
            return View(db.OtrosLabs.ToList());
        }

        // GET: OtrosLabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtrosLabs otrosLabs = db.OtrosLabs.Find(id);
            if (otrosLabs == null)
            {
                return HttpNotFound();
            }
            return View(otrosLabs);
        }

        // GET: OtrosLabs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtrosLabs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,VitaminaD,Calcio,Fosforo,Magnesio,Sodio,Potasio,Cloro,HemoglobinaGlugosilada")] OtrosLabs otrosLabs)
        {
            if (ModelState.IsValid)
            {
                db.OtrosLabs.Add(otrosLabs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otrosLabs);
        }

        // GET: OtrosLabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtrosLabs otrosLabs = db.OtrosLabs.Find(id);
            if (otrosLabs == null)
            {
                return HttpNotFound();
            }
            return View(otrosLabs);
        }

        // POST: OtrosLabs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,VitaminaD,Calcio,Fosforo,Magnesio,Sodio,Potasio,Cloro,HemoglobinaGlugosilada")] OtrosLabs otrosLabs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otrosLabs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otrosLabs);
        }

        // GET: OtrosLabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtrosLabs otrosLabs = db.OtrosLabs.Find(id);
            if (otrosLabs == null)
            {
                return HttpNotFound();
            }
            return View(otrosLabs);
        }

        // POST: OtrosLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtrosLabs otrosLabs = db.OtrosLabs.Find(id);
            db.OtrosLabs.Remove(otrosLabs);
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
