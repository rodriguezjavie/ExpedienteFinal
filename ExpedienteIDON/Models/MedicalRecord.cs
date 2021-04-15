using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class MedicalRecord
    {
        public MedicalRecord()
        {
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("FamilyRecord")]
        public int FamilyRecordId { get; set; }
        public FamilyRecord FamilyRecord { get; set; }
        [ForeignKey("NonPathologicalRecord")]
        public int NonPathologicalRecordId { get; set; }
        public NonPathologicalRecord NonPathologicalRecord { get; set; }
        [ForeignKey("GynecoRecord")]
        public int GynecoRecordId { get; set; }
        public GynecoRecord GynecoRecord { get; set; }
        [ForeignKey("PathologicRecord")]
        public int PathologicRecordId { get; set; }
        public PathologicRecord PathologicRecord { get; set; }
        public DateTime Created { get; set; }
        public int? VitalSignsId { get; set; }
        public VitalSigns VitalSigns { get; set; }
        public int? MedicalTestId { get; set; }
        public MedicalTest MedicalTest { get; set; }
        public int? BiometriaHematicaId { get; set; }
        public BiometriaHematica BiometriaHematica { get; set; }
        public int? QuimicaSanguineaId { get; set; }
        public QuimicaSanguinea QuimicaSanguinea { get; set; }
        public int PhysicalExplorationId { get; set; }
        public PhysicalExploration PhysicalExploration { get; set; }
        public int? PerfilHepaticoId { get; set; }
        public PerfilHepatico PerfilHepatico { get; set; }
        public int? PerfilTiroideoId { get; set; }
        public PerfilTiroideo PerfilTiroideo { get; set; }
        public int? HormonasId { get; set; }
        public Hormonas Hormonas { get; set; }
        public int? GeneralOrinaId { get; set; }
        public GeneralOrina GeneralOrina { get; set; }
        public int? OtrosLabsId { get; set; }
        public OtrosLabs OtrosLabs { get; set; }
        public int OthersId { get; set; }
        public Others Others { get; set; }
    }
}