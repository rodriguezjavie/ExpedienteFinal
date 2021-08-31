using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Others
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Motivo de consulta")]
        public string Reason { get; set; }
        [Required]
        [Display(Name = "Diagnostico")]
        public string Diagnosis { get; set; }
        [Display(Name = "Pronostico")]
        public Prognosis Prognosis { get; set; }
        [Display(Name ="Notas y comentarios")]
        public string Notes { get; set; }

    }
}