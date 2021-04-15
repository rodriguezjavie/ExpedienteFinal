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
    public class PerfilTiroideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerfilTiroideos
        public ActionResult Index()
        {
            return View(db.PerfilTiroideos.ToList());
        }

        // GET: PerfilTiroideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilTiroideo perfilTiroideo = db.PerfilTiroideos.Find(id);
            if (perfilTiroideo == null)
            {
                return HttpNotFound();
            }
            return View(perfilTiroideo);
        }

        // GET: PerfilTiroideos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilTiroideos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,TSH,T3Total,T3Libre,T4Total,T4Libre")] PerfilTiroideo perfilTiroideo)
        {
            if (ModelState.IsValid)
            {
                db.PerfilTiroideos.Add(perfilTiroideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfilTiroideo);
        }

        // GET: PerfilTiroideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilTiroideo perfilTiroideo = db.PerfilTiroideos.Find(id);
            if (perfilTiroideo == null)
            {
                return HttpNotFound();
            }
            return View(perfilTiroideo);
        }

        // POST: PerfilTiroideos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,TSH,T3Total,T3Libre,T4Total,T4Libre")] PerfilTiroideo perfilTiroideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilTiroideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfilTiroideo);
        }

        // GET: PerfilTiroideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilTiroideo perfilTiroideo = db.PerfilTiroideos.Find(id);
            if (perfilTiroideo == null)
            {
                return HttpNotFound();
            }
            return View(perfilTiroideo);
        }

        // POST: PerfilTiroideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerfilTiroideo perfilTiroideo = db.PerfilTiroideos.Find(id);
            db.PerfilTiroideos.Remove(perfilTiroideo);
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
