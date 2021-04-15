using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Hormonas
    {
        public int Id { get; set; }
        [Display(Name ="Fecha")]
        public DateTime? Date { get; set; }
        [Display(Name = "LH")]
        public double? LH { get; set; }
        [Display(Name = "FSH")]
        public double? FSH { get; set; }
        [Display(Name = "Prolactina")]
        public double? Prolactina { get; set; }
        [Display(Name = "Progesterona")]
        public double? Progesterona { get; set; }
        [Display(Name = "Estrogenos")]
        public double? Estrogenos { get; set; }
        [Display(Name = "Cortisol")]
        public double? Cortisol { get; set; }



    }
}