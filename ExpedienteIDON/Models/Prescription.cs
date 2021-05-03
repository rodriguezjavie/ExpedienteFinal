using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateCreated { get; set; }
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