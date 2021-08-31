using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.ViewModels
{
    public class UserRoleVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string  Phone { get; set; }
        public string Cedula { get; set; }
    }
}