using ExpedienteIDON.Models;
using ExpedienteIDON.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpedienteIDON.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UserRoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserRole
        public ActionResult Index()
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
            var listOfUsers = (from u in db.Users
                               let query = (from ur in db.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in db.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                         .ToList();
            return View(listOfUsers);
        }
      
    }
}