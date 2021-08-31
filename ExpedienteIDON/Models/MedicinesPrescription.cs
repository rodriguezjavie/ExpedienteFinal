using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class MedicinesPrescription
    {
        public int Id { get; set; }
        
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        [Required]
        [Display(Name = "Medicamento")]
        public string Medicine { get; set; }
        [Display(Name = "Presentación")]
        public string UnitOfMeasure { get; set; }
        [Display(Name = "Dosis")]
        public string Dose { get; set; }
        [Display(Name = "Frecuencia")]
        public string Frequency { get; set; }
        [Display(Name = "Via de administración")]
        public string Administration { get; set; }
        [Display(Name ="Duración del tratamiento")]
        public string TreatmentDuration { get; set; }
        [Display(Name = "Indicaciones adicionales")]
        public string Indications { get; set; }
    }
}