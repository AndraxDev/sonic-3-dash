using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.actors
{
    public interface ISwitchable
    {
        void Toggle();
        void TurnOn();
        void TurnOff();
        bool IsOn();
    }
}
