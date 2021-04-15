using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class OtrosLabs
    {
        public int Id { get; set; }
        [Display(Name ="Fecha")]
        public DateTime? Date { get; set; }
        [Display(Name = "Vitamina D")]
        public double? VitaminaD { get; set; }
        [Display(Name = "Calcio")]
        public double? Calcio { get; set; }
        [Display(Name = "Fosforo")]
        public double? Fosforo { get; set; }
        [Display(Name = "Magnesio")]
        public double? Magnesio { get; set; }
        [Display(Name = "Sodio")]
        public double? Sodio { get; set; }
        [Display(Name = "Potasio")]
        public double? Potasio { get; set; }
        [Display(Name = "Cloro")]
        public double? Cloro { get; set; }
        [Display(Name = "Hemoglobina Glugosilada")]
        public double? HemoglobinaGlugosilada { get; set; }

    }
}