using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.commands
{
    public class Fall<T> : IAction<T> where T : IActor
    {
        private int step;
        private int dx;
        private int dy;

        public Fall(int step) {
            this.step = step;
            this.dx = 0;
            this.dy = 1;
        }

        public void Execute(T value)
        {
            int oldX = value.GetX();
            int oldY = value.GetY();
            int newX = value.GetX() + step * dx;
            int newY = value.GetY() + step * dy;

            value.SetPosition(newX, newY);

            if (value.GetWorld().IntersectWithWall(value))
            {
                value.SetPosition(oldX, oldY);

                if (value.GetWorld().IntersectWithWall(value))
                {
                    value.SetPosition(value.GetX(), value.GetY() - 8);
                }
            }
        }
    }
}
