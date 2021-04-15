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
    public class OthersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Others
        public ActionResult Index()
        {
            return View(db.Others.ToList());
        }

        // GET: Others/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Others others = db.Others.Find(id);
            if (others == null)
            {
                return HttpNotFound();
            }
            return View(others);
        }

        // GET: Others/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Others/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Reason,Diagnosis,Prognosis")] Others others)
        {
            if (ModelState.IsValid)
            {
                db.Others.Add(others);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(others);
        }

        // GET: Others/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Others others = db.Others.Find(id);
            if (others == null)
            {
                return HttpNotFound();
            }
            return View(others);
        }

        // POST: Others/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Reason,Diagnosis,Prognosis")] Others others)
        {
            if (ModelState.IsValid)
            {
                db.Entry(others).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(others);
        }

        // GET: Others/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Others others = db.Others.Find(id);
            if (others == null)
            {
                return HttpNotFound();
            }
            return View(others);
        }

        // POST: Others/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Others others = db.Others.Find(id);
            db.Others.Remove(others);
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
