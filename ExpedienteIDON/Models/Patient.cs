﻿using System;
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
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Genero")]
        public Gender PatientGender { get; set; }

        [Phone]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Phone]
        [Display(Name = "Celular")]
        public string Cellphone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Photo { get; set; }
        [Display(Name = "Ocupación")]
        public string Ocupation { get; set; }
        [Display(Name = "Estudios")]
        public Studies PatientStudies { get; set; }
        [Display(Name = "Estado Civil")]
        public CivilStatus PatientCivilStatus { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }
    }
}