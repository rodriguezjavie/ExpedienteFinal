using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpedienteIDON.Controllers
{
    public class PrescriptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Prescription
        public ActionResult Index()
        {
            var list = db.Prescriptions.ToList();
            return View(list);
        }

        // GET: Prescription/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Prescription/Create
        [Route("Prescription/Create/{doctorId}/{patientId}")]
        public ActionResult Create( int doctorId, int patientId)
        {
            var doctor = db.Doctors.SingleOrDefault(d => d.Id == doctorId);
            var patient = db.Patients.SingleOrDefault(p => p.Id == patientId);
            var prescriptVM = new PrescriptionViewModel
            {
                Doctor = doctor,
                Patient = patient,
                MedicinesPrescription = new MedicinesPrescription { Prescription=new Prescription { DoctorId=doctorId, PatientId=patientId} }
            };
           
            return View(prescriptVM);
        }

        // POST: Prescription/Create
        [HttpPost]
        [Route("Prescription/Create/{doctorId}/{patientId}")]
        public ActionResult Create(MedicinesPrescription medicinesPrescription, Prescription prescription)
        {
            try
            {
                prescription.CratedDate = DateTime.Now;
                medicinesPrescription.Prescription = prescription;
                db.Prescriptions.Add(prescription);
                db.MedicinesPrescriptions.Add(medicinesPrescription);
                db.SaveChanges();
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prescription/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prescription/Edit/5
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

        // GET: Prescription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prescription/Delete/5
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
