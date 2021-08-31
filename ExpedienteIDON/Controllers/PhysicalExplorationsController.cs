using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExpedienteIDON.Models;

namespace ExpedienteIDON.Controllers
{
    [Authorize(Roles = "Administrador,Doctor")]
    public class PhysicalExplorationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PhysicalExplorations
        public async Task<ActionResult> Index()
        {
            return View(await db.PhysicalExplorations.ToListAsync());
        }

        // GET: PhysicalExplorations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalExploration physicalExploration = await db.PhysicalExplorations.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Habitus,Cabeza,CuelloBocio,SoploCarotideo,CuelloAcantosis,AcanosisAfectacion,CuelloComments,ToraxComments,AbdomenComments,ToracicosSimetricos,ToracicosSensibilidad,ToracicosFuerza,ToracicosSinovitis,ToracicosROT,ToracicosComments,PelvicoSimetrico,PelvicoFuerza,PelvicoSensibilidad,PelvicoVarices,PelvicoROTAquileo,PelvicoOnicomicosis,PelvicoPulsos,PelvicoEdema,PelvicoOtros,Genitales")] PhysicalExploration physicalExploration)
        {
            if (ModelState.IsValid)
            {
                db.PhysicalExplorations.Add(physicalExploration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(physicalExploration);
        }

        // GET: PhysicalExplorations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalExploration physicalExploration = await db.PhysicalExplorations.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Habitus,Cabeza,CuelloBocio,SoploCarotideo,CuelloAcantosis,AcanosisAfectacion,CuelloComments,ToraxComments,AbdomenComments,ToracicosSimetricos,ToracicosSensibilidad,ToracicosFuerza,ToracicosSinovitis,ToracicosROT,ToracicosComments,PelvicoSimetrico,PelvicoFuerza,PelvicoSensibilidad,PelvicoVarices,PelvicoROTAquileo,PelvicoOnicomicosis,PelvicoPulsos,PelvicoEdema,PelvicoOtros,Genitales")] PhysicalExploration physicalExploration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(physicalExploration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(physicalExploration);
        }

        // GET: PhysicalExplorations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalExploration physicalExploration = await db.PhysicalExplorations.FindAsync(id);
            if (physicalExploration == null)
            {
                return HttpNotFound();
            }
            return View(physicalExploration);
        }

        // POST: PhysicalExplorations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PhysicalExploration physicalExploration = await db.PhysicalExplorations.FindAsync(id);
            db.PhysicalExplorations.Remove(physicalExploration);
            await db.SaveChangesAsync();
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
