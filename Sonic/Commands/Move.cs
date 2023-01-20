using Sonic.actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Sonic.commands
{
    public class Move : ICommand
    {
        private IActor actor;
        private double step;
        private int dx;
        private int dy;

        public Move(IMovable movable, double step, int dx, int dy) {
            if (!(movable is IActor)) {
                throw new ArgumentException("'movable' has invalid type.");
            }

            this.actor = (IActor) movable;
            this.step = step;
            this.dx = dx;
            this.dy = dy;
        }

        public void SetSpeed(double speed)
        {
            this.step = speed;
        }

        public void Execute()
        {
            int oldX = this.actor.GetX();
            int oldY = this.actor.GetY();
            int newX = (int) Math.Round(this.actor.GetX() + step * dx);
            int newY = (int) Math.Round(this.actor.GetY() + step * dy);

            this.actor.SetPosition(newX, newY);

            if (this.actor.GetWorld().IntersectWithWall(this.actor))
                this.actor.SetPosition(oldX, oldY);
        }
    }
}
