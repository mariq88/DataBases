using System;
using System.Linq;
using System.Xml;

namespace DeleteAlbums
{
    class DeletAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (decimal.Parse(node["price"].InnerText) > 20)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }
            }
        }
    }
}