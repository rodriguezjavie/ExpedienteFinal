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
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "Talla (cm)")]
        public double Size { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "Peso (Kg)")]
        public double Weight { get; set; }
        [Display(Name = "IMC")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double IMC { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "TA-Sistolica-BD (mmHg)")]
        public int TASistBD { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "TA-Diastolica-BD (mmHg)")]
        public int TADiastBD { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "TA-Sistolica-BIzq (mmHg)")]
        public int TASistBI { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "TA-Diastolica-BIzq (mmHg)")]
        public int TADiastBI { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "FC-(Latidos por minuto)")]
        public int FC { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        [Display(Name = "FR-(Respiraciones por minuto")]
        public int FR { get; set; }
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
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
        [Display(Name ="Glucosa en sangre")]
        [Range(0, int.MaxValue,
        ErrorMessage = "El valor debe ser mayor a 0.")]
        public int? Glucose { get; set; }

    }
}