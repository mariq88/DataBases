using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SuperMarketInfo.Model;
using System.Data;

namespace ConvertToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GeneratePdf();
        }
        public static void GeneratePdf()
        {
            

            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            StringBuilder sb = new StringBuilder();
            PdfWriter pdf = PdfWriter.GetInstance(document, new FileStream(@"ConvertToPdfTest.pdf", FileMode.Create));
            document.Open();
            SupermarketInformationEntities1 dbtable = new SupermarketInformationEntities1();

            var result = from r in dbtable.Reports
                         join p in dbtable.Products on r.ProductID equals p.ID
                         group r by new { r.ReportDate, p.ProductName, r.Quantity, r.UnitPrice, r.Supermarket, r.Sum } into newObj
                         orderby newObj.Key.ReportDate
                         select new { Date = newObj.Key.ReportDate, Product = newObj.Key.ProductName, Quantity = newObj.Key.Quantity, UnitPrice = newObj.Key.UnitPrice, Location = newObj.Key.Supermarket, Sum = newObj.Key.Sum };
            PdfPTable table = new PdfPTable(6);
            Dictionary<DateTime, List<object>> objects = new Dictionary<DateTime, List<object>>();

            //var reportSalesbyDays =
            //           from sale in dbtable.Sales
            //           join sd in sqlServerContext.SalesDetails
            //           on sale.Id equals sd.SalesId
            //           group sd by new { sale.Date } into d
            //           select new
            //           {
            //               dateSale = d.Key,
            //               sumDay = d.Sum(x => x.Quantity * x.UnitPrice)
            //           };
           
            foreach (var item in result)
            {
                PdfPCell date = new PdfPCell(new Phrase(item.Date.ToString()));
                date.Colspan = 6;
              

                if (objects.ContainsKey(item.Date))
                {

                    table.AddCell(item.Product);
                    table.AddCell(item.Quantity.ToString());
                    table.AddCell(item.UnitPrice.ToString());
                    table.AddCell(item.Location);
                    table.AddCell(item.Sum.ToString());

                    //objects[item.Date].Add(new { Product = item.Product, Quantity = item.Quantity, UnitPrice = item.UnitPrice, Location = item.Location, Sum = item.Sum });
                }
                else
                {
                    objects.Add(item.Date, new List<object>() { new { Product = item.Product, Quantity = item.Quantity, UnitPrice = item.UnitPrice, Location = item.Location, Sum = item.Sum } });
                }
                //PdfPCell sum = new PdfPCell(new Phrase(item.Date.ToString()));

                table.AddCell(date);

                //PdfPCell totalSum = new PdfPCell(new Phrase(sums[index].ToString()));
                //totalSum.Colspan = 6;
                //table.AddCell(totalSum);
                //index++;
            }

            //var distinctDates = (from r in dbtable.Reports select r.ReportDate).Distinct();
            //foreach (var d in distinctDates)
            //{
            //    var sum = (from r in dbtable.Reports where r.ReportDate == d select r.Sum).Sum();
            //    //Console.WriteLine(sum);

            //    PdfPCell totalSum = new PdfPCell(new Phrase(sum.ToString()));
            //    totalSum.Colspan = 6;
            //    table.AddCell(totalSum);
            //}
            //SupermarketInformationSupermarketInformationEntities dbtable = new SupermarketInformationSupermarketInformationEntities();
            //TelerikAcademyEntities dbtable = new TelerikAcademyEntities();

            //dbtable.Reports.ToList().ForEach(r =>
            //{
            //    table.AddCell(r.Quantity.ToString());
            //    table.AddCell(r.UnitPrice.ToString());
            //    table.AddCell(r.Supermarket.ToString());
            //    table.AddCell(r.Sum.ToString());
            //    table.AddCell(r.ProductID.ToString());

            //});
            //Paragraph p = new Paragraph("Just testing the iTextShar.dll library!!!!!");
            //Paragraph paragraph = new Paragraph(table);
            document.Add(table);
            document.Close();


        }
        //public static void GeneratePdf(TelerikAcademyEntities db)
        //{
        //    Document document = new Document();
        //    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"C:\Users\maria\Desktop\DB\TeamWorkProjectTest\ConvertToPdfTest.pdf", FileMode.Create));
        //    document.Open();
        //    iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);


        //    //PdfPTable table = new PdfPTable(3);
        //    //PdfPRow row = null;
        //    //float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f };
        //    PdfPTable table = new PdfPTable(3);
        //    PdfPRow row = null;
        //    float[] widths = new float[] { 4f, 4f, 4f };

        //    table.SetWidths(widths);

        //    table.WidthPercentage = 100;
        //    int iCol = 0;
        //    string colname = "";
        //    PdfPCell cell = new PdfPCell();
        //    document.NewPage();

        //    cell.Colspan = 5;

        //    //foreach (DataColumn c in dt.Columns)
        //    //{

        //    //    table.AddCell(new Phrase(c.ColumnName, font5));
        //    //}

        //    db.Projects.ToList().ForEach(p =>
        //    {
        //        p.Description.ToList();
        //        p.Employees.ToList();
        //        p.Name.ToList();


        //    });

        //    document.Add(table);
        //    document.Close();
        //}

    }
}
