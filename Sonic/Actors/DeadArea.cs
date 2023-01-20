using Sonic.actors;
using Merlin2d.Game;

namespace Sonic.Actors
{
    public class DeadArea : AbstractActor, IInteractible
    {
        private Player player;
        private Animation animation;

        public DeadArea(int x, int y)
        {
            this.animation = new Animation("resources/sprites/dead_area.png", 32, 32);
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
            if (player.GetState() is PlayerLivingState)
            {
                if (this.IntersectsWithActor(this.player))
                {
                    this.player.Die();
                }
            }
        }
    }
}
