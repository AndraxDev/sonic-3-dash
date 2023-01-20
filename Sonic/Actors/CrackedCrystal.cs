using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.actors
{
    public class CrackedCrystal : Crystal
    {
        private int maxUses;
        private int uses;
        public CrackedCrystal(int x, int y, int maxUses, IObservable source) : base(x, y, source) {
            this.maxUses = maxUses;
            this.uses = 0;
        }

        public override void TurnOn() { 

        }
    }
}
