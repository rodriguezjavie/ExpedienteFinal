using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PerfilTiroideo
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? TSH { get; set; }
        public double? T3Total { get; set; }
        public double? T3Libre { get; set; }
        public double? T4Total { get; set; }
        public double? T4Libre { get; set; }


    }
}