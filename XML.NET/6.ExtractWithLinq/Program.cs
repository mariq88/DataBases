using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

class ExtractSongs
{
    static void Main()
    {
        XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");
        var songs =
            from song in xmlDoc.Descendants("song")
            select new
            {
                Title = song.Element("title").Value,
            };
        Console.WriteLine("Found {0} songs:", songs.Count());
        foreach (var song in songs)
        {
            Console.WriteLine("Song Title {0}", song.Title);
        }
    }
}