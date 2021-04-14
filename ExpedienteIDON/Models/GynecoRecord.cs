using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class GynecoRecord
    {
        public int Id { get; set; }
        public int? Menarca { get; set; }
        public int? Gesta { get; set; }
        public int? Para { get; set; }
        public int? Cesarea { get; set; }
        public int? Aborto { get; set; }
        public int? Obitos { get; set; }
        [Display(Name = "Inicio de vida sexual")]
        public int? SexualLifeStart { get; set; }
        [Display(Name = "Ciclo menstrual regular")]
        public bool RegularMenstrualCycle { get; set; }
        [Display(Name = "Fecha de última menstruación")]
        public DateTime? LastMenstruationDate { get; set; }
        public bool Amenorrea { get; set; }
        [Display(Name = "Uso de metodo anticonceptivo")]
        public BirthControlMethods BirthControlMethod { get; set; }
        [Display(Name = "Hipertensión durante el embarazo")]
        public KnowledgeStatus PregnancyHypertension { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? PregnancyHypertensionDate { get; set; }
        [Display(Name = "Diabetes durante el embarazo")]
        public KnowledgeStatus PregnancyDiabetes { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? PregnancyDiabetesDate { get; set; }
        [Display(Name = "Hijos con peso mayor a 4kg al nacer")]
        public KnowledgeStatus ChildrenPlus4Kg { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? ChildrenPlus4KgDate { get; set; }
    }

}