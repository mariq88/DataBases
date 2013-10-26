using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Models;

namespace SelectEmployees
{
    class Program
    {
        static TelerikAcademyEntities context = new TelerikAcademyEntities();

        static void InfoWithoutInlude()
        {
            foreach (var employee in context.Employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
        }

        static void InfoWithInlude()
        {
            foreach (var employee in context.Employees.Include("Address.Town").Include("Department"))
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //InfoWithoutInlude(); //342 requests
            InfoWithInlude(); // 2 request
        }
    }
}
