using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolMSMVC.Models
{
    public class EnrollmentModal
    {
        public int EnrollmentID { get; set; }
        public Nullable<decimal> Grade { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Nullable<int> LecturerId { get; set; }
        public virtual CourseModal Course { get; set; }
        public virtual LecturersModal Lecturer { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}