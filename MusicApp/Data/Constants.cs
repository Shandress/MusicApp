using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data
{
    class Constants
    {
        public static string ImageDir = "./Images/";
        public static string Unknown = "N/A";

        public static class XPath
        {
            public static string SongXpath = "./td[@class='song__name']/div[@class='title_td_wrap']/span[@itemprop='name']";
            public static string SongsXpath = "//div[@class='content  main_cell']//tr[@class='song']/td[@class='song__name']";
            public static string AlbumTitleXpath = "./h5[@class='album_report__heading']";
            public static string AlbumYearXpath = "./div[@class='album_report__second_line']/span[@class='album_report__date']";
            public static string AlbumGenresXpath = "./ul[@class='tags tags--genres unstyled']/li";
            public static string AlbumLinkXpath = "./h5[@class='album_report__heading']/a";
            public static string AlbumImgXpath = "//img[@class='art_wrap__img']";
        }
    }
}
