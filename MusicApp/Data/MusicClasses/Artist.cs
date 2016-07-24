using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.MusicClasses
{
    /// <summary>
    /// Represents a musical band or an artist.
    /// </summary>
    class Artist
    {
        /// <summary>
        /// Band's title is unique.
        /// </summary>
        public string Title { get; set; }
        public ushort FoundationYear { get; set; }
        public string Biography { get; set; }
        public List<Album> Discography { get; set; }
        public Image Image { get; set; }
        public List<string> Styles { get; set; }

        /// <summary>
        /// Creates a new Artist instance with default values.
        /// </summary>
        public Artist()
        {
            Title = string.Empty;
            FoundationYear = 0;
            Biography = string.Empty;
            Discography = new List<Album>();
            Image = new Bitmap(10, 10);
            Styles = new List<string>();
        }

        /// <summary>
        /// Creates an Artist intance with giver parameters.
        /// </summary>
        public Artist(string title, ushort year, string bio, List<Album> albums)
        {
            Title = title;
            FoundationYear = year;
            Biography = bio;
            Discography = new List<Album>(albums);
        }


    }
}
