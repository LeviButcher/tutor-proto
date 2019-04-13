using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting.Server;

namespace TutorPrototype.EF
{
    public class DbInitializer
    {
        private TPContext _context;

        public DbInitializer(TPContext context)
        {
            _context = context;
        }

        public static void InitializeData(TPContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }

        public static void ClearData(TPContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[SignInReasons]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[SignInCourses]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[SignIns]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Courses]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Departments]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Reasons]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[People]");
            context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Semesters]");
        }

        private static void SeedData(TPContext context)
        {
            string courses = File.ReadAllText(@"..\..\SampleData\dbo.Courses.data.sql");
            string departments = File.ReadAllText(@"..\..\SampleData\dbo.Departments.data.sql");
            string people = File.ReadAllText(@"..\..\SampleData\dbo.People.data.sql");
            string reasons = File.ReadAllText(@"..\..\SampleData\dbo.Reasons.data.sql");
            string semesters = File.ReadAllText(@"..\..\SampleData\dbo.Semesters.data.sql");
            string signIns = File.ReadAllText(@"..\..\SampleData\dbo.SignIns.data.sql");
            string signInReasons = File.ReadAllText(@"..\..\SampleData\dbo.SignInReasons.data.sql");
            string signInCourses = File.ReadAllText(@"..\..\SampleData\dbo.SignInCourses.data.sql");

            context.Database.ExecuteSqlCommand(courses);
            context.Database.ExecuteSqlCommand(departments);
            context.Database.ExecuteSqlCommand(people);
            context.Database.ExecuteSqlCommand(reasons);
            context.Database.ExecuteSqlCommand(semesters);
            context.Database.ExecuteSqlCommand(signIns);
            context.Database.ExecuteSqlCommand(signInReasons);
            context.Database.ExecuteSqlCommand(signInCourses);
        }

    }
}
