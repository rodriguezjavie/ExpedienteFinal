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
    public class OthersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Others
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View(await db.Others.ToListAsync());
        }

        // GET: Others/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Others others = await db.Others.FindAsync(id);
            if (others == null)
            {
                return HttpNotFound();
            }
            return View(others);
        }

        // GET: Others/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View();
        }

        // POST: Others/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Reason,Diagnosis,Prognosis,Notes")] Others others)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            if (ModelState.IsValid)
            {
                db.Others.Add(others);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(others);
        }

        // GET: Others/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Others others = await db.Others.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Reason,Diagnosis,Prognosis")] Others others)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            if (ModelState.IsValid)
            {
                db.Entry(others).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(others);
        }

        // GET: Others/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Others others = await db.Others.FindAsync(id);
            if (others == null)
            {
                return HttpNotFound();
            }
            return View(others);
        }

        // POST: Others/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
            }
            else
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            Others others = await db.Others.FindAsync(id);
            db.Others.Remove(others);
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
