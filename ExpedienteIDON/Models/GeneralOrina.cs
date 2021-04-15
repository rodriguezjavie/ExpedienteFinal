using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class GeneralOrina
    {
        public int Id { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }
        [Display(Name = "Aspecto")]
        public string Aspecto { get; set; }
        [Display(Name = "Densidad")]
        public string Densidad { get; set; }
        [Display(Name = "Ph")]
        public double? Ph { get; set; }
        [Display(Name = "Glucosa")]
        public double? Glucosa { get; set; }
        [Display(Name = "Proteinas")]
        public string Proteinas { get; set; }
        [Display(Name = "Sangre")]
        public string Sangre { get; set; }
        [Display(Name = "Cetonas")]
        public string Cetonas { get; set; }
        [Display(Name = "Nitritos")]
        public string Nitritos { get; set; }
        [Display(Name = "Esterasa")]
        public string Esterasa { get; set; }
        [Display(Name = "Leucocitos")]
        public string Leucocitos { get; set; }
        [Display(Name = "Bacterias")]
        public string Bacterias { get; set; }
    }
}