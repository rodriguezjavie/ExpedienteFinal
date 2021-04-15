using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PhysicalExploration
    {
        public int Id { get; set; }
        public string Habitus { get; set; }
        public string Cabeza { get; set; }
        public bool CuelloBocio { get; set; }
        public bool CuelloSoplo { get; set; }
        public bool CuelloAcantosis { get; set; }
        public string Cuello { get; set; }
        public string Torax { get; set; }
        public string Abdomen { get; set; }
        public bool ToracicosSimetricos { get; set; }
        public bool ToracicosSensibilidad { get; set; }
        public bool ToracicosFuerza { get; set; }
        public bool ToracicosSinovitis { get; set; }
        public string ToracicosROT { get; set; }
        public string ToracicosComments { get; set; }
        public bool PelvicoSimetrico { get; set; }
        public bool PelvicoFuerza { get; set; }
        public bool PelvicoSensibilidad { get; set; }
        public bool PelvicoVarices { get; set; }
        public string PelvicoROT { get; set; }
        public bool PelvicoOnicomicosis { get; set; }
        public bool PelvicoPulsos { get; set; }
        public bool PelvicoEdema { get; set; }
        public string PelvicoOtros { get; set; }
        public string Genitales { get; set; }


    }
}