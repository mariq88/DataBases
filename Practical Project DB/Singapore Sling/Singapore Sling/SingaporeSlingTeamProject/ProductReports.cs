using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketInfo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;

namespace SingaporeSlingTeamProject
{
    public class ProductReport
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string VendorName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalIncomes { get; set; }
    }

    public class ProductReports
    {
        private static SupermarketInformationEntities1 entities = new SupermarketInformationEntities1();

        public static IQueryable<ProductReport> GetProductReports()
        {
            var reports = entities.Reports.Join(entities.Products,
                    report => report.ProductID,
                    product => product.ID,
                    (report, product) => new { Report = report, Product = product })
                    .Join(entities.Vendors,
                    report => report.Product.VendorID,
                    vendor => vendor.ID,
                    (report, vendor) => new { Report = report, Vendor = vendor })
                        .GroupBy(x => x.Report.Report.ProductID).Select(x => new ProductReport()
                        {
                            ProductID = x.FirstOrDefault().Report.Report.ProductID,
                            ProductName = x.FirstOrDefault().Report.Product.ProductName,
                            VendorName = x.FirstOrDefault().Vendor.VendorName,
                            TotalQuantitySold = x.Sum(y => y.Report.Report.Quantity),
                            TotalIncomes = x.Sum(y => y.Report.Report.Sum)
                        });


            return reports;
        }

        public static void SaveReportsToMongoDB()
        {
            var productReports = GetProductReports();
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoServer server = new MongoServer(settings);
            var database = server.GetDatabase("supermarketinfo");
            var products = database.GetCollection("products");

            foreach (var report in productReports)
            {
                products.Insert(report.ToBsonDocument());
            }
        }

        public static void SaveReportsToFileSystem()
        {
            var productReports = GetProductReports();
            System.IO.Directory.CreateDirectory("../../Product-Reports");

            foreach (var report in productReports)
            {
                using (StreamWriter writer = new StreamWriter("../../Product-Reports/" + report.ProductID.ToString() + ".json"))
                {
                    writer.WriteLine(report.ToJson());
                }
            }
        }
    }
}
