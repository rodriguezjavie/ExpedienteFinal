using AutoMapper;
using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ExpedienteIDON.Controllers
{
    [Authorize(Roles = "Administrador,Doctor")]
    public class EvolutionNoteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: EvolutionNote
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
            var evolutionNote = await db.EvolutionNotes.ToListAsync();
            return View(evolutionNote);
        }

        // GET: EvolutionNote/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                    return HttpNotFound();
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

                var evolutionNote = await db.EvolutionNotes
                                        .Include(v => v.VitalSigns)
                                        .Include(b => b.BiometriaHematica)
                                        .Include(g => g.GeneralOrina)
                                        .Include(h => h.Hormonas)
                                        .Include(ph => ph.PerfilHepatico)
                                        .Include(pt => pt.PerfilTiroideo)
                                        .Include(q => q.QuimicaSanguinea)
                                        .Include(ol => ol.OtrosLabs)
                                        .Include(o => o.Others)
                                        .SingleOrDefaultAsync(e => e.Id == id);
                if (evolutionNote == null)
                    return HttpNotFound();
                var patient = await db.Patients.SingleAsync(p => p.Id == evolutionNote.PatientId);
                var doctor = await db.Doctors.SingleOrDefaultAsync(d => d.Id == evolutionNote.DoctorId);
                var prescription = await db.Prescriptions.SingleOrDefaultAsync(p => p.EvolutionNoteId == evolutionNote.Id);
                var user = await db.Users.SingleOrDefaultAsync(u => u.Id == evolutionNote.ApplicationUserId);

                if (prescription == null)
                {
                    var evolucionNoteVM = new EvolutionNoteVM
                    {
                        EvolutionNote = evolutionNote,
                        Patient = patient,
                        Doctor = doctor,
                        UserDataViewModel = new UserDataViewModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            Phone = user.Phone,
                            Cedula = user.Cedula
                        }
                    };
                    return View(evolucionNoteVM);
                }
                else
                {
                    var evolucionNoteVM = new EvolutionNoteVM
                    {
                        EvolutionNote = evolutionNote,
                        Patient = patient,
                        Doctor = doctor,
                        Prescription = prescription,
                        UserDataViewModel = new UserDataViewModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            Phone = user.Phone,
                            Cedula = user.Cedula
                        }

                    };
                    return View(evolucionNoteVM);
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }

        // GET: EvolutionNote/Create
        [Route("EvolutionNote/Create/{patientId}")]
        public async Task<ActionResult> Create(int? patientId)
        {
            try
            {
                if (patientId == null)
                    return HttpNotFound();
                if (User.IsInRole("Administrador"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                else if (User.IsInRole("Asistente"))
                    ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                else
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

                var patient = await db.Patients.SingleAsync(p => p.Id == patientId);
                if (patient == null)
                    return HttpNotFound();
                string currentUserId = User.Identity.GetUserId();
                var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);

                var EvolutionNoteVM = new EvolutionNoteVM
                {
                    UserDataViewModel = new UserDataViewModel
                    {
                        Name = user.Name,
                        LastName = user.LastName,
                        Phone = user.Phone,
                        Cedula = user.Cedula
                    },
                    Patient = patient,
                    EvolutionNote = new EvolutionNote
                    {
                        VitalSigns = new VitalSigns
                        {
                            OxygenSaturation = 98,
                            FC = 60,
                            FR = 20
                        ,
                            Glucose = 100,
                            Hip = 0.0d,
                            Size = 160,
                            TADiastBD = 60,
                            TADiastBI = 60
                        ,
                            TASistBD = 120,
                            TASistBI = 120,
                            Waist = 0.0d,
                            Weight = 0.0d
                        }
                    }
                };
                return View(EvolutionNoteVM);
            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

        // POST: EvolutionNote/Create
        [Route("EvolutionNote/Create/{patientId}")]
        [HttpPost]
        public async Task<ActionResult> Create(EvolutionNote evolutionNote, string Type, String idPatient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (User.IsInRole("Administrador"))
                        ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                    else if (User.IsInRole("Asistente"))
                        ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                    else
                        ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

                    evolutionNote.CreatedDate = DateTime.Now;
                    evolutionNote.DoctorId = 1;
                    evolutionNote.PatientId = int.Parse(idPatient);
                    evolutionNote.ApplicationUserId = User.Identity.GetUserId();
                    var imc = (evolutionNote.VitalSigns.Weight / (evolutionNote.VitalSigns.Size * evolutionNote.VitalSigns.Size)) * 10000;
                    evolutionNote.VitalSigns.IMC = imc;
                    db.EvolutionNotes.Add(evolutionNote);
                    db.SaveChanges();
                    if (Type == "Guardar sin Receta")
                        return RedirectToAction("Details", "EvolutionNote", new { Id = evolutionNote.Id });
                    else
                        return RedirectToAction("Create", "EvolNotePrescription", new { patientId = evolutionNote.PatientId, evolutionNoteId = evolutionNote.Id });

                }
                else
                {
                    string currentUserId = User.Identity.GetUserId();
                    var user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                    var patientId = int.Parse(idPatient);
                    var patient = await db.Patients.SingleAsync(p => p.Id == patientId);

                    var EvolutionNoteVM = new EvolutionNoteVM
                    {
                        UserDataViewModel = new UserDataViewModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            Phone = user.Phone,
                            Cedula = user.Cedula
                        },
                        EvolutionNote = evolutionNote,
                        Patient = patient
                    };

                    if (User.IsInRole("Administrador"))
                        ViewBag.Layout = "~/Views/Shared/_LayoutAdministrador.cshtml";
                    else if (User.IsInRole("Asistente"))
                        ViewBag.Layout = "~/Views/Shared/_LayoutAsistente.cshtml";
                    else
                        ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

                    return View(EvolutionNoteVM);
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

        // GET: EvolutionNote/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                    return HttpNotFound();
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
                var evolutionNote = await db.EvolutionNotes
                                        .Include(v => v.VitalSigns)
                                        .Include(b => b.BiometriaHematica)
                                        .Include(g => g.GeneralOrina)
                                        .Include(h => h.Hormonas)
                                        .Include(ph => ph.PerfilHepatico)
                                        .Include(pt => pt.PerfilTiroideo)
                                        .Include(q => q.QuimicaSanguinea)
                                        .Include(ol => ol.OtrosLabs)
                                        .Include(o => o.Others)
                                        .SingleOrDefaultAsync(e => e.Id == id);
                if (evolutionNote == null)
                    return HttpNotFound();
                var patient = await db.Patients.SingleAsync(p => p.Id == evolutionNote.PatientId);
                var doctor = await db.Doctors.SingleOrDefaultAsync(d => d.Id == evolutionNote.DoctorId);
                var prescription = await db.Prescriptions.SingleOrDefaultAsync(p => p.EvolutionNoteId == evolutionNote.Id);
                var user = await db.Users.SingleOrDefaultAsync(u => u.Id == evolutionNote.ApplicationUserId);

                if (prescription == null)
                {
                    var evolucionNoteVM = new EvolutionNoteVM
                    {
                        EvolutionNote = evolutionNote,
                        Patient = patient,
                        Doctor = doctor,
                        UserDataViewModel = new UserDataViewModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            Phone = user.Phone,
                            Cedula = user.Cedula
                        }
                        //Prescription = await db.Prescriptions.SingleAsync(p => p.EvolutionNoteId == evolutionNote.Id),
                    };
                    return View(evolucionNoteVM);
                }
                else
                {
                    var evolucionNoteVM = new EvolutionNoteVM
                    {
                        EvolutionNote = evolutionNote,
                        Patient = patient,
                        Doctor = doctor,
                        Prescription = prescription,
                        UserDataViewModel = new UserDataViewModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            Phone = user.Phone,
                            Cedula = user.Cedula
                        }
                    };
                    return View(evolucionNoteVM);
                }

            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

        // POST: EvolutionNote/Edit/5
        [HttpPost]
        public ActionResult Edit(EvolutionNote evolutionNote)
        {
            try
            {
                var patient = db.Patients.SingleOrDefault(p => p.Id == evolutionNote.PatientId);
                var doctor = db.Doctors.SingleOrDefault(d => d.Id == evolutionNote.DoctorId);

                if (ModelState.IsValid)
                {
                    var evolInDb = db.EvolutionNotes.Include(v => v.VitalSigns)
                                            .Include(b => b.BiometriaHematica)
                                            .Include(g => g.GeneralOrina)
                                            .Include(h => h.Hormonas)
                                            .Include(ph => ph.PerfilHepatico)
                                            .Include(pt => pt.PerfilTiroideo)
                                            .Include(q => q.QuimicaSanguinea)
                                            .Include(ol => ol.OtrosLabs)
                                            .Include(o => o.Others).SingleOrDefault(e => e.Id == evolutionNote.Id);
                    evolutionNote.Patient = patient;
                    evolutionNote.Doctor = doctor;
                    var imc = (evolutionNote.VitalSigns.Weight / (evolutionNote.VitalSigns.Size * evolutionNote.VitalSigns.Size)) * 10000;
                    evolutionNote.VitalSigns.IMC = imc;
                    evolutionNote.BiometriaHematica.Id = (int)evolutionNote.BiometriaHematicaId;
                    var othersInDb = db.Others.SingleOrDefault(o => o.Id == evolInDb.Others.Id);
                    var vitalSignsInDb = db.VitalSigns.SingleOrDefault(v => v.Id == evolutionNote.VitalSignsId);
                    var biomInDb = db.BiometriaHematicas.SingleOrDefault(b => b.Id == evolutionNote.BiometriaHematicaId);
                    var hormInDb = db.Hormonas.SingleOrDefault(b => b.Id == evolutionNote.HormonasId);
                    var quimInDb = db.QuimicaSanguineas.SingleOrDefault(b => b.Id == evolutionNote.QuimicaSanguineaId);
                    var perfHepInDb = db.PerfilHepaticos.SingleOrDefault(b => b.Id == evolutionNote.PerfilHepaticoId);
                    var perfTirInDb = db.PerfilTiroideos.SingleOrDefault(b => b.Id == evolutionNote.PerfilTiroideoId);
                    var genOrInDb = db.GeneralOrinas.SingleOrDefault(b => b.Id == evolutionNote.GeneralOrinaId);
                    var otroslabInDb = db.OtrosLabs.SingleOrDefault(b => b.Id == evolutionNote.OtrosLabsId);

                    var others = evolutionNote.Others;

                    var vitalSigns = evolutionNote.VitalSigns;
                    var biom = evolutionNote.BiometriaHematica;
                    var horm = evolutionNote.Hormonas;
                    var quim = evolutionNote.QuimicaSanguinea;
                    var perfHep = evolutionNote.PerfilHepatico;
                    var perfTir = evolutionNote.PerfilTiroideo;
                    var genOr = evolutionNote.GeneralOrina;
                    var otroslab = evolutionNote.OtrosLabs;

                    Mapper.Map(others, othersInDb);
                    Mapper.Map(vitalSigns, vitalSignsInDb);
                    Mapper.Map(biom, biomInDb);
                    Mapper.Map(genOr, genOrInDb);
                    Mapper.Map(horm, hormInDb);
                    Mapper.Map(quim, quimInDb);
                    Mapper.Map(perfHep, perfHepInDb);
                    Mapper.Map(perfTir, perfTirInDb);
                    Mapper.Map(otroslab, otroslabInDb);

                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = evolutionNote.Id });


                }
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var user = db.Users.SingleOrDefault(u => u.Id == evolutionNote.ApplicationUserId);

                var evolucionNoteVM = new EvolutionNoteVM
                {
                    EvolutionNote = evolutionNote,
                    Patient = patient,
                    Doctor = doctor,
                    UserDataViewModel = new UserDataViewModel
                    {
                        Name = user.Name,
                        LastName = user.LastName,
                        Phone = user.Phone,
                        Cedula = user.Cedula
                    }
                };
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
                return View(evolucionNoteVM);

            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }
    }
}