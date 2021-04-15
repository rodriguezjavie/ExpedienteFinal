using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class LabsTest
    {
        public int Id { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }
        [Display(Name = "Hemoglobina glucosilada")]
        public double? HemoglobinaGlucosilada { get; set; }
        [Display(Name = "Glucosa Sérica")]
        public double? GlucosaSerica { get; set; }
        [Display(Name = "Glucosa capilar en ayuno")]
        public double? GlucosaAyuno { get; set; }
        [Display(Name = "Glucosa capilar casual")]
        public double? GlucosaCasual { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

    }
}