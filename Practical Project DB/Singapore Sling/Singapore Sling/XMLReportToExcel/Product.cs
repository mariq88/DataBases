using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace GeneratingExcelReports
{
    public class Product
    {
        public BsonObjectId _id { get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string VendorName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalIncomes { get; set; }
    }
}
