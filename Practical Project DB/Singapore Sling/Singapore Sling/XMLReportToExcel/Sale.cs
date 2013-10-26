using System;
using System.Collections.Generic;
using MongoDB.Bson;

public class Sale
{
    public BsonObjectId _id { get; set; }
    public string Vendor { get; set; }
    public List<ExpenseModel> Expenses { get; set; }
}

public class ExpenseModel
{
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }
}