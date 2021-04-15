using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PhysicalExploration
    {
        public int Id { get; set; }
        [Display(Name = "Habitus exterior")]
        public string Habitus { get; set; }
        [Display(Name = "Cabeza")]
        public string Cabeza { get; set; }
        [Display(Name = "Cuello Bocio")]
        public bool CuelloBocio { get; set; }
        [Display(Name = "Soplo(s) carotideos")]
        public bool SoploCarotideo { get; set; }
        [Display(Name = "Acantosis")]
        public bool CuelloAcantosis { get; set; }
        [Display(Name = "Severidad Acantosis")]
        public GradoAfectación AcanosisAfectacion { get; set; }
        [Display(Name = "Comentarios Cuello")]
        public string CuelloComments { get; set; }
        [Display(Name = "Comentarios Torax")]
        public string ToraxComments { get; set; }
        [Display(Name = "Comentarios Abdomen")]
        public string AbdomenComments { get; set; }
        [Display(Name = "Miembros Torácicos simetricos")]
        public bool ToracicosSimetricos { get; set; }
        [Display(Name = "Sensibilidad miembros torácicos")]
        public bool ToracicosSensibilidad { get; set; }
        [Display(Name = "Fuerza miembros torácicos")]
        public bool ToracicosFuerza { get; set; }
        [Display(Name = "Miembros torácicos sinovitis")]
        public bool ToracicosSinovitis { get; set; }
        [Display(Name = "RTO bicipital")]
        public string ToracicosROT { get; set; }
        [Display(Name = "Comentarios Miembros torácicos")]
        public string ToracicosComments { get; set; }
        [Display(Name = "Simetria miembros pélvicos")]
        public bool PelvicoSimetrico { get; set; }
        [Display(Name = "Fureza miembros pélvicos")]
        public bool PelvicoFuerza { get; set; }
        [Display(Name = "Sensibilidad miembros pelvicos")]
        public bool PelvicoSensibilidad { get; set; }
        [Display(Name = "Varices")]
        public bool PelvicoVarices { get; set; }
        [Display(Name = "RTO Aquileos")]
        public bool PelvicoROTAquileo { get; set; }
        [Display(Name = "Onicomicosis")]
        public bool PelvicoOnicomicosis { get; set; }
        [Display(Name = "Pulsos pedios presentes")]
        public bool PelvicoPulsos { get; set; }
        [Display(Name = "Edema Maleolar")]
        public bool PelvicoEdema { get; set; }
        [Display(Name = "Otros Hallazgos")]
        public string PelvicoOtros { get; set; }
        [Display(Name = "Genitales")]
        public string Genitales { get; set; }


    }
}