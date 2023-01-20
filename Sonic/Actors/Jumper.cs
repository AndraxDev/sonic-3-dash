using Sonic.actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class Jumper : AbstractActor, IInteractible
    {
        private Player player;
        
        private bool jumpState = false;
        private int jumpHeight = 15;
        private Animation animation;
        
        public Jumper(Player player, int x, int y, Animation animation) { 
            this.player = player;
            this.animation = animation;
            this.SetAnimation(animation);
            this.GetAnimation().Stop();
            this.GetAnimation().SetCurrentFrame(0);
            this.GetAnimation().SetLooping(false);
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void SetJumpHeight(int height) {
            this.jumpHeight = height;
        }

        public override void Update()
        {
            if (player.GetState() is PlayerLivingState)
            {
                if (this.IntersectsWithActor(this.player) && !jumpState)
                {
                    jumpState = true;
                    this.GetAnimation().SetCurrentFrame(0);
                    this.GetAnimation().Start();
                    this.player.Jump(jumpHeight);
                }
                else
                {
                    jumpState = false;
                }
            }
        }
    }
}
