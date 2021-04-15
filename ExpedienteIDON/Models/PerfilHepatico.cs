using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PerfilHepatico
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? BilirrubinaTotal { get; set; }
        public double? BilirrubinaDirecta { get; set; }
        public double? BilirrubinaIndirecta { get; set; }
        public double? FosfatasaAlcalina { get; set; }
        public double? TGO { get; set; }
        public double? TGP { get; set; }
        public double? GGT { get; set; }


    }
}