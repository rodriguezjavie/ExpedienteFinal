using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var evolutionNote = db.EvolutionNotes
                .Include(v=>v.VitalSigns)
                .Include(b=>b.BiometriaHematica)
                .Include(g=>g.GeneralOrina)
                .Include(h=>h.Hormonas)
                .Include(ph=>ph.PerfilHepatico)
                .Include(pt=>pt.PerfilTiroideo)
                .Include(q=>q.QuimicaSanguinea)
                .Include(ol=>ol.OtrosLabs)
                .Include(o=>o.Others)
                .SingleOrDefault(e => e.Id == id);
            var patient = db.Patients.Single(p => p.Id == evolutionNote.PatientId);
            var doctor = db.Doctors.Single(d => d.Id == evolutionNote.DoctorId);
            var evolucionNoteVM = new EvolutionNoteVM
            {
                EvolutionNote = evolutionNote,
                Patient = patient,
                Doctor = doctor
            };



            return View(evolucionNoteVM);
        }

        // GET: EvolutionNote/Create
        [Route("EvolutionNote/Create/{doctorId}/{patientId}")]
        public ActionResult Create(int doctorId, int patientId)
        {
            var patient = db.Patients.Single(p => p.Id == patientId);
            var doctor = db.Doctors.Single(d => d.Id == doctorId);
            var evolutionNote = new EvolutionNote
            {
                Patient = patient,
                Doctor = doctor
            };



            return View(evolutionNote);
        }

        // POST: EvolutionNote/Create
       
        [Route("EvolutionNote/Create/{doctorId}/{patientId}")]
        [HttpPost]
        public ActionResult Create(EvolutionNote evolutionNote, string Type)
        {
            try

            {
                evolutionNote.CreatedDate = DateTime.Now;

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
                if (Type == "Sin Receta")
                {
                   

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Create", "EvolNotePrescription",new { doctorId =evolutionNote.DoctorId, patientId =evolutionNote.PatientId, evolutionNoteId =evolutionNote.Id});
                }
                
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