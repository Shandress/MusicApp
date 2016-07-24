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

        public static Artist ParseArtist(string url)
        {
            HtmlWeb w = new HtmlWeb();
            HtmlDocument doc = w.Load(url);
            HtmlNode root = doc.DocumentNode;

            IEnumerable<HtmlNode> sections = root.SelectNodes(Constants.XPath.Discography);
            
            

            Artist artist = new Artist();
            artist.Title = root.SelectSingleNode(Constants.XPath.ArtistTitle).InnerText;
            //artist.FoundationYear = 


            foreach(HtmlNode section in sections)
            {
                artist.Discography.AddRange(ProcessAlbums(section));
            }

            GetArtistInfo(ref artist, root);

            return artist;
        }

        private static void GetArtistInfo(ref Artist artist, HtmlNode infoTag)
        {
            HtmlNode infoNode = infoTag.SelectSingleNode(Constants.XPath.ArtistInfo);
            HtmlNode artistPictureNode = infoNode.SelectSingleNode(Constants.XPath.ArtistImage);
            GetTextInfo(ref artist, infoNode);


        }

        private static void GetTextInfo(ref Artist artist, HtmlNode infoTag)
        {
            IEnumerable<HtmlNode> nodes = infoTag.SelectNodes("./li");
            Dictionary<string, string[]> rows = new Dictionary<string, string[]>();

            foreach(HtmlNode node in nodes)
            {
                string[] line = node.InnerText.Split(':');
                if(line[0].Equals("Website"))
                {
                    continue;
                }
                rows.Add(line[0], line[1].Split(','));  
                
            }
            if (rows.ContainsKey(Constants.FoundationYear))
            {
                artist.FoundationYear = ushort.Parse(rows[Constants.FoundationYear][0]);
            }
            if (rows.ContainsKey(Constants.Genres))
            {
                artist.Styles.AddRange(rows[Constants.Genres]);
            }
        }



        private static List<Album> ProcessAlbums(HtmlNode section)
        {
            List<Album> res = new List<Album>();
            string type = GetAlbumType(section.SelectSingleNode(Constants.XPath.AlbumType));
            IEnumerable<HtmlNode> albumTags = section.SelectNodes(Constants.XPath.Albums);
            foreach(HtmlNode albumTag in albumTags)
            {
                res.Add(CreateAlbum(albumTag, type));
            }
            return res;
        }

        private static string GetAlbumType(HtmlNode typeTag)
        {
            string type = typeTag.InnerText;
            if(type.EndsWith("s"))
            {
                type = type.Remove(type.Length - 1);
            }
            return type;
        }

        /// <summary>
        /// Processes the album tag and creates an album with all necessary 
        /// information i.e. title, type, date, picture, songs.
        /// </summary>
        /// <param name="albumTag"></param>
        /// <returns></returns>
        private static Album CreateAlbum(HtmlNode albumTag, string type)
        {
            string baseUrl = @"https://musicmp3.ru";
            string link = string.Empty;
            Album album = new Album();
            album.Title = albumTag.SelectSingleNode(Constants.XPath.AlbumTitle).InnerText;
            album.Type = type;
            album.ReleaseDate = ushort.Parse(albumTag.SelectSingleNode(Constants.XPath.AlbumYear).InnerText);
            album.Styles.AddRange(albumTag
                .SelectNodes(Constants.XPath.AlbumGenres)
                .Select(n => n.InnerText));

            HtmlNode node = albumTag.SelectSingleNode(Constants.XPath.AlbumLink);
            HtmlAttribute attribute = node.Attributes["href"];
            if(attribute != null)
            {
                link = attribute.Value;
                album.Songs = ParseSongs(baseUrl + link);

                HtmlWeb w = new HtmlWeb();
                HtmlDocument doc = w.Load(baseUrl + link);
                HtmlNode imgNode = doc.DocumentNode
                    .SelectSingleNode(Constants.XPath.AlbumImg);
                album.Cover = GetImage(imgNode, type);
            }

            return album;
            
        }

        /// <summary>
        /// Processes a link to an album page and gets all songs the album contains.
        /// </summary>
        private static List<Song> ParseSongs(string url)
        {
            List<Song> songs = new List<Song>();
            HtmlWeb w = new HtmlWeb();
            HtmlDocument doc = w.Load(url);
            HtmlNode root = doc.DocumentNode;
            return root
                .SelectNodes(Constants.XPath.Songs)
                .Select(node => new Song(node.InnerText))
                .ToList();
        }

        /// <summary>
        /// Gets an image from the iage tag and saves it on disk if it exists or ImageNotFound picture otherwise.
        /// </summary>
        private static Image GetImage(HtmlNode imageTag, string albumType)
        {
            HtmlAttribute attribute = imageTag.Attributes["src"];

            string src = string.Empty;
            string tag = Constants.Unknown;
            if (attribute != null)
            {
                src = attribute.Value;
                tag = imageTag.Attributes["alt"].Value + "," + albumType;
            }
            if(src != string.Empty)
            {
                Image cover = Utility.DownloadImage(src);
                cover.Tag = tag;
                Image copy = cover.Clone() as Image;
                Utility.SaveImage(cover);
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
            string title = songTag.SelectSingleNode(Constants.XPath.Song).InnerText;
            return new Song(title);
        }
    }
}
