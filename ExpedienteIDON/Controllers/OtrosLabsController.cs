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
    public class OtrosLabsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OtrosLabs
        public async Task<ActionResult> Index()
        {
            return View(await db.OtrosLabs.ToListAsync());
        }

        // GET: OtrosLabs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtrosLabs otrosLabs = await db.OtrosLabs.FindAsync(id);
            if (otrosLabs == null)
            {
                return HttpNotFound();
            }
            return View(otrosLabs);
        }

        // GET: OtrosLabs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtrosLabs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,VitaminaD,Calcio,Fosforo,Magnesio,Sodio,Potasio,Cloro,HemoglobinaGlugosilada")] OtrosLabs otrosLabs)
        {
            if (ModelState.IsValid)
            {
                db.OtrosLabs.Add(otrosLabs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(otrosLabs);
        }

        // GET: OtrosLabs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtrosLabs otrosLabs = await db.OtrosLabs.FindAsync(id);
            if (otrosLabs == null)
            {
                return HttpNotFound();
            }
            return View(otrosLabs);
        }

        // POST: OtrosLabs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,VitaminaD,Calcio,Fosforo,Magnesio,Sodio,Potasio,Cloro,HemoglobinaGlugosilada")] OtrosLabs otrosLabs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otrosLabs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(otrosLabs);
        }

        // GET: OtrosLabs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtrosLabs otrosLabs = await db.OtrosLabs.FindAsync(id);
            if (otrosLabs == null)
            {
                return HttpNotFound();
            }
            return View(otrosLabs);
        }

        // POST: OtrosLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OtrosLabs otrosLabs = await db.OtrosLabs.FindAsync(id);
            db.OtrosLabs.Remove(otrosLabs);
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
