using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class LabsTest
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? HemoglobinaGlucosilada { get; set; }
        public double? GlucosaSerica { get; set; }
        public double? GlucosaAyuno { get; set; }
        public double? GlucosaCasual { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

    }
}