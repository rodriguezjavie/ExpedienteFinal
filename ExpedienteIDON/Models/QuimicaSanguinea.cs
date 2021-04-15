using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class QuimicaSanguinea
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Glucosa { get; set; }
        public string Creatinina { get; set; }
        public string AcidoUrico { get; set; }
        public string Colesterol { get; set; }
        public string Trigliceridos { get; set; }
        public string HDL { get; set; }
        public string LDL { get; set; }

    }
}