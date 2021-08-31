using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PerfilHepatico
    {
        public int Id { get; set; }
        [Display(Name ="Fecha")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [Display(Name = "Bilirrubina Total")]
        public double? BilirrubinaTotal { get; set; }
        [Display(Name = "Bilirrubina Directa")]
        public double? BilirrubinaDirecta { get; set; }
        [Display(Name = "Bilirrubina Indirecta")]
        public double? BilirrubinaIndirecta { get; set; }
        [Display(Name = "Fosfatasa Alcalina")]
        public double? FosfatasaAlcalina { get; set; }
        [Display(Name = "TGO")]
        public double? TGO { get; set; }
        [Display(Name = "TGP")]
        public double? TGP { get; set; }
        [Display(Name = "GGT")]
        public double? GGT { get; set; }


    }
}