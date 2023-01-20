using Sonic.actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class Shima : AbstractActor, IInteractible
    {
        private Player player;
        private Animation animation;
        private int move;
        private int direction = 1;

        public Shima(int x, int y, int direction) {
            this.animation = new Animation("resources/sprites/shima.png", 64, 32);
            this.SetAnimation(animation);
            this.GetAnimation().Start();

            this.SetPosition(x, y);
            this.direction = direction;
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (IntersectsWithActor(player)) {
                if (move <= 100)
                {
                    if (direction == 1)
                    {
                        player.SetPosition(player.GetX(), player.GetY() - (player.GetY() + 48 - this.GetY()));
                    }
                    else {
                        player.SetPosition(player.GetX(), player.GetY() - (player.GetY() + 40 - this.GetY()));
                    }
                }
                else {
                    if (direction == 1)
                    {
                        player.SetPosition(player.GetX(), player.GetY() - (player.GetY() + 40 - this.GetY()));
                    }
                    else
                    {
                        player.SetPosition(player.GetX(), player.GetY() - (player.GetY() + 48 - this.GetY()));
                    }
                }
                player.ResetJumping();
            }

            if (move <= 100)
            {
                this.SetPosition(GetX(), GetY() - 2 * direction);
            }
            else {
                if (move <= 200)
                {
                    this.SetPosition(GetX(), GetY() + 2 * direction);
                }
                else {
                    move = 0;
                }
            }

            move++;
        }
    }
}
