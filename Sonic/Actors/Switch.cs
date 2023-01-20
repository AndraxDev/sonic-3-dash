using Sonic.actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class Switch : AbstractSwitchable, ISwitchable
    {
        protected Switch(int x, int y) : base(x, y)
        {
        }
    }
}
