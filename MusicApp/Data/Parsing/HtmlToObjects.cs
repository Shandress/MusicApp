using HtmlAgilityPack;
using MusicApp.Data.MusicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.Parsing
{
    /// <summary>
    /// Used to 
    /// </summary>
    class HtmlToObjects
    {
        public static Album ParseAlbum(string url)
        {

            throw new NotImplementedException();

        }

        /// <summary>
        /// Processes a link to an album page and gets all songs the album contains.
        /// </summary>
        public static IEnumerable<Song> ParseSongs(string url)
        {
            List<Song> songs = new List<Song>();
            HtmlWeb w = new HtmlWeb();
            HtmlDocument doc = w.Load(url);
            HtmlNode root = doc.DocumentNode;
            IEnumerable<HtmlNode> songTags = root.SelectNodes(Constants.XPath.SongsXpath);

            foreach(HtmlNode node in songTags)
            {
                songs.Add(ParseSong(node));
            }

            return songs;
        }
        /// <summary>
        /// Processes an HTML tag containing info and creates a Song object. 
        /// </summary>
        private static Song ParseSong(HtmlNode songTag)
        {
            string SongXpath = "./td[@class='song__name']/div[@class='title_td_wrap']/span[@itemprop='name']";
            string title = songTag.SelectSingleNode(/*Constants.XPath.SongXpath*/SongXpath).InnerText;
            return new Song(title);
        }
    }
}
