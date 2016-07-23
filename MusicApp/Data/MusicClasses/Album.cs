using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.MusicClasses
{
    /// <summary>
    /// Represents a musical album, EP, Single, Compilation etc.
    /// </summary>
    class Album
    {
        public string Title { get; set; }
        public ushort ReleaseDate { get; set; }
        public List<Song> Songs { get; set; }
        public Image Image { get; set; }
        public List<string> Styles { get; set; }

        /// <summary>
        /// Creates an Album intance with default parameters.
        /// </summary>
        public Album()
        {
            Title = string.Empty;
            ReleaseDate = 0;
            Songs = new List<Song>();
            Image = new Bitmap(10, 10);
            Styles = new List<string>();
        }

        /// <summary>
        /// Creates an Album intance with given parameters.
        /// </summary>
        public Album(string title, ushort year, List<Song> songs, Image image, List<string> styles)
        {
            Title = title;
            ReleaseDate = year;
            Songs = new List<Song>(songs);
            Image = new Bitmap(image);
            Styles = new List<string>(styles);
        }

    }
}
