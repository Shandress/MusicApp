﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.MusicClasses
{

    class Song
    {
        public string Title { get; set; }

        // In time there will be more info....


        public Song()
        {
            Title = string.Empty;
        }

        public Song(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
