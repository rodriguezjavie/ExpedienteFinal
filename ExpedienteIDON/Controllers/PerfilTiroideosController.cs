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
    public class PerfilTiroideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerfilTiroideos
        public async Task<ActionResult> Index()
        {
            return View(await db.PerfilTiroideos.ToListAsync());
        }

        // GET: PerfilTiroideos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilTiroideo perfilTiroideo = await db.PerfilTiroideos.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,TSH,T3Total,T3Libre,T4Total,T4Libre")] PerfilTiroideo perfilTiroideo)
        {
            if (ModelState.IsValid)
            {
                db.PerfilTiroideos.Add(perfilTiroideo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(perfilTiroideo);
        }

        // GET: PerfilTiroideos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilTiroideo perfilTiroideo = await db.PerfilTiroideos.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,TSH,T3Total,T3Libre,T4Total,T4Libre")] PerfilTiroideo perfilTiroideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilTiroideo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(perfilTiroideo);
        }

        // GET: PerfilTiroideos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilTiroideo perfilTiroideo = await db.PerfilTiroideos.FindAsync(id);
            if (perfilTiroideo == null)
            {
                return HttpNotFound();
            }
            return View(perfilTiroideo);
        }

        // POST: PerfilTiroideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PerfilTiroideo perfilTiroideo = await db.PerfilTiroideos.FindAsync(id);
            db.PerfilTiroideos.Remove(perfilTiroideo);
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
