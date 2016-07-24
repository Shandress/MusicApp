using System.Collections.Generic;
using System.Drawing;

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
        public Image Cover { get; set; }
        public List<string> Styles { get; set; }

        /// <summary>
        /// Album's type: Studio album, Compilation, Single etc.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Creates an Album intance with default parameters.
        /// </summary>
        public Album()
        {
            Title = string.Empty;
            ReleaseDate = 0;
            Songs = new List<Song>();
            Cover = new Bitmap(10, 10);
            Styles = new List<string>();
            Type = string.Empty;
        }

        /// <summary>
        /// Creates an Album intance with given parameters.
        /// </summary>
        public Album(string title, ushort year, List<Song> songs, Image image, List<string> styles, string type)
        {
            Title = title;
            ReleaseDate = year;
            Songs = new List<Song>(songs);
            Cover = new Bitmap(image);
            Styles = new List<string>(styles);
        }

        public override string ToString()
        {
            return Title + ", " + ReleaseDate;
        }

    }
}
