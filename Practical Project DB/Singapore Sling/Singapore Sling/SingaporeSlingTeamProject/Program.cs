using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingaporeSlingTeamProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //XMLData.LoadDataIntoMongoDB("../../test-report.xml");
            //XMLData.LoadDataIntoSQLServer("../../test-report.xml");
            ProductReports.SaveReportsToMongoDB();
            //ProductReports.SaveReportsToFileSystem();
        }
    }
}
