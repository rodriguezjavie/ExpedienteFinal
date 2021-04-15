using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PerfilTiroideo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TSH { get; set; }
        public string T3Total { get; set; }
        public string T3Libre { get; set; }
        public string T4Total { get; set; }
        public string T4Libre { get; set; }


    }
}