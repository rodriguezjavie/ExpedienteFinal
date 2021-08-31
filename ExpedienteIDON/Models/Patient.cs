using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre(s)")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Género")]
        public Gender PatientGender { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Phone]
        [Display(Name = "Celular")]
        public string Cellphone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Subir Imagen")]
        public string Photo { get; set; }
        [Display(Name = "Ocupación")]
        public string Ocupation { get; set; }
        [Display(Name = "Estudios")]
        public Studies PatientStudies { get; set; }
        [Display(Name = "Estado Civil")]
        public CivilStatus PatientCivilStatus { get; set; }
        [Display(Name = "Calle y Numero")]
        public string StreetAndNumber { get; set; }
        [Display(Name = "Colonia")]
        public string Suburb { get; set; }
        [Display(Name = "Ciudad")]
        public string City { get; set; }
        [Display(Name = "Codigo Postal")]
        public string ZipCode { get; set; }
        [Display(Name="Estado del Paciente")]
        public ObjectStatus Status { get; set; }

    }
}