using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpedienteIDON.Models;

namespace ExpedienteIDON.ViewModels
{
    public class PatientRecordProfile
    {
        public Patient Patient { get; set; }

        public Boolean Record { get; set; }
    }
}