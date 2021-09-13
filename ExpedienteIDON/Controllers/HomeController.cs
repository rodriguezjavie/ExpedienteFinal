using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace ExpedienteIDON.Controllers
{
    [Authorize(Roles = "Administrador,Doctor,Asistente")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Administrador"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
            }
            else if (User.IsInRole("Asistente"))
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                return RedirectToAction("Index", "Patients");
            }
            else
            {
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            }
                

            var patient = await db.Patients.OrderByDescending(p => p.Created).Take(10).ToListAsync();
            List<PatientRecordProfile> patientList = new List<PatientRecordProfile>();
            foreach (var item in patient)
            {
                var record = await db.MedicalRecords.Where(a => a.PatientId == item.Id).FirstOrDefaultAsync();
                var userDataViewModel = new UserDataViewModel();
                if (record == null)
                {
                    userDataViewModel.Name = "";
                    userDataViewModel.LastName = "";
                }
                else
                {
                    var user = await db.Users.Where(u => u.Id == record.ApplicationUserId).FirstOrDefaultAsync();
                    userDataViewModel.Name = user.Name;
                    userDataViewModel.LastName = user.LastName;
                }
                
                var patientRecordProfile = new PatientRecordProfile
                {
                    Patient = item,
                    UserDataViewModel = userDataViewModel
                };
                if (record == null)
                {
                    patientRecordProfile.Record = false;
                }
                else
                {
                    patientRecordProfile.Record = true;
                }

                var relativePath = "~/Content/UploadedFiles/" + patientRecordProfile.Patient.Photo;
                var absolutePath = HttpContext.Server.MapPath(relativePath);
                if (!System.IO.File.Exists(absolutePath))
                {
                    patientRecordProfile.Patient.Photo = "patient1.jpg";
                }
                patientList.Add(patientRecordProfile);
            }
            return View(patientList);
        }
    }
}