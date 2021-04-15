using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class QuimicaSanguinea
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? Glucosa { get; set; }
        public double? Creatinina { get; set; }
        public double? AcidoUrico { get; set; }
        public double? Colesterol { get; set; }
        public double? Trigliceridos { get; set; }
        public double? HDL { get; set; }
        public double? LDL { get; set; }

    }
}