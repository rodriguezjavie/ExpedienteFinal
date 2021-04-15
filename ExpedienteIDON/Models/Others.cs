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
        [Display(Name = "Motivo de consulta")]
        public string Reason { get; set; }
        [Display(Name = "Diagnostico")]
        public string Diagnosis { get; set; }
        [Display(Name = "Pronostico")]
        public Prognosis Prognosis { get; set; }

    }
}