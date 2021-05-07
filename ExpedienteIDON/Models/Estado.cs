using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
}