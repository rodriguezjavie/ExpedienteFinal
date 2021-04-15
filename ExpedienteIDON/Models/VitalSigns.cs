using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class VitalSigns
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public double Weight { get; set; }
        public double IMC { get; set; }
        public int TABD { get; set; }
        public int TABI { get; set; }
        public int FC { get; set; }
        public int FR { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
        public int OxygenSaturation { get; set; }

    }
}