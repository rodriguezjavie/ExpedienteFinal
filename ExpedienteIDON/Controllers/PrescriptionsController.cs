using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpedienteIDON.Controllers
{
    public class PrescriptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prescriptions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Prescriptions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Route("Prescriptions/Create/{doctorId}/{patientId}")]
        // GET: Prescriptions/Create
        public ActionResult Create(int doctorId, int patientId)
        {
            var doctor = db.Doctors.Single(d => d.Id == doctorId);
            var patient = db.Patients.Single(p => p.Id == patientId);
            var perscription = new Prescription
            {
                Doctor=doctor,
                Patient=patient
            };
            return View(perscription);
        }

        // POST: Prescriptions/Create
        [Route("Prescriptions/Create/{doctorId}/{patientId}")]
        [HttpPost]
        public ActionResult Create(Prescription prescription)
        {
            try
            {
                prescription.DateCreated = DateTime.Now;
                db.Prescriptions.Add(prescription);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prescriptions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prescriptions/Edit/5
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

        // GET: Prescriptions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prescriptions/Delete/5
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
