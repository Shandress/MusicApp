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
        public static string FoundationYear = "Date Of Birth";
        public static string Genres = "Genre(s)";

        public static class XPath
        {
            public static string Song = "./td[@class='song__name']/div[@class='title_td_wrap']/span[@itemprop='name']";
            public static string Songs = "//div[@class='content  main_cell']//tr[@class='song']/td[@class='song__name']";
            public static string AlbumTitle = "./h5[@class='album_report__heading']";
            public static string AlbumYear = "./div[@class='album_report__second_line']/span[@class='album_report__date']";
            public static string AlbumGenres = "./ul[@class='tags tags--genres unstyled']/li";
            public static string AlbumLink = "./h5[@class='album_report__heading']/a";
            public static string AlbumImg = "//img[@class='art_wrap__img']";
            public static string ArtistTitle = "//div[@class='row  clearfix']/div[@class='main_cell']/" +
                "div[@class='page_title  page_title--one-lined']/h1[@class='page_title__h1']";
            public static string Discography = "//div[@class='page_section']";
            public static string AlbumType = "./h2[@class='page_subtitle  marked_left']";
            public static string Albums = "./div[@class='clearfix']/div[@class='album_report']";
            public static string ArtistInfo = "//ul[@class='infolist  marked_left  unstyled']";
            public static string ArtistImage = "//div[@class='art_wrap']";
            
        }
    }
}
