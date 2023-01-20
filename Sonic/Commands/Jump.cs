using Sonic.actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Sonic.Commands
{
    public class Jump : ICommand
    {
        private IActor actor;
        private double step;
        private int isJumping = 0;
        private int jumpingMaxHeight = 0;
        private int currentJumpingHeight = 0;

        public Jump(IMovable movable, double step, int maxHeight)
        {
            if (!(movable is IActor))
            {
                throw new ArgumentException("'movable' has invalid type.");
            }

            this.actor = (IActor)movable;
            this.step = step;
            this.jumpingMaxHeight = maxHeight;
        }

        public void SetCurrentHeight(int height) {
            this.currentJumpingHeight = height;
        }

        public void SetMaxHeight(int height) {
            this.jumpingMaxHeight = height;
        }

        public void SetJumping(int jumping) {
            this.isJumping = jumping;
        }

        public int IsJumping() {
            return this.isJumping;
        }

        public void Execute()
        {
            int oldY = this.actor.GetY();

            if (IsJumping() == 1)
            {
                int newY = (int)Math.Round(this.actor.GetY() - step);
                this.actor.SetPosition(this.actor.GetX(), newY);
                this.currentJumpingHeight++;
            }

            if (IsJumping() == 2)
            {
                int newY = (int)Math.Round(this.actor.GetY() + step);
                this.actor.SetPosition(this.actor.GetX(), newY);

                if (this.actor.GetWorld().IntersectWithWall(this.actor))
                {
                    SetJumping(0);
                    this.actor.SetPosition(this.actor.GetX(), oldY);
                    this.actor.SetPhysics(true);
                }
            }

            if (this.actor.GetWorld().IntersectWithWall(this.actor) || currentJumpingHeight >= jumpingMaxHeight)
            {
                SetJumping(2);
                SetCurrentHeight(0);
                this.SetMaxHeight(15);
            }

            if (this.actor.GetWorld().IntersectWithWall(this.actor))
            {
                this.actor.SetPosition(this.actor.GetX(), oldY);
            }
        }
    }
}
