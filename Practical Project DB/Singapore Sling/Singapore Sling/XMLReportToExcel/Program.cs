using System;
using MongoDB.Bson;
using MongoDB.Driver;
using GeneratingExcelReports;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization;
using System.Data.Entity;
using SuperMarketInfo.Model;


namespace GeneratingExcelReports
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<List<Product>, List<Sale>> entites = ReadFromMongoDB();

            GenerateToExcel(entites);
        }

        static Tuple<List<Product>, List<Sale>> ReadFromMongoDB()
        {
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoServer server = new MongoServer(settings);
            MongoDatabase database = server.GetDatabase("supermarketinfo");

            List<Product> productReports = new List<Product>();
            List<Sale> saleReporst = new List<Sale>();

            var sales = database.GetCollection("sales").FindAll();

            var products = database.GetCollection("products").FindAll();

            foreach (var product in products)
            {
                Product currentProduct = BsonSerializer.Deserialize<Product>(product.AsBsonDocument);

                productReports.Add(currentProduct);
            }

            foreach (var sale in sales)
            {
                Sale currentSale = BsonSerializer.Deserialize<Sale>(sale.AsBsonDocument);

                saleReporst.Add(currentSale);
            }
            Console.WriteLine();

            return new Tuple<List<Product>, List<Sale>>(productReports, saleReporst);

        }

        static void GenerateToExcel(Tuple<List<Product>, List<Sale>> inputEntites)
        {
            SupermarketInformationEntities1 DB = new SupermarketInformationEntities1();

            using(DB)
            {
                
            }
        }

        


        public static object List { get; set; }
    }
}
