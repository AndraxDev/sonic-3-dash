using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class InvalidBoosterException : Exception
    {
        public InvalidBoosterException() : base() { }

        public InvalidBoosterException(string message) : base(message) { }
    }
}
