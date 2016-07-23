using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Exceptions
{
    class MusicAppException : Exception
    {
        public MusicAppException(string msg) : base(msg) { }
    }
}
