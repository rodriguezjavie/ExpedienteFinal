using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class MedicalTest
    {
        public int Id { get; set; }
        public string Radiograph { get; set; }
        public DateTime RadiographDate { get; set; }
        public string RadiographNormal { get; set; }
        public string Ultrasound { get; set; }
        public DateTime UltrasoundDate { get; set; }
        public string UltrasoundType { get; set; }
        public string Observations { get; set; }
        public string Electrocardiography { get; set; }
        public DateTime ElectrocardiographyDate { get; set; }
        public string ElectrocardiographyNormal { get; set; }
        public string ElectrocardiographyObservations { get; set; }
        public string Others { get; set; }


    }
}