using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class QuimicaSanguinea
    {
        public int Id { get; set; }
        [Display(Name ="Fecha")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [Display(Name = "Glucosa")]
        public double? Glucosa { get; set; }
        [Display(Name = "Creatinina")]
        public double? Creatinina { get; set; }
        [Display(Name = "Ácido Úrico")]
        public double? AcidoUrico { get; set; }
        [Display(Name = "Colesterol")]
        public double? Colesterol { get; set; }
        [Display(Name = "Trigliceridos")]
        public double? Trigliceridos { get; set; }
        [Display(Name = "HDL")]
        public double? HDL { get; set; }
        [Display(Name = "LDL")]
        public double? LDL { get; set; }

    }
}