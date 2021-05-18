using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime CratedDate { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int? EvolutionNoteId { get; set; }
        public EvolutionNote EvolutionNote { get; set; }
        public int? MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}