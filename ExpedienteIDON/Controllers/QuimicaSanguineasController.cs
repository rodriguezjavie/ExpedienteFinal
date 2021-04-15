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
    public class QuimicaSanguineasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuimicaSanguineas
        public ActionResult Index()
        {
            return View(db.QuimicaSanguineas.ToList());
        }

        // GET: QuimicaSanguineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuimicaSanguinea quimicaSanguinea = db.QuimicaSanguineas.Find(id);
            if (quimicaSanguinea == null)
            {
                return HttpNotFound();
            }
            return View(quimicaSanguinea);
        }

        // GET: QuimicaSanguineas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuimicaSanguineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Glucosa,Creatinina,AcidoUrico,Colesterol,Trigliceridos,HDL,LDL")] QuimicaSanguinea quimicaSanguinea)
        {
            if (ModelState.IsValid)
            {
                db.QuimicaSanguineas.Add(quimicaSanguinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quimicaSanguinea);
        }

        // GET: QuimicaSanguineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuimicaSanguinea quimicaSanguinea = db.QuimicaSanguineas.Find(id);
            if (quimicaSanguinea == null)
            {
                return HttpNotFound();
            }
            return View(quimicaSanguinea);
        }

        // POST: QuimicaSanguineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Glucosa,Creatinina,AcidoUrico,Colesterol,Trigliceridos,HDL,LDL")] QuimicaSanguinea quimicaSanguinea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quimicaSanguinea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quimicaSanguinea);
        }

        // GET: QuimicaSanguineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuimicaSanguinea quimicaSanguinea = db.QuimicaSanguineas.Find(id);
            if (quimicaSanguinea == null)
            {
                return HttpNotFound();
            }
            return View(quimicaSanguinea);
        }

        // POST: QuimicaSanguineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuimicaSanguinea quimicaSanguinea = db.QuimicaSanguineas.Find(id);
            db.QuimicaSanguineas.Remove(quimicaSanguinea);
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
