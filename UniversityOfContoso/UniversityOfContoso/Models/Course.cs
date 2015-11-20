using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityOfContoso.Models
{
    class Course
    {
        public int courseID { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Days { get; set; }
        public string Type { get; set; }



        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
