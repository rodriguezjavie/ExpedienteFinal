using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class BiometriaHematica
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Eritrocitos { get; set; }
        public string Hemoglobina { get; set; }
        public string Leucocitos { get; set; }
        public string Linfocitos { get; set; }
        public string Monocitos { get; set; }
        public string Plaquetas { get; set; }

    }
}