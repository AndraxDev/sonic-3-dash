using Sonic.actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class Finish : AbstractActor, IInteractible
    {
        private Player player;
        private Animation animation;
        private bool animationStarted = false;
        public Finish(int x, int y) {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/finish.png", 48, 48);
            animation.SetLooping(false);
            this.SetAnimation(animation);
            this.GetAnimation().Stop();
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (IntersectsWithActor(player)) {
                if (!animationStarted)
                {
                    animationStarted = true;
                    this.GetAnimation().Start();
                    // animation.SetCurrentFrame(4);
                }

                // TODO: Finish the game
                // player.RemovedFromWorld();
                player.SetState(new PlayerWonState());
            }
        }
    }
}
