using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class OtherPathologicRecord
    {
        public int Id { get; set; }
        [ForeignKey("PathologicRecord")]
        public int PathologicRecordId { get; set; }
        public PathologicRecord PathologicRecord { get; set; }
        [Display(Name = "Otra Patologia")]
        public string Name { get; set; }
        [Display(Name = "Año de Diagnostico")]
        public int? DiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string Comment { get; set; }
    }
}