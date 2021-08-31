using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.ViewModels
{
    public class HistoryRecordViewModel
    {
        public UserDataViewModel UserDataViewModel { get; set; }
        public Doctor Doctor { get; set; }
        public OtherFamilyRecord OtherFamilyRecord { get; set; }
        public OtherPathologicRecord OtherPathologicRecord { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public List<Symptom> Symptoms { get; set; }
        public LabsTest LabsTest { get; set; }
        public IEnumerable<BloodType> BloodTypes { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public IEnumerable<Municipio> Municipios { get; set; }
        public Prescription Prescription { get; set; }

    }
}