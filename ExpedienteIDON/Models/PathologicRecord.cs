using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class PathologicRecord
    {
        public PathologicRecord()
        {
            MedicalRecords = new HashSet<MedicalRecord>();
            OtherPathologicRecords = new HashSet<OtherPathologicRecord>();

        }
        public int Id { get; set; }
        [Display(Name = "Diabetes tipo 1")]
        public bool DiabetesType1 { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? Diabetes1DiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string Diabetes1Comment { get; set; }
        [Display(Name = "Diabetes tipo 2")]
        public bool DiabetesType2 { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? Diabetes2DiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string Diabetes2Comment { get; set; }
        [Display(Name = "Obesidad")]
        public bool Obesity { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? ObesityDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string ObesityComment { get; set; }
        [Display(Name = "Peso Maximo")]
        public int? MaxWeight { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? WeightDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string WeightComment { get; set; }
        [Display(Name = "Hipertensión arterial sistémica")]
        public bool Hypertension { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? HypertensionDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string HypertensionComment { get; set; }
        [Display(Name = "Cardiopatía isqémica")]
        public bool IschemicHeartDisease { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? IschemicHeartDiseaseDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string IschemicHeartDiseaseComment { get; set; }
        [Display(Name = "Cardiopatía no isqémica")]
        public bool NoIschemicHeartDisease { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? NoIschemicHeartDiseaseDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string NoIschemicHeartDiseaseComment { get; set; }
        [Display(Name = "Enfermedad vascular cerebral")]
        public bool CerebralDisease { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? CerebralDiseaseDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string CerebralDiseaseComment { get; set; }
        [Display(Name = "Epilepsia")]
        public bool Epilepsy { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? EpilepsyDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string EpilepsyComment { get; set; }
        [Display(Name = "Enfermedad tiroidea")]
        public bool Thyroid { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? ThyroidDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string ThyroidComment { get; set; }
        [Display(Name = "Enfermedad pulmonar crónica")]
        public bool LungDisease { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? LungDiseaseDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string LungDiseaseComment { get; set; }
        [Display(Name = "Hepatopatía crónica")]
        public bool LiverDisease { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? LiverDiseaseDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string LiverDiseaseComment { get; set; }
        [Display(Name = "Enfermedad de colon irritable")]
        public bool Colon { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? ColonDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string ColonComment { get; set; }
        [Display(Name = "Cancer")]
        public bool Cancer { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? CancerDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string CancerComment { get; set; }
        [Display(Name = "Hipertrigliceridemia")]
        public bool Hypertriglyceridemia { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? HypertriglyceridemiaDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string HypertriglyceridemiaComment { get; set; }
        [Display(Name = "Hipercolesterolemia")]
        public bool Hypercholesterolemia { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? HypercholesterolemiaDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string HypercholesterolemiaComment { get; set; }
        [Display(Name = "Nefropatía diabética")]
        public bool Necropathy { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? NecropathyDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string NecropathyComment { get; set; }
        [Display(Name = "Retinopatía diabética")]
        public bool Retinopathy { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? RetinopathyDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string RetinopathyComment { get; set; }
        [Display(Name = "Procedimientos oftalmológicos")]
        public bool Ophthalmological { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? OphthalmologicalDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string OphthalmologicalComment { get; set; }
        [Display(Name = "Neuropatia diabética")]
        public bool Neuropathy { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? NeuropathyDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string NeuropathyComment { get; set; }
        [Display(Name = "Transfusión de sangre y hemoderivados")]
        public bool BloodTransfusion { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? BloodTransfusionDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string BloodTransfusionComment { get; set; }
        [Display(Name = "Alergias a medicamentos")]
        public bool Allergy { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? AllergyDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string AllergyComment { get; set; }
        [Display(Name = "Cirugías")]
        public bool Surgery { get; set; }
        [Display(Name = "Año de diagnóstico")]
        public int? SurgeryDiagnosticYear { get; set; }
        [Display(Name = "Comentarios")]
        public string SurgeryComment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherPathologicRecord> OtherPathologicRecords { get; set; }
    }
}