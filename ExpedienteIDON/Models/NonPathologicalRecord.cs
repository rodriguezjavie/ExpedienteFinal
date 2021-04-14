using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class NonPathologicalRecord
    {
        public int Id { get; set; }
        [Display(Name = "Tipo de sangre")]
        public int? BloodTypeId { get; set; }
        [Display(Name = "Tipo de sangre")]
        public BloodType BloodType { get; set; }
        [Display(Name = "Tabaquismo ?")]
        public bool Smoking { get; set; }
        [Display(Name = "Cigarros al día")]
        public int? SmokingCigars { get; set; }
        [Display(Name = "Año en que empezo")]
        public int? SmokingStarted { get; set; }
        [Display(Name = "Ex fumador ?")]
        public bool ExSmoking { get; set; }
        [Display(Name = "¿Cuanto tiempo fumó?")]
        public int? ExSmokingHowLong { get; set; }
        [Display(Name = "¿Hace cuanto lo dejó?")]
        public int? ExSmokingWhenStopped { get; set; }
        [Display(Name = "Cigarrillos al día")]
        public int? ExSmokingCigars { get; set; }
        [Display(Name = "Alcohol ?")]
        public bool Alcohol { get; set; }
        [Display(Name = "Litros de Alcohol al mes")]
        public int? AlcoholLiters { get; set; }
        [Display(Name = "¿Drogas?")]
        public DrugType DrugsType { get; set; }
        [Display(Name = "¿Dieta?")]
        public DietType DietType { get; set; }
        [Display(Name = "¿Ejercicio?")]
        public ExerciseType ExerciseType { get; set; }
        [Display(Name = "Higiene Personal")]
        public HygieneRange Hygiene { get; set; }
    }
}