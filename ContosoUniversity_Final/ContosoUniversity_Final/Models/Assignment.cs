using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity_Final.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int CourseID { get; set; }
        public DateTime DueTime { get; set; }
        public string AssigLink { get; set; }
    }
}
