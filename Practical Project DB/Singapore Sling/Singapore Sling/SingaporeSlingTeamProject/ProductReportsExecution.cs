using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingaporeSlingTeamProject
{
    class ProductReportsExecution
    {
        static void Main(string[] args)
        {
            ProductReports.SaveReportsToMongoDB();
            ProductReports.SaveReportsToFileSystem();
        }
    }
}
