using System;
using System.Xml;

class ExtractSongs
{
    static void Main()
    {
        using (XmlReader reader = XmlReader.Create("../../../catalogue.xml"))
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "title"))
                {
                    Console.WriteLine(reader.ReadElementString());
                }
            }
        }
    }
}