using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Hormonas
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? LH { get; set; }
        public double? FSH { get; set; }
        public double? Prolactina { get; set; }
        public double? Progesterona { get; set; }
        public double? Estrogenos { get; set; }
        public double? Cortisol { get; set; }



    }
}