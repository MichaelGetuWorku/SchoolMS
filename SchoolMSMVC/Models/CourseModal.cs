using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolMSMVC.Models
{
    public class CourseModal
    {
        [Range(1, 8)]
        public int CourseID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        public Nullable<int> Credits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollmentModal> Enrollments { get; set; }
    }
}