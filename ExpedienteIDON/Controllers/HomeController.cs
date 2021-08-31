using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpedienteIDON.Controllers
{
    [Authorize(Roles = "Administrador,Doctor,Asistente")]
    public class HomeController : Controller
    {
        public ActionResult Index()
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
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}