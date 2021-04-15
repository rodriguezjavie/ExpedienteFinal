using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class VitalSigns
    {
        public int Id { get; set; }
        [Display(Name = "Talla (cm)")]
        public int Size { get; set; }
        [Display(Name = "Peso (Kg)")]
        public double Weight { get; set; }
        [Display(Name = "IMC")]
        public double IMC { get; set; }
        [Display(Name = "TA-BD (mmHg)")]
        public int TABD { get; set; }
        [Display(Name = "TA-BI (mmhg)")]
        public int TABI { get; set; }
        [Display(Name = "FC-(Latidos por minuto)")]
        public int FC { get; set; }
        [Display(Name = "FR-(Respiraciones por minuto")]
        public int FR { get; set; }
        [Display(Name = "Cintura (cm)")]
        public double Waist { get; set; }
        [Display(Name = "Cadera (cm)")]
        public double Hip { get; set; }
        [Display(Name = "Saturación de oxigeno (%)")]
        public int OxygenSaturation { get; set; }

    }
}