using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Models;

namespace ToListPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            IEnumerable query = context.Employees.ToList()
                .Select(x => x.Address).ToList()
                .Select(t => t.Town).ToList()
                .Where(t => t.Name == "Sofia");

            foreach (var t in query)
            {
                Console.WriteLine(t);
            } // made 1292 queries

            //IEnumerable querySmart = context.Employees
            //   .Select(x => x.Address)
            //   .Select(t => t.Town)
            //   .Where(t => t.Name == "Sofia").ToList();

            //foreach (var t in querySmart)
            //{
            //    Console.WriteLine(t);
            //} // made 2 queries
        }
    }
}
