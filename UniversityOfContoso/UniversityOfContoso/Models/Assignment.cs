using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityOfContoso.Models
{
    class Assignment
    {
        public string AssignmentID { get; set; }
        public string CourseID { get; set; }
        public DateTime DueTime { get; set; }
        public string AssigLink { get; set; }
    }
}
