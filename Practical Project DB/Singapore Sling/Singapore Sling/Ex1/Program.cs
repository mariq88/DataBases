using Ionic.Zip;
using System;
using System.Linq;
using System.IO;
using System.Data.OleDb;
using Telerik.OpenAccess;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using SuperMarketInfo.Model;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Creating DB Schema
            CreateSQLServerSchema();

            // Reading MySQL db with OpenAccess and writhing it to SQL Server with EF
            ReadMySQLAndWriteToSQLServer();

            // Zip, Excel, ADO.NET, SQL Server
            ExtractZipReadExcelAndWriteToSQLServer();

            // Deleting the temp folder
            DeleteTempFolder();

            Console.WriteLine("Done!");
        }

        private static void ExtractZipReadExcelAndWriteToSQLServer()
        {
            string fileName = "../../Sample-Sales-Reports.zip";

            using (ZipFile zip = ZipFile.Read(fileName))
            {
                foreach (var item in zip)
                {
                    if (item.FileName.Substring(item.FileName.Length - 3, 3) == "xls")
                    {
                        ZipEntry entry = zip[item.FileName];

                        // Making temp folder
                        string[] parts;
                        string fullPath;
                        MakeTempFolderAndExtract(item, entry, out parts, out fullPath);

                        // Reading with ADO.NET
                        ReadExcelAndWriteToSQLServer(parts, fullPath);
                    }
                }
            }
        }

        private static void DeleteTempFolder()
        {
            Directory.Delete("../../temp", true);
        }

        private static void MakeTempFolderAndExtract(ZipEntry item, ZipEntry entry, out string[] parts, out string fullPath)
        {
            Directory.CreateDirectory("../../temp");

            parts = item.FileName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string pathName = "../../temp/" + parts[0];
            Directory.CreateDirectory(pathName);

            fullPath = pathName + '/' + parts[1];
            FileStream fs = new FileStream(fullPath, FileMode.Create);
            using (fs)
            {
                entry.Extract(fs);
            }
        }

        private static void ReadExcelAndWriteToSQLServer(string[] parts, string fullPath)
        {
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0; data source=" + fullPath + "; Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
            OleDbConnection dbConn = new OleDbConnection(connStr);

            // Inserting excel data to SQL Server
            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sales$]", dbConn);

                string supermarket = null;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double[] elems = new double[4];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string val = (reader[i] == DBNull.Value) ? "" : (string)reader[i];
                        if (val.Length > 0)
                        {
                            if (reader[1] != DBNull.Value && (string)reader[0] != "ProductID")
                            {
                                double doubleVal;
                                bool isOk = double.TryParse(val, out doubleVal);

                                if (isOk)
                                {
                                    if (i != reader.FieldCount - 1)
                                    {
                                        elems[i] = doubleVal;
                                    }
                                    else
                                    {
                                        elems[i] = doubleVal;
                                        using (SupermarketInformationEntities1 context =
                                            new SupermarketInformationEntities1())
                                        {
                                            SuperMarketInfo.Model.Report report = new SuperMarketInfo.Model.Report()
                                            {
                                                ProductID = (int)elems[0],
                                                Quantity = (int)elems[1],
                                                UnitPrice = (decimal)elems[2],
                                                Sum = (decimal)elems[3],
                                                Supermarket = supermarket,
                                                ReportDate = DateTime.Parse(parts[0])
                                            };

                                            context.Reports.Add(report);
                                            context.SaveChanges();
                                        }
                                    }
                                }
                            }
                            else if (reader[1] == DBNull.Value && (string)reader[0] != "Total sum:")
                            {
                                supermarket = val;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void ReadMySQLAndWriteToSQLServer()
        {
            using (EntitiesModel em = new EntitiesModel())
            {
                var vendors = em.Vendors;
                var measures = em.Measures;
                var products = em.Products;

                using (SupermarketInformationEntities1 context = new SupermarketInformationEntities1())
                {
                    foreach (var vendor in vendors)
                    {
                        SuperMarketInfo.Model.Vendor v = new SuperMarketInfo.Model.Vendor()
                        {
                            VendorName = vendor.VendorName
                        };

                        context.Vendors.Add(v);
                        context.SaveChanges();
                    }

                    foreach (var measure in measures)
                    {
                        SuperMarketInfo.Model.Measure m = new SuperMarketInfo.Model.Measure()
                        {
                            MeasureName = measure.MeasureName,
                        };

                        context.Measures.Add(m);
                        context.SaveChanges();
                    }

                    foreach (var product in products)
                    {
                        SuperMarketInfo.Model.Product p = new SuperMarketInfo.Model.Product()
                        {
                            MeasureID = product.Measures_ID,
                            ProductName = product.ProductName,
                            BasePrice = product.BasePrice,
                            VendorID = product.Vendors_ID
                        };

                        context.Products.Add(p);
                        context.SaveChanges();
                    }
                }
            }
        }

        private static void CreateSQLServerSchema()
        {
            string sqlConnectionString = "Server=.;Database=master;Integrated Security=true";
            FileInfo file = new FileInfo("../../SQL Server Schema.sql");
            string script = file.OpenText().ReadToEnd();

            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
