using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class MedicinesPrescription
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string Medicine { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Dose { get; set; }
        public string Frequency { get; set; }
        public string Administration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Indications { get; set; }
    }
}