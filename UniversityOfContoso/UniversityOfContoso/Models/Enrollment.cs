using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityOfContoso.Models
{
    class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int studentID { get; set; }
        public int gradePercent { get; set; }
        public ICollection<string> submisions { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }

    }
}
