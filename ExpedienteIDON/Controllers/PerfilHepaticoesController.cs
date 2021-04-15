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
    public class PerfilHepaticoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerfilHepaticoes
        public ActionResult Index()
        {
            return View(db.PerfilHepaticos.ToList());
        }

        // GET: PerfilHepaticoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilHepatico perfilHepatico = db.PerfilHepaticos.Find(id);
            if (perfilHepatico == null)
            {
                return HttpNotFound();
            }
            return View(perfilHepatico);
        }

        // GET: PerfilHepaticoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilHepaticoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,BilirrubinaTotal,BilirrubinaDirecta,BilirrubinaIndirecta,FosfatasaAlcalina,TGO,TGP,GGT")] PerfilHepatico perfilHepatico)
        {
            if (ModelState.IsValid)
            {
                db.PerfilHepaticos.Add(perfilHepatico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfilHepatico);
        }

        // GET: PerfilHepaticoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilHepatico perfilHepatico = db.PerfilHepaticos.Find(id);
            if (perfilHepatico == null)
            {
                return HttpNotFound();
            }
            return View(perfilHepatico);
        }

        // POST: PerfilHepaticoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,BilirrubinaTotal,BilirrubinaDirecta,BilirrubinaIndirecta,FosfatasaAlcalina,TGO,TGP,GGT")] PerfilHepatico perfilHepatico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilHepatico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfilHepatico);
        }

        // GET: PerfilHepaticoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilHepatico perfilHepatico = db.PerfilHepaticos.Find(id);
            if (perfilHepatico == null)
            {
                return HttpNotFound();
            }
            return View(perfilHepatico);
        }

        // POST: PerfilHepaticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerfilHepatico perfilHepatico = db.PerfilHepaticos.Find(id);
            db.PerfilHepaticos.Remove(perfilHepatico);
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
