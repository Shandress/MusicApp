using System;
using System.Collections.Generic;
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
        string Title { get; set; }
        ushort ReleaseDate { get; set; }
        List<Song> Songs { get; set; }

        /// <summary>
        /// Creates an Album intance with default parameters.
        /// </summary>
        public Album()
        {
            Title = string.Empty;
            ReleaseDate = 0;
            Songs = new List<Song>();
        }

        /// <summary>
        /// Creates an Album intance with given parameters.
        /// </summary>
        public Album(string title, ushort year, List<Song> songs)
        {
            Title = title;
            ReleaseDate = year;
            Songs = new List<Song>(songs);
        }

    }
}
