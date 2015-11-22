using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity_Final.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string oauth_provider { get; set; }
        public string oauth_uid { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
