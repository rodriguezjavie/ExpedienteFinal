using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}