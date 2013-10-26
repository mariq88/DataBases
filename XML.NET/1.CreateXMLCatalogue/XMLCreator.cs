using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace _1.CreateXMLCatalogue
{
    class XMLCreator
    {
        static void Main(string[] args)
        {
            string filename = "../../catalogue.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(filename, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("catalogue");
                writer.WriteAttributeString("name", "Song Catalogue");

                WriteAlbum(writer, "Ritchie Blackmore's Rainbow", "Rainbow", "1975", "Polydor", "12$", "The Man on the Silver Mountain");
                WriteAlbum(writer, "Appetite for Destruction", "Guns'n'Roses", "1987", "Mike Clink", "12.5$", "Welcome To The Jungle");
                //WriteSong(writer, "Welcome To The Jungle", "3.50");
                writer.WriteEndDocument();
            }
            Console.WriteLine("Document {0} created", filename);
        }
        private static void WriteAlbum(XmlWriter writer, string name, string artist, string year, string producer, string price, string song)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteElementString("year", year);
            writer.WriteElementString("producer", producer);
            writer.WriteElementString("price", price);
            writer.WriteElementString("song", song);
            writer.WriteEndElement();
        }
    }
}
