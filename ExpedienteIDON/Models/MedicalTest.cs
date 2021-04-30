using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class MedicalTest
    {
        public int Id { get; set; }
        [Display(Name = "Radiografía de tórax")]
        public bool RadiographTorax { get; set; }
        [Display(Name = "Fecha de radiografía de tórax")]
        public DateTime? RadiographToraxDate { get; set; }
        [Display(Name = "¿Radiografía de tórax normal?")]
        public bool RadiographToraxNormal { get; set; }
        [Display(Name = "Comentarios de Radiografía")]
        public string RadiographToraxObservations { get; set; }
        [Display(Name = "Ultrasonido")]
        public bool Ultrasound { get; set; }
        [Display(Name = "Fecha de ultrasonido")]
        public DateTime? UltrasoundDate { get; set; }
        [Display(Name = "Tipo de ultrasonido")]
        public string UltrasoundType { get; set; }
        [Display(Name = "Hallazgos ultrasonido")]
        public string Observations { get; set; }
        [Display(Name = "Electrocardiograma en reposo")]
        public bool Electrocardiography { get; set; }
        [Display(Name = "Fecha de electrocardiograma")]
        public DateTime? ElectrocardiographyDate { get; set; }
        [Display(Name = "¿Electrocardiograma normal?")]
        public bool ElectrocardiographyNormal { get; set; }
        [Display(Name = "Comentarios de electrocardiograma")]
        public string ElectrocardiographyObservations { get; set; }
        [Display(Name = "Otros Estudios")]
        public string Others { get; set; }


    }
}