using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.ViewModels
{
    public class PerfilPatientVM
    {
        public Patient Patient { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public IEnumerable<EvolutionNote> EvolutionNotes { get; set; }
        public IEnumerable<Prescription> Prescriptions { get; set; }
        public List<String> Weight { get; set; }
        public List<String> Dates { get; set; }
        public List<String> Glucose { get; set; }
        public List<String> TASistBI { get; set; }
        public List<String> TADiastBI { get; set; }
    }
}