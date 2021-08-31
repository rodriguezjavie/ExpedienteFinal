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
    public class GeneralOrinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GeneralOrinas
        public ActionResult Index()
        {
            return View(db.GeneralOrinas.ToList());
        }

        // GET: GeneralOrinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralOrina generalOrina = db.GeneralOrinas.Find(id);
            if (generalOrina == null)
            {
                return HttpNotFound();
            }
            return View(generalOrina);
        }

        // GET: GeneralOrinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralOrinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Aspecto,Densidad,Ph,Glucosa,Proteinas,Sangre,Cetonas,Nitritos,Esterasa,Leucocitos,Bacterias")] GeneralOrina generalOrina)
        {
            if (ModelState.IsValid)
            {
                db.GeneralOrinas.Add(generalOrina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(generalOrina);
        }

        // GET: GeneralOrinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralOrina generalOrina = db.GeneralOrinas.Find(id);
            if (generalOrina == null)
            {
                return HttpNotFound();
            }
            return View(generalOrina);
        }

        // POST: GeneralOrinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Aspecto,Densidad,Ph,Glucosa,Proteinas,Sangre,Cetonas,Nitritos,Esterasa,Leucocitos,Bacterias")] GeneralOrina generalOrina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalOrina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generalOrina);
        }

        // GET: GeneralOrinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralOrina generalOrina = db.GeneralOrinas.Find(id);
            if (generalOrina == null)
            {
                return HttpNotFound();
            }
            return View(generalOrina);
        }

        // POST: GeneralOrinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralOrina generalOrina = db.GeneralOrinas.Find(id);
            db.GeneralOrinas.Remove(generalOrina);
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
