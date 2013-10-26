namespace StudentSystem.Data.Migrations
{
    using StudentSystem;
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            //context.Courses.AddOrUpdate(
            //c => c.Name,
            //        new Course { Name = "Databases", Description = "Telerik Academy Databases course" },
            //        new Course { Name = "C#", Description = "Telerik Academy C# course" }
            //    );

            //context.Students.AddOrUpdate(
            //s => s.Name,
            //        new Student { Name = "Pesho", FacNumber = "B123123" },
            //        new Student { Name = "Mesho", FacNumber = "C456456" },
            //        new Student { Name = "Pesho", FacNumber = "K123456" }
            //    );

            //context.Students
            //    .Where(x => x.FacNumber == "B123123")
            //    .First()
            //    .Courses.Add(context.Courses.Where(c => c.Name == "C#").First());

            //context.Students
            //    .Where(x => x.FacNumber == "B123123")
            //    .First()
            //    .Courses.Add(context.Courses.Where(c => c.Name == "Databases").First());

            //context.Students
            //    .Where(x => x.FacNumber == "C456456")
            //    .First()
            //    .Courses.Add(context.Courses.Where(c => c.Name == "C#").First());

            //context.Students
            //    .Where(x => x.FacNumber == "K123456")
            //    .First()
            //    .Courses.Add(context.Courses.Where(c => c.Name == "Databases").First());

            //context.SaveChanges();

        }
    }
}
