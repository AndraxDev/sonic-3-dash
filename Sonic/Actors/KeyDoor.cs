using Sonic.actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    internal class KeyDoor : Door, IDoor, IInteractible
    {
        private Animation animation;
        private Animation closed;
        private Animation opened;
        private Player player;

        public KeyDoor(int x, int y, bool state) : base(x, y, state)
        {
            closed = new Animation("resources/sprites/key_door_closed.png", 32, 64);
            opened = new Animation("resources/sprites/key_door_opened.png", 32, 64);
            LoadAnimation();
        }

        public void LoadAnimation()
        {
            if (IsClosed()) this.SetAnimation(closed);
            else this.SetAnimation(opened);
            this.GetAnimation().Start();
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            LoadAnimation();

            if (IntersectsWithActor(player) && IsClosed())
            {
                bool keyIsPicked = true;
                foreach (AbstractActor actor in player.GetWorld().GetActors())
                {
                    if (actor.GetName() == "Key") keyIsPicked = false;
                }

                if (keyIsPicked) Open();
                else player.SetPosition(player.GetX() - (int)player.GetSpeedStrategy().GetSpeed(player.GetSpeed()), player.GetY());
            }
        }
    }
}
