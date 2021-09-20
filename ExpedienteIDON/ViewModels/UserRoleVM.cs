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
        [Display(Name = "Rol")]
        public string RoleName { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string  Phone { get; set; }
        public string Cedula { get; set; }
    }
}