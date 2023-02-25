using System;
using System.Collections.Generic;
using System.Text;

namespace CSCResult.Models
{
    public class StudentCoursesModel
    {
        public string Key { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; } 
        public string MatricNo{ get; set; }
        public string CourseUnit { get; set; } // It is assumed that no calculation is done on this attribute
        public int Score { get; set; }
        public string GradePoint { get; set; }
        public string AdminEmail { get; set; }
    }
}
