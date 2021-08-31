using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PerfilTiroideo
    {
        public int Id { get; set; }
        [Display(Name ="Fecha")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [Display(Name = "TSH")]
        public double? TSH { get; set; }
        [Display(Name = "T3 Total")]
        public double? T3Total { get; set; }
        [Display(Name = "T3 Libre")]
        public double? T3Libre { get; set; }
        [Display(Name = "T4 Total")]
        public double? T4Total { get; set; }
        [Display(Name = "T4 Libre")]
        public double? T4Libre { get; set; }


    }
}