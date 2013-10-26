using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics;
using System.Globalization;
using SuperMarketInfo.Model;

namespace XMLReports
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSalesReport();
        }

        public static void GetSalesReport()
        {
            SupermarketInformationEntities1 DB = new SupermarketInformationEntities1();
            using (DB)
            {
                List<KeyValuePair<DateTime, decimal>> currentSummary = new List<KeyValuePair<DateTime, decimal>>();
                Dictionary<string, List<KeyValuePair<DateTime, decimal>>> vendorsReports = new Dictionary<string, List<KeyValuePair<DateTime, decimal>>>();

                var allVendors =
                      (from vendor in DB.Vendors
                      orderby vendor.VendorName
                      select new
                      {
                          Name = vendor.VendorName,
                          ID = vendor.ID
                      }).Distinct();

                var allDates =
                      (from report in DB.Reports
                       orderby report.ReportDate descending
                       select report.ReportDate).Distinct();

                foreach (var currentVendor in allVendors)
                {
                    currentSummary = new List<KeyValuePair<DateTime, decimal>>();

                    foreach (DateTime currentDate in allDates)
                    {

                        decimal totalProfit =
                            (from report in DB.Reports
                             join product in DB.Products
                             on report.ProductID equals product.ID
                             where report.ReportDate == currentDate &&
                                 product.VendorID == currentVendor.ID
                             select
                                report.Sum).DefaultIfEmpty(0M).Sum();

                        currentSummary.Add(new KeyValuePair<DateTime, decimal>(currentDate, totalProfit));
                    }

                    vendorsReports.Add(currentVendor.Name, currentSummary);

                }

                SaveXMLToFile(vendorsReports);

            }
        }

        public static void SaveXMLToFile(Dictionary<string, List<KeyValuePair<DateTime, decimal>>> salesReport)
        {
            XElement rootElement = new XElement("sales");

            foreach (var currentSaleReport in salesReport)
            {
                XElement currentVendor = new XElement("sale", new XAttribute("vendor", currentSaleReport.Key));

                foreach (var summaryAttribute in currentSaleReport.Value)
                {
                    XElement currentVendorSummary = new XElement("summary",

                        new XAttribute("date", String.Format("{0}", summaryAttribute.Key.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture))),
                        new XAttribute("total-sum", String.Format("{0:C3}", summaryAttribute.Value.ToString(CultureInfo.InvariantCulture))));

                    currentVendor.Add(currentVendorSummary);
                }

                rootElement.Add(currentVendor);
            }

            Console.WriteLine(rootElement);
            rootElement.Save("../../sales-report.xml");

            Console.WriteLine("You successfully created file.");
        }
    }
}
