using Sonic.actors;
using Sonic.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Items
{
    public class Key : AbstractActor, IItem, IInteractible
    {
        private Animation animation;
        private Player player;

        public Key(int x, int y)
        {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/key.png", 32, 32);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (IntersectsWithActor(player))
            {
                this.RemoveFromWorld();
            }
        }
    }
}
