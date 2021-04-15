using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Hormonas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LH { get; set; }
        public string FSH { get; set; }
        public string Prolactina { get; set; }
        public string Progesterona { get; set; }
        public string Estrogenos { get; set; }
        public string Cortisol { get; set; }



    }
}