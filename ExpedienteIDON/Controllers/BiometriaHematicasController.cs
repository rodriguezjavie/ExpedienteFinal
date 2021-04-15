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
    public class BiometriaHematicasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BiometriaHematicas
        public ActionResult Index()
        {
            return View(db.BiometriaHematicas.ToList());
        }

        // GET: BiometriaHematicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiometriaHematica biometriaHematica = db.BiometriaHematicas.Find(id);
            if (biometriaHematica == null)
            {
                return HttpNotFound();
            }
            return View(biometriaHematica);
        }

        // GET: BiometriaHematicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BiometriaHematicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Eritrocitos,Hemoglobina,Leucocitos,Linfocitos,Monocitos,Plaquetas")] BiometriaHematica biometriaHematica)
        {
            if (ModelState.IsValid)
            {
                db.BiometriaHematicas.Add(biometriaHematica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biometriaHematica);
        }

        // GET: BiometriaHematicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiometriaHematica biometriaHematica = db.BiometriaHematicas.Find(id);
            if (biometriaHematica == null)
            {
                return HttpNotFound();
            }
            return View(biometriaHematica);
        }

        // POST: BiometriaHematicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Eritrocitos,Hemoglobina,Leucocitos,Linfocitos,Monocitos,Plaquetas")] BiometriaHematica biometriaHematica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biometriaHematica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biometriaHematica);
        }

        // GET: BiometriaHematicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiometriaHematica biometriaHematica = db.BiometriaHematicas.Find(id);
            if (biometriaHematica == null)
            {
                return HttpNotFound();
            }
            return View(biometriaHematica);
        }

        // POST: BiometriaHematicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BiometriaHematica biometriaHematica = db.BiometriaHematicas.Find(id);
            db.BiometriaHematicas.Remove(biometriaHematica);
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
