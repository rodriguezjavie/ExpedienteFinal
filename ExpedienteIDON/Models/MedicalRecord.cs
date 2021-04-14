using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExpedienteIDON.Models
{
    public class MedicalRecord
    {
        public MedicalRecord()
        {
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("FamilyRecord")]
        public int FamilyRecordId { get; set; }
        public FamilyRecord FamilyRecord { get; set; }
        [ForeignKey("NonPathologicalRecord")]
        public int NonPathologicalRecordId { get; set; }
        public NonPathologicalRecord NonPathologicalRecord { get; set; }
        [ForeignKey("GynecoRecord")]
        public int GynecoRecordId { get; set; }
        public GynecoRecord GynecoRecord { get; set; }
        [ForeignKey("PathologicRecord")]
        public int PathologicRecordId { get; set; }
        public PathologicRecord PathologicRecord { get; set; }
        public DateTime Created { get; set; }
    }
}