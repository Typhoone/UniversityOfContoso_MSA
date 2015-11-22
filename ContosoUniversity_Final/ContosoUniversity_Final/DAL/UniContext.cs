using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using ContosoUniversity_Final.Models;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System;

namespace ContosoUniversity_Final.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UniContext : DbContext
    {
        public class DBConfig : DbMigrationsConfiguration<UniContext>
        {
            public DBConfig()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(UniContext context)
            {
                /*var students = new List<Student>
            {
                new Student {ID = 1,  LastName = "Adams", FirstName = "Gordon", oauth_provider = "web", oauth_uid ="0", Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", Email="gordonadamsnz@gmail.com"},
                new Student {ID = 2, LastName = "Bob", FirstName = "Mr", oauth_provider = "web", oauth_uid ="1", Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", Email="MrBob@gmail.com"},
                new Student {ID = 3, LastName = "Snew", FirstName = "John", oauth_provider = "web", oauth_uid ="2", Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", Email="Snoow@gmail.com"},
            };

                //students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
                //context.Students.Add(students[0]);
                context.Students.Add(students[1]);
                context.Students.Add(students[2]);
                context.SaveChanges();

                var courses = new List<Course>
            {
                new Course {courseID = 1000, CourseName = "Math", Location ="MPH045", Time="12:00 - 13:00", Days = "Mon, Wed, Thu", Type = "Lecture"},
                new Course {courseID = 1001, CourseName = "Math", Location ="HM002", Time="13:00 - 14:00", Days = "Thu", Type = "Tutorial"},
                new Course {courseID = 3000, CourseName = "History", Location ="HM105", Time="12:00 - 14:00", Days = "Tues", Type = "Lecture"},
            };

                //courses.ForEach(s => context.Courses.AddOrUpdate(p => p.courseID, s));
                context.Courses.Add(courses[0]);
                context.Courses.Add(courses[1]);
                context.Courses.Add(courses[2]);
                context.SaveChanges();

                var enrollments = new List<Enrollment>
            {
                new Enrollment {CourseID = 1000, studentID = 1, gradePercent = 80, submisions = new List<string> { "www.google.com" }, EnrollmentID = 1 },
                new Enrollment {CourseID = 1001, studentID = 1, gradePercent = 100, submisions = new List<string> { "www.google.com" }, EnrollmentID = 2 },
                new Enrollment {CourseID = 3000, studentID = 2, gradePercent = 100, submisions = new List<string> { "www.google.com" }, EnrollmentID = 3 },
            };

                //enrollments.ForEach(s => context.Enrollments.AddOrUpdate(p => p.CourseID, s));

                context.Enrollments.Add(enrollments[0]);
                context.Enrollments.Add(enrollments[1]);
                context.Enrollments.Add(enrollments[2]);
                context.SaveChanges();

                var assignments = new List<Assignment>
            {
                new Assignment {CourseID = 1000, DueTime =  DateTime.Parse("2099-09-01"), AssigLink = "www.bing.com", AssignmentID = 1},
                new Assignment {CourseID = 1001, DueTime =  DateTime.Parse("2080-4-01"), AssigLink = "www.bing.com", AssignmentID = 2},
                new Assignment {CourseID = 3000, DueTime =  DateTime.Parse("2070-09-01"), AssigLink = "www.bing.com", AssignmentID = 3},
            };

                //assignments.ForEach(s => context.Assignments.AddOrUpdate(p => p.CourseID, s));

                context.Assignments.Add(assignments[0]);
                context.Assignments.Add(assignments[1]);
                context.Assignments.Add(assignments[2]);
                context.SaveChanges();*/


            }

        }

        public UniContext() : base("UniContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniContext, DBConfig>());
        }

        public System.Data.Entity.DbSet<ContosoUniversity_Final.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<ContosoUniversity_Final.Models.Enrollment> Enrollments { get; set; }
        public System.Data.Entity.DbSet<ContosoUniversity_Final.Models.Course> Courses { get; set; }
        public System.Data.Entity.DbSet<ContosoUniversity_Final.Models.Assignment> Assignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
