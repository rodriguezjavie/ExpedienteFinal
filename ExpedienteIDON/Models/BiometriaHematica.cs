using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class BiometriaHematica
    {
        public int Id { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }
        [Display(Name = "Eritrocitos")]
        public double? Eritrocitos { get; set; }
        [Display(Name = "Hemoglobina")]
        public double? Hemoglobina { get; set; }
        [Display(Name = "Leucocitos")]
        public double? Leucocitos { get; set; }
        [Display(Name = "Linfocitos")]
        public double? Linfocitos { get; set; }
        [Display(Name = "Monocitos")]
        public double? Monocitos { get; set; }
        [Display(Name = "Plaquetas")]
        public double? Plaquetas { get; set; }

    }
}