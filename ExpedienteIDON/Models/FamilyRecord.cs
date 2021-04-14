using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class FamilyRecord
    {
        public int Id { get; set; }

        [Display(Name = "Diabetes")]
        public KnowledgeStatus StatusDiabetes { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentDiabetes { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingDiabetes { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildDiabetes { get; set; }

        [Display(Name = "Hipertensión")]
        public KnowledgeStatus StatusHypertension { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentHypertension { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingHypertension { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildHypertension { get; set; }

        [Display(Name = "Enfermedad Tiroidea")]
        public KnowledgeStatus StatusThyroid { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentThyroid { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingThyroid { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildThyroid { get; set; }

        [Display(Name = "Hipertrigliceridemia")]
        public KnowledgeStatus StatusHypertriglyceridemia { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentHypertriglyceridemia { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingHypertriglyceridemia { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildHypertriglyceridemia { get; set; }

        [Display(Name = "Hipercolesterolemia")]
        public KnowledgeStatus StatusHypercholesterolemia { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentHypercholesterolemia { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingHypercholesterolemia { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildHypercholesterolemia { get; set; }

        [Display(Name = "Cancer")]
        public KnowledgeStatus StatusCancer { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentCancer { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingCancer { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildCancer { get; set; }

        [Display(Name = "Infarto agudo al miocardio menos de 50 años")]
        public KnowledgeStatus StatusHeartAttack { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentHeartAttack { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingHeartAttack { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildHeartAttack { get; set; }

        [Display(Name = "Infarto agudo al miocardio más de 50 años")]
        public KnowledgeStatus StatusHeartAttackTwo { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency ParentHeartAttackTwo { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency SiblingHeartAttackTwo { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency ChildHeartAttackTwo { get; set; }
    }
}