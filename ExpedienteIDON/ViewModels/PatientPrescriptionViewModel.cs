using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpedienteIDON.Models;

namespace ExpedienteIDON.ViewModels
{
    public class PatientPrescriptionViewModel
    {
        public String Patient { get; set; }
        public int Id { get; set; }
        public IEnumerable<Prescription> Prescriptions { get; set; }
    }
}