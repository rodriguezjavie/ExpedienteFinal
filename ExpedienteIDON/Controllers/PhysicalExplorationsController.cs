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
    public class PhysicalExplorationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PhysicalExplorations
        public ActionResult Index()
        {
            return View(db.PhysicalExplorations.ToList());
        }

        // GET: PhysicalExplorations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalExploration physicalExploration = db.PhysicalExplorations.Find(id);
            if (physicalExploration == null)
            {
                return HttpNotFound();
            }
            return View(physicalExploration);
        }

        // GET: PhysicalExplorations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhysicalExplorations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Habitus,Cabeza,CuelloBocio,SoploCarotideo,CuelloAcantosis,AcanosisAfectacion,CuelloComments,ToraxComments,AbdomenComments,ToracicosSimetricos,ToracicosSensibilidad,ToracicosFuerza,ToracicosSinovitis,ToracicosROT,ToracicosComments,PelvicoSimetrico,PelvicoFuerza,PelvicoSensibilidad,PelvicoVarices,PelvicoROTAquileo,PelvicoOnicomicosis,PelvicoPulsos,PelvicoEdema,PelvicoOtros,Genitales")] PhysicalExploration physicalExploration)
        {
            if (ModelState.IsValid)
            {
                db.PhysicalExplorations.Add(physicalExploration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(physicalExploration);
        }

        // GET: PhysicalExplorations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalExploration physicalExploration = db.PhysicalExplorations.Find(id);
            if (physicalExploration == null)
            {
                return HttpNotFound();
            }
            return View(physicalExploration);
        }

        // POST: PhysicalExplorations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Habitus,Cabeza,CuelloBocio,SoploCarotideo,CuelloAcantosis,AcanosisAfectacion,CuelloComments,ToraxComments,AbdomenComments,ToracicosSimetricos,ToracicosSensibilidad,ToracicosFuerza,ToracicosSinovitis,ToracicosROT,ToracicosComments,PelvicoSimetrico,PelvicoFuerza,PelvicoSensibilidad,PelvicoVarices,PelvicoROTAquileo,PelvicoOnicomicosis,PelvicoPulsos,PelvicoEdema,PelvicoOtros,Genitales")] PhysicalExploration physicalExploration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(physicalExploration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(physicalExploration);
        }

        // GET: PhysicalExplorations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalExploration physicalExploration = db.PhysicalExplorations.Find(id);
            if (physicalExploration == null)
            {
                return HttpNotFound();
            }
            return View(physicalExploration);
        }

        // POST: PhysicalExplorations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhysicalExploration physicalExploration = db.PhysicalExplorations.Find(id);
            db.PhysicalExplorations.Remove(physicalExploration);
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
