using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PerfilHepatico
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BilirrubinaTotal { get; set; }
        public string BilirrubinaDirecta { get; set; }
        public string BilirrubinaIndirecta { get; set; }
        public string FosfatasaAlcalina { get; set; }
        public string TGO { get; set; }
        public string TGP { get; set; }
        public string GGT { get; set; }


    }
}