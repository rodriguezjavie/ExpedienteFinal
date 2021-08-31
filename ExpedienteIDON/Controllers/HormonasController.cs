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
    public class HormonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hormonas
        public ActionResult Index()
        {
            return View(db.Hormonas.ToList());
        }

        // GET: Hormonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hormonas hormonas = db.Hormonas.Find(id);
            if (hormonas == null)
            {
                return HttpNotFound();
            }
            return View(hormonas);
        }

        // GET: Hormonas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hormonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,LH,FSH,Prolactina,Progesterona,Estrogenos,Cortisol")] Hormonas hormonas)
        {
            if (ModelState.IsValid)
            {
                db.Hormonas.Add(hormonas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hormonas);
        }

        // GET: Hormonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hormonas hormonas = db.Hormonas.Find(id);
            if (hormonas == null)
            {
                return HttpNotFound();
            }
            return View(hormonas);
        }

        // POST: Hormonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,LH,FSH,Prolactina,Progesterona,Estrogenos,Cortisol")] Hormonas hormonas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hormonas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hormonas);
        }

        // GET: Hormonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hormonas hormonas = db.Hormonas.Find(id);
            if (hormonas == null)
            {
                return HttpNotFound();
            }
            return View(hormonas);
        }

        // POST: Hormonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hormonas hormonas = db.Hormonas.Find(id);
            db.Hormonas.Remove(hormonas);
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
