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
    public class PerfilHepaticoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerfilHepaticoes
        public async Task<ActionResult> Index()
        {
            return View(await db.PerfilHepaticos.ToListAsync());
        }

        // GET: PerfilHepaticoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilHepatico perfilHepatico = await db.PerfilHepaticos.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,BilirrubinaTotal,BilirrubinaDirecta,BilirrubinaIndirecta,FosfatasaAlcalina,TGO,TGP,GGT")] PerfilHepatico perfilHepatico)
        {
            if (ModelState.IsValid)
            {
                db.PerfilHepaticos.Add(perfilHepatico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(perfilHepatico);
        }

        // GET: PerfilHepaticoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilHepatico perfilHepatico = await db.PerfilHepaticos.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,BilirrubinaTotal,BilirrubinaDirecta,BilirrubinaIndirecta,FosfatasaAlcalina,TGO,TGP,GGT")] PerfilHepatico perfilHepatico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilHepatico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(perfilHepatico);
        }

        // GET: PerfilHepaticoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilHepatico perfilHepatico = await db.PerfilHepaticos.FindAsync(id);
            if (perfilHepatico == null)
            {
                return HttpNotFound();
            }
            return View(perfilHepatico);
        }

        // POST: PerfilHepaticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PerfilHepatico perfilHepatico = await db.PerfilHepaticos.FindAsync(id);
            db.PerfilHepaticos.Remove(perfilHepatico);
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
