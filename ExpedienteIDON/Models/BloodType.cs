using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class BloodType
    {
        [Display(Name = "Tipo de sangre")]
        public int Id { get; set; }
        [Display(Name = "Tipo de sangre")]
        public string Name { get; set; }
    }
}