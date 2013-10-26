using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Client
{
    internal class Program
    {

        static StudentSystemContext context = new StudentSystemContext();

        static void ParseCommand(string command)
        {
            switch (command)
            {
                case "1":
                    ListAllStudents(); break;
                case "2":
                    ListAllCourses(); break;
                case "3":
                    LisAllCoursesAndStudents(); break;
                default:
                    Console.WriteLine("Error reading command.");
                    break;
            }
        }

        private static void LisAllCoursesAndStudents()
        {
          
        }

        private static void ListAllStudents()
        {
            var allStudents = context.Students.ToList();

            foreach (var student in allStudents)
            {
                Console.WriteLine("{0} - {1}", student.Name, student.FacNumber);
            }
        }

        private static void ListAllCourses()
        {
            var allCourses = context.Courses.ToList();

            foreach (var course in allCourses)
            {
                Console.WriteLine("{0}-{1}", course.Name, course.Description);
            }
        }

        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            context.Database.Initialize(true);

            
            Console.WriteLine("Commands:");
            Console.WriteLine("List all students - 1");
            Console.WriteLine("List all courses - 2");
            Console.WriteLine("List all courses with their students - 3");
           

            Console.Write("Enter a command number: ");
            string commandNumber = Console.ReadLine().Trim();

            ParseCommand(commandNumber);
        }
    }
}

