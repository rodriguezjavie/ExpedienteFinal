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
        public Symptom Symptom { get; set; }
        public VitalSigns VitalSigns { get; set; }
        public PhysicalExploration PhysicalExploration { get; set; }
        public MedicalTest MedicalTest { get; set; }
        public LabsTest LabsTest { get; set; }
        public Others Others { get; set; }
        public BiometriaHematica BiometriaHematica { get; set; }
        public QuimicaSanguinea QuimicaSanguinea { get; set; }
        public Hormonas Hormonas { get; set; }
        public PerfilHepatico PerfilHepatico { get; set; }
        public PerfilTiroideo PerfilTiroideo { get; set; }
        public GeneralOrina GeneralOrina { get; set; }
        public OtrosLabs OtrosLabs { get; set; }
        public IEnumerable<BloodType> BloodTypes { get; set; }

    }
}