using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class BiometriaHematica
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? Eritrocitos { get; set; }
        public double? Hemoglobina { get; set; }
        public double? Leucocitos { get; set; }
        public double? Linfocitos { get; set; }
        public double? Monocitos { get; set; }
        public double ?Plaquetas { get; set; }

    }
}