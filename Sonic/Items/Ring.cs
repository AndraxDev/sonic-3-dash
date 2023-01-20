using Sonic.actors;
using Sonic.Actors;
using Sonic.commands;
using Merlin2d.Game;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Items
{
    public class Ring : AbstractActor, IInteractible, IItem
    {
        private Player player;
        private Animation animation;
        private int a = 300;
        public Ring(int x, int y)
        {
            animation = new Animation("resources/sprites/ring.png", 16, 16);
            SetAnimation(animation);
            GetAnimation().Start();

            SetPosition(x, y);
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (player.GetState() is PlayerLivingState)
            {
                if (IntersectsWithActor(player))
                {
                    player.SetRingsCount(player.GetRingsCount() + 1);
                    RemoveFromWorld();
                }
            }


            if (IsAffectedByPhysics())
            {
                if (a <= 0) RemoveFromWorld();
                a--;
            }
        }
    }
}
