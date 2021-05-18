using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class EvolutionNote
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int VitalSignsId { get; set; }
        public VitalSigns VitalSigns { get; set; }
        public int? BiometriaHematicaId { get; set; }
        public BiometriaHematica BiometriaHematica { get; set; }
        public int? QuimicaSanguineaId { get; set; }
        public QuimicaSanguinea QuimicaSanguinea { get; set; }
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