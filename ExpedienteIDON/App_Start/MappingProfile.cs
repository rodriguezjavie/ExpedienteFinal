using AutoMapper;
using ExpedienteIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, Patient>();
            Mapper.CreateMap<EvolutionNote, EvolutionNote>();
            Mapper.CreateMap<MedicalRecord, MedicalRecord>();
            Mapper.CreateMap<FamilyRecord, FamilyRecord>();
            Mapper.CreateMap<GynecoRecord, GynecoRecord>();
            Mapper.CreateMap<MedicalTest, MedicalTest>();
            Mapper.CreateMap<NonPathologicalRecord, NonPathologicalRecord>();
            Mapper.CreateMap<PathologicRecord, PathologicRecord>();
            Mapper.CreateMap<PhysicalExploration, PhysicalExploration>();
            Mapper.CreateMap<Symptom, Symptom>();
            Mapper.CreateMap<OtherFamilyRecord, OtherFamilyRecord>();
            Mapper.CreateMap<OtherPathologicRecord, OtherPathologicRecord>();
            Mapper.CreateMap<LabsTest, LabsTest>();
            Mapper.CreateMap<Others, Others>();
            Mapper.CreateMap<VitalSigns, VitalSigns>();
            Mapper.CreateMap<BiometriaHematica, BiometriaHematica>();
            Mapper.CreateMap<GeneralOrina, GeneralOrina>();
            Mapper.CreateMap<Hormonas, Hormonas>();
            Mapper.CreateMap<OtrosLabs, OtrosLabs>();
            Mapper.CreateMap<PerfilHepatico, PerfilHepatico>();
            Mapper.CreateMap<PerfilTiroideo, PerfilTiroideo>();
            Mapper.CreateMap<QuimicaSanguinea, QuimicaSanguinea>();
            Mapper.CreateMap<MedicinesPrescription, MedicinesPrescription>(); 
        }
    }
}