using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.DAL
{
    class UniInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniContext>
    {
        protected override void Seed(UniContext context)
        {
            var students = new List<Student>
            {
                new Student { LastName = "Adams", FirstName = "Gordon", oauth_provider = "web", oauth_uid ="0", Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", Email="gordonadamsnz@gmail.com"},
                new Student { LastName = "Bob", FirstName = "Mr", oauth_provider = "web", oauth_uid ="0", Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", Email="MrBob@gmail.com"},
                new Student { LastName = "Snew", FirstName = "John", oauth_provider = "web", oauth_uid ="0", Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", Email="Snoow@gmail.com"},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {courseID = 1000, CourseName = "Math", Location ="MPH045", Time="12:00 - 13:00", Days = "Mon, Wed, Thu", Type = "Lecture"},
                new Course {courseID = 1001, CourseName = "Math", Location ="HM002", Time="13:00 - 14:00", Days = "Thu", Type = "Tutorial"},
                new Course {courseID = 3000, CourseName = "History", Location ="HM105", Time="12:00 - 14:00", Days = "Tues", Type = "Lecture"},
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {CourseID = 1000, studentID = 1, gradePercent = 80, submisions = new List<string> { "www.google.com" } },
                new Enrollment {CourseID = 1001, studentID = 1, gradePercent = 100, submisions = new List<string> { "www.google.com" } },
                new Enrollment {CourseID = 3000, studentID = 2, gradePercent = 100, submisions = new List<string> { "www.google.com" } },
            };

            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

            var assignments = new List<Assignment>
            {
                new Assignment {CourseID = 1000, DueTime =  DateTime.Parse("2099-09-01"), AssigLink = "www.bing.com"},
                new Assignment {CourseID = 1001, DueTime =  DateTime.Parse("2080-4-01"), AssigLink = "www.bing.com"},
                new Assignment {CourseID = 3000, DueTime =  DateTime.Parse("2070-09-01"), AssigLink = "www.bing.com"},
            };

            assignments.ForEach(s => context.Assignments.Add(s));
            context.SaveChanges();


        }
    }
}
