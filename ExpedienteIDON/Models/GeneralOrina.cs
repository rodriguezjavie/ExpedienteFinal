using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class GeneralOrina
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Aspecto { get; set; }
        public string Densidad { get; set; }
        public string Ph { get; set; }
        public string Glucosa { get; set; }
        public string Proteinas { get; set; }
        public string Sangre { get; set; }
        public string Cetonas { get; set; }
        public string Nitricos { get; set; }
        public string Esterasa { get; set; }
        public string Leucocitos { get; set; }
        public string Bacterias { get; set; }
    }
}