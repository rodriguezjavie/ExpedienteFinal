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
        [Required]
        [Display(Name = "Talla (cm)")]
        public int Size { get; set; }
        [Required]
        [Display(Name = "Peso (Kg)")]
        public double Weight { get; set; }
        [Display(Name = "IMC")]
        public double IMC { get; set; }
        [Required]
        [Display(Name = "TA-BD (mmHg)")]
        public string TABD { get; set; }
        [Required]
        [Display(Name = "TA-BI (mmhg)")]
        public string TABI { get; set; }
        [Required]
        [Display(Name = "FC-(Latidos por minuto)")]
        public int FC { get; set; }
        [Required]
        [Display(Name = "FR-(Respiraciones por minuto")]
        public int FR { get; set; }
        [Required]
        [Display(Name = "Cintura (cm)")]
        public double Waist { get; set; }
        [Required]
        [Display(Name = "Cadera (cm)")]
        public double Hip { get; set; }
        [Required]
        [Range(1, 100,
        ErrorMessage = "El valor debe estar entre 1 y 100.")]
        [Display(Name = "Saturación de oxigeno (%)")]
        public int OxygenSaturation { get; set; }

    }
}