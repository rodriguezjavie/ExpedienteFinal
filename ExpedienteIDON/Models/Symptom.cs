using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Symptom
    {
        public int Id { get; set; }
        [Display(Name ="Síntoma")]
        public string Name { get; set; }
        [Display(Name = "Severidad")]
        public GradoAfectación Severity { get; set; }
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Fecha de termino")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }


    }
}