using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Xml;
using SuperMarketInfo.Model;
using System.Linq;

namespace SingaporeSlingTeamProject
{
    public class Sale
    {
        public Sale()
        {
            this.Expenses = new List<ExpenseModel>();
        }

        public string Vendor { get; set; }
        public List<ExpenseModel> Expenses { get; set; }
    }

    public class ExpenseModel
    {
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
    }


    public class XMLData
    {
        public static void LoadDataIntoMongoDB(string xmlFilePath)
        {
            var allSales = ParseSalesXML(xmlFilePath);

            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoServer server = new MongoServer(settings);
            var database = server.GetDatabase("supermarketinfo");
            var sales = database.GetCollection("sales");

            foreach (var sale in allSales)
            {
                sales.Insert(sale.ToBsonDocument());
            }
        }

        public static void LoadDataIntoSQLServer(string xmlFilePath)
        {
            var allSales = ParseSalesXML(xmlFilePath);

            using (SupermarketInformationEntities1 entities = new SupermarketInformationEntities1())
            {
                foreach (var sale in allSales)
                {
                    var vendor = entities.Vendors.FirstOrDefault(x => x.VendorName == sale.Vendor);
                    if (vendor == null)
                    {
                        throw new InvalidOperationException("No such vendor in the database.");
                    }

                    int vendorId = vendor.ID;
                    foreach (var expense in sale.Expenses)
                    {
                        entities.Expenses.Add(new Expense() { Cost = expense.Cost, Date = expense.Date, VendorID = vendorId });
                    }
                }

                entities.SaveChanges();
            }
        }

        private static List<Sale> ParseSalesXML(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            List<Sale> allSales = new List<Sale>();
            XmlNodeList sales = xmlDoc.SelectNodes("/sales/sale");

            foreach (XmlNode sale in sales)
            {
                string vendor = sale.Attributes["vendor"].Value;
                Sale saleEntry = new Sale();
                saleEntry.Vendor = vendor;

                XmlNodeList expenses = sale.SelectNodes("expenses");
                foreach (XmlNode expense in expenses)
                {
                    var date = ParseDate(expense.Attributes["month"].Value);
                    var expenseCost = decimal.Parse(expense.InnerText, CultureInfo.InvariantCulture);
                    saleEntry.Expenses.Add(new ExpenseModel() { Cost = expenseCost, Date = date });
                }

                allSales.Add(saleEntry);
            }

            return allSales;
        }

        private static DateTime ParseDate(string date)
        {
            string[] tokens = date.Split('-');
            int month = -1;
            switch (tokens[0])
            {
                case "Jan":
                    month = 1;
                    break;
                case "Feb":
                    month = 2;
                    break;
                case "Mar":
                    month = 3;
                    break;
                case "Apr":
                    month = 4;
                    break;
                case "May":
                    month = 5;
                    break;
                case "Jun":
                    month = 6;
                    break;
                case "Jul":
                    month = 7;
                    break;
                case "Aug":
                    month = 8;
                    break;
                case "Sep":
                    month = 9;
                    break;
                case "Oct":
                    month = 10;
                    break;
                case "Nov":
                    month = 11;
                    break;
                case "Dec":
                    month = 12;
                    break;
            }

            int year = int.Parse(tokens[1]);
            DateTime parsed = new DateTime(year, month, 1);
            return parsed;
        }
    }
}
