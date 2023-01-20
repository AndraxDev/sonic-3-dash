using Sonic.actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    internal class PressurePlate : AbstractActor
    {
        private bool pressed = false;
        private Door door;

        public PressurePlate(Door door) {
            this.door = door;
        }

        public bool IsPressed() { 
            return this.pressed;
        }

        public void Press(bool press) {
            this.pressed = press;
        }

        public override void Update()
        {
            if (pressed)
            {
                door.Open();
            }
            else { 
                door.Close();
            }
        }
    }
}
