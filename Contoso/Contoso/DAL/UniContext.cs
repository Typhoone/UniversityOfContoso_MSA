using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using Contoso.Models;

namespace Contoso.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UniContext : DbContext
    {
        public UniContext() : base("UniContext")
        {

        }

        public System.Data.Entity.DbSet<Contoso.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<Contoso.Models.Enrollment> Enrollments { get; set; }
        public System.Data.Entity.DbSet<Contoso.Models.Course> Courses { get; set; }
        public System.Data.Entity.DbSet<Contoso.Models.Assignment> Assignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
