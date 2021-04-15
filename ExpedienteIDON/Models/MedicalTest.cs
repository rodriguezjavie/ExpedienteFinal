using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class MedicalTest
    {
        public int Id { get; set; }
        public bool RadiographTorax { get; set; }
        public DateTime? RadiographToraxDate { get; set; }
        public bool RadiographToraxNormal { get; set; }
        public bool Ultrasound { get; set; }
        public DateTime? UltrasoundDate { get; set; }
        public string UltrasoundType { get; set; }
        public string Observations { get; set; }
        public bool Electrocardiography { get; set; }
        public DateTime? ElectrocardiographyDate { get; set; }
        public bool ElectrocardiographyNormal { get; set; }
        public string ElectrocardiographyObservations { get; set; }
        public string Others { get; set; }


    }
}