using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Exceptions
{
    class InternetAccessException : MusicAppException
    {
        public InternetAccessException(string msg) : base(msg) { }
    }
}
