using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class OtherFamilyRecord
    {
        public int Id { get; set; }
        public int FamilyRecordId { get; set; }
        public FamilyRecord FamilyRecord { get; set; }
        [Display(Name = "Otros antecedentes")]
        public string Name { get; set; }
        [Display(Name = "Padres")]
        public GenderDependency Parents { get; set; }
        [Display(Name = "Hermanos")]
        public GenderDependency Sibilings { get; set; }
        [Display(Name = "Hijos")]
        public GenderDependency Childs { get; set; }

    }
}