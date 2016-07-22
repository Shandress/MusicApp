using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Data.Parsing;

namespace MusicApp
{
    class Test
    {
        public static void TestStuff()
        {
            string url = "https://musicmp3.ru/artist_xandria__album_sacrificium.html#.V5IwqEZ9600";
            var x = HtmlToObjects.ParseSongs(url);
        }
    }
}
