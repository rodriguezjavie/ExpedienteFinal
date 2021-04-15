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
    public class VitalSignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VitalSigns
        public ActionResult Index()
        {
            return View(db.VitalSigns.ToList());
        }

        // GET: VitalSigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = db.VitalSigns.Find(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
        }

        // GET: VitalSigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VitalSigns/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Size,Weight,IMC,TABD,TABI,FC,FR,Waist,Hip,OxygenSaturation")] VitalSigns vitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.VitalSigns.Add(vitalSigns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vitalSigns);
        }

        // GET: VitalSigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = db.VitalSigns.Find(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
        }

        // POST: VitalSigns/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Size,Weight,IMC,TABD,TABI,FC,FR,Waist,Hip,OxygenSaturation")] VitalSigns vitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vitalSigns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vitalSigns);
        }

        // GET: VitalSigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = db.VitalSigns.Find(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
        }

        // POST: VitalSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VitalSigns vitalSigns = db.VitalSigns.Find(id);
            db.VitalSigns.Remove(vitalSigns);
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
