using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Display(Name = "Nombres")]
        public string Name { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Celular")]
        public string Cellphone { get; set; }
        [Display(Name = "Telefono")]
        public string Phone { get; set; }
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        [Display(Name = "Genero")]
        public Gender DoctorGender { get; set; }
    }
}