using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CSCResult.Models
{
    public class StudentProfile
    {
        public int ProfileId { get; set; }
        public string MatricNo { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string AdmissionCategory { get; set; }

    }
}
