using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpedienteIDON.Controllers
{
    public class EvolutionNoteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: EvolutionNote
        public ActionResult Index()
        {
            var evolutionNote = db.EvolutionNotes.ToList();
            return View(evolutionNote);
        }

        // GET: EvolutionNote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EvolutionNote/Create
        public ActionResult Create(int id)
        {
            var patient = db.Patients.Single(p => p.Id == id);
            var evolutionNote = new EvolutionNote
            {
                Patient = patient,
            };
           


            return View(evolutionNote);
        }

        // POST: EvolutionNote/Create
        [HttpPost]
        public ActionResult Create(EvolutionNote evolutionNote, Patient patient)
        {
            try

            {

                evolutionNote.PatientId = patient.Id;
                if (evolutionNote.BiometriaHematica.Date == null)
                    evolutionNote.BiometriaHematica = null;
                if (evolutionNote.GeneralOrina.Date == null)
                    evolutionNote.GeneralOrina = null;
                if (evolutionNote.Hormonas.Date == null)
                    evolutionNote.Hormonas = null;
                if (evolutionNote.OtrosLabs.Date == null)
                    evolutionNote.OtrosLabs = null;
                if (evolutionNote.PerfilHepatico.Date == null)
                    evolutionNote.PerfilHepatico = null;
                if (evolutionNote.PerfilTiroideo.Date == null)
                    evolutionNote.PerfilTiroideo = null;
                if (evolutionNote.QuimicaSanguinea.Date == null)
                    evolutionNote.QuimicaSanguinea = null;


                db.EvolutionNotes.Add(evolutionNote);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EvolutionNote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EvolutionNote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EvolutionNote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EvolutionNote/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}