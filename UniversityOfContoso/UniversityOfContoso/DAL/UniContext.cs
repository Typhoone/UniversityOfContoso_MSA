using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using UniversityOfContoso.Models;

namespace UniversityOfContoso.DAL
{
    public class UniContext : DbContext
    {
        public UniContext() : base("UniContext")
        {

        }


        public System.Data.Entity.DbSet<UniversityOfContoso.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<UniversityOfContoso.Models.Enrollment> Enrollments { get; set; }
        public System.Data.Entity.DbSet<UniversityOfContoso.Models.Course> Courses { get; set; }
        public System.Data.Entity.DbSet<UniversityOfContoso.Models.Assignment> Assignments { get; set; }
    }
}
