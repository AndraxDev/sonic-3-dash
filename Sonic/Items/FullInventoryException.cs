using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Items
{
    public class FullInventoryException : Exception
    {
        public FullInventoryException() : base() { }

        public FullInventoryException(string message) : base(message) { }
    }
}
