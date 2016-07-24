using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Data.Parsing;
using HtmlAgilityPack;

namespace MusicApp
{
    class Test
    {
        public static void TestStuff()
        {
            string url = @"https://musicmp3.ru/artist_xandria__album_sacrificium.html#.V5IwqEZ9600";
            url = @"https://musicmp3.ru/artist_myrath.html";
            url = @"https://musicmp3.ru/artist_arch-enemy.html";
            HtmlWeb w = new HtmlWeb();
            HtmlDocument doc = w.Load(url);
            HtmlNode albumNode = doc.DocumentNode
                .SelectSingleNode("//div[@class='album_report'][1]");
            var x = HtmlToObjects.ParseArtist(url);
        }
    }
}
