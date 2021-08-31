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
    public class VitalSignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VitalSigns
        public async Task<ActionResult> Index()
        {
            return View(await db.VitalSigns.ToListAsync());
        }

        // GET: VitalSigns/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = await db.VitalSigns.FindAsync(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
        }

        // GET: VitalSigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VitalSigns/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Size,Weight,IMC,TABD,TABI,FC,FR,Waist,Hip,OxygenSaturation")] VitalSigns vitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.VitalSigns.Add(vitalSigns);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vitalSigns);
        }

        // GET: VitalSigns/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = await db.VitalSigns.FindAsync(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
        }

        // POST: VitalSigns/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Size,Weight,IMC,TABD,TABI,FC,FR,Waist,Hip,OxygenSaturation")] VitalSigns vitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vitalSigns).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vitalSigns);
        }

        // GET: VitalSigns/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = await db.VitalSigns.FindAsync(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
        }

        // POST: VitalSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VitalSigns vitalSigns = await db.VitalSigns.FindAsync(id);
            db.VitalSigns.Remove(vitalSigns);
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
