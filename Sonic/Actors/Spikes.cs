using Sonic.actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class Spikes : AbstractActor, IInteractible
    {
        private Player player;
        private Animation animation;

        public Spikes(int x, int y)
        {
            this.animation = new Animation("resources/sprites/spikes.png", 32, 32);
            this.SetAnimation(animation);
            this.GetAnimation().Start();

            this.SetPosition(x, y);
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (player.GetState() is PlayerLivingState && !player.GetResistance())
            {
                if (this.StandsOn(this.player))
                {
                    this.player.ResetJumping();
                    this.player.Damage();
                }
            }
        }
    }
}
