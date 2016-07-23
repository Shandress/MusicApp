using HtmlAgilityPack;
using MusicApp.Data.MusicClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicApp.Data.Parsing
{
    /// <summary>
    /// Used to get information about the album.
    /// </summary>
    class HtmlToObjects
    {
        public static Album ParseAlbum(HtmlNode albumTag)
        {
            string baseUrl = @"https://musicmp3.ru";
            string link = string.Empty;
            Album album = new Album();
            album.Title = albumTag.SelectSingleNode(Constants.XPath.AlbumTitleXpath).InnerText;
            album.ReleaseDate = ushort.Parse(albumTag.SelectSingleNode(Constants.XPath.AlbumYearXpath).InnerText);
            album.Styles.AddRange(albumTag
                .SelectNodes(Constants.XPath.AlbumGenresXpath)
                .Select(n => n.InnerText));

            HtmlNode node = albumTag.SelectSingleNode(Constants.XPath.AlbumLinkXpath);
            HtmlAttribute attribute = node.Attributes["href"];
            if(attribute != null)
            {
                link = attribute.Value;
                album.Songs = ParseSongs(baseUrl + link);

                HtmlWeb w = new HtmlWeb();
                HtmlDocument doc = w.Load(baseUrl + link);
                HtmlNode imgNode = doc.DocumentNode
                    .SelectSingleNode(Constants.XPath.AlbumImgXpath);
                album.Image = GetImage(imgNode);
            }

            

            return album;
            
        }

        /// <summary>
        /// Processes a link to an album page and gets all songs the album contains.
        /// </summary>
        public static List<Song> ParseSongs(string url)
        {
            List<Song> songs = new List<Song>();
            HtmlWeb w = new HtmlWeb();
            HtmlDocument doc = w.Load(url);
            HtmlNode root = doc.DocumentNode;
            return root
                .SelectNodes(Constants.XPath.SongsXpath)
                .Select(node => new Song(node.InnerText))
                .ToList();
        }

        /// <summary>
        /// Gets an image from the iage tag and saves it on disk if it exists or ImageNotFound picture otherwise.
        /// </summary>
        public static Image GetImage(HtmlNode imageTag)
        {
            HtmlAttribute attribute = imageTag.Attributes["src"];

            string src = string.Empty;
            string tag = Constants.Unknown;
            if (attribute != null)
            {
                src = attribute.Value;
                tag = imageTag.Attributes["alt"].Value;
            }
            if(src != string.Empty)
            {
                Image cover = Utility.DownloadImage(src);
                cover.Tag = tag;
                Image copy = cover.Clone() as Image;
                Utility.SaveImage(Constants.ImageDir, cover);
                return new Bitmap(copy);
            }
            else
            {
                return Image.FromFile(Constants.ImageDir + "image-not-found.jpg");
            }
        }

        /// <summary>
        /// Processes an HTML tag containing info and creates a Song object. 
        /// </summary>
        private static Song ParseSong(HtmlNode songTag)
        {
            string title = songTag.SelectSingleNode(Constants.XPath.SongXpath).InnerText;
            return new Song(title);
        }
    }
}
