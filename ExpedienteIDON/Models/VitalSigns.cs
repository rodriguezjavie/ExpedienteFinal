using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class VitalSigns
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string IMC { get; set; }
        public string TABD { get; set; }
        public string TABI { get; set; }
        public string FC { get; set; }
        public string FR { get; set; }
        public string Waist { get; set; }
        public string Hip { get; set; }
        public string OxygenSaturation { get; set; }

    }
}