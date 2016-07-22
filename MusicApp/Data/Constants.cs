using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data
{
    class Constants
    {
        public static class XPath
        {
            public static string SongXpath = "./td[@class='song__name']div[@class='title_td_wrap']/span[@itemprop='name']";
            public static string AlbumTitleXpath = "//div[@class='main_cell']" +
                "/div[@class='page_title  page_title--two-lined']/h1";
            public static string SongsXpath = "//div[@class='content  main_cell']//tr[@class='song']";
        }
    }
}
