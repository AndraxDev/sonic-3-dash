using Sonic.actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class VJumper2 : Jumper
    {
        public VJumper2(Player player, int x, int y) : base(player, x, y, new Animation("resources/sprites/vjumper2.png", 32, 32))
        {
            base.SetJumpHeight(40);
        }
    }
}
