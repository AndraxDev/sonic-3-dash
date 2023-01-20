using Sonic.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.actors
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        void SetJumpStrategy(IJumpStrategy strategy);
        double GetSpeed(double speed);

        bool GetResistance();

        void SetResistance(bool resistance);
    }
}
