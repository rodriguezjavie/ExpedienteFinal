using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.ViewModels
{
    public class HistoryRecordViewModel
    {
        public Patient Patient { get; set; }
        public FamilyRecord FamilyRecord { get; set; }
        public OtherFamilyRecord OtherFamilyRecord { get; set; }
        public NonPathologicalRecord NonPathologicalRecord { get; set; }
        public GynecoRecord GynecoRecord { get; set; }
        public PathologicRecord PathologicRecord { get; set; }
        public OtherPathologicRecord OtherPathologicRecord { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public IEnumerable<BloodType> BloodTypes { get; set; }

    }
}