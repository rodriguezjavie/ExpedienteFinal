using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.ViewModels
{
    public class EvolutionNoteVM
    {
        public UserDataViewModel UserDataViewModel { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public EvolutionNote EvolutionNote { get; set; }
        public Prescription Prescription { get; set; }
    }
}