using Sonic.actors;
using Sonic.Actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Commands
{
    public class SpeedEffect : ICommand, IEffect
    {
        private int speed;
        private ICharacter target;
        private string name;
        public SpeedEffect(int speed) {
            this.speed = speed;
        }

        public void Execute()
        {
            target.SetSpeedStrategy(new ModifiedSpeedStrategy(speed));
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetTarget(ICharacter target)
        {
            this.target = target;
        }
    }
}
