using Sonic.actors;
using Sonic.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Items;

namespace Sonic.Items
{
    public class Emerald : AbstractActor, IItem, IInteractible
    {
        private Animation animation;
        private Player player;
        private Message msg;
        private bool messageShown = false;

        public Emerald(int x, int y) {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/emerald.png", 32, 32);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
            this.msg = new Message("Your energy is too low. You need to collect 100 rings to pick emerald.", 10, 30);
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (IntersectsWithActor(player))
            {
                if (player.GetRingsCount() >= 100)
                {
                    this.RemoveFromWorld();
                }
                else
                {
                    if (!messageShown) {
                        this.GetWorld().AddMessage(msg);
                        this.messageShown = true;
                    }
                }
            }
            else {
                this.GetWorld().RemoveMessage(msg);
                this.messageShown = false;
            }
        }
    }
}
