using Sonic.actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class Door : AbstractActor, IDoor
    {
        private bool state;
        public Door(int x, int y, bool state) { 
            this.SetPosition(x, y);
            this.state = state;
        }

        public void Open() {
            this.state = false;
        }

        public void Close() {
            this.state = true;
        }

        public bool IsClosed() {
            return this.state;
        }

        public void SetClosed(bool state) { 
            this.state = state;
        }

        public override void Update()
        {
            
        }
    }
}
