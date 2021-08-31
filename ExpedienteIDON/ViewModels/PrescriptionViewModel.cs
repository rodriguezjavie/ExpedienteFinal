using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.ViewModels
{
    public class PrescriptionViewModel
    {
        public UserDataViewModel UserDataViewModel { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Prescription Prescription { get; set; }
        public MedicinesPrescription MedicinesPrescription { get; set; }
        [Required]
        public List<MedicinesPrescription> MedicinesPrescriptions { get; set; }
    }
}