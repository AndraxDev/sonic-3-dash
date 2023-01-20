using Sonic.Actors;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Commands
{
    public class JumpEffect : ICommand, IEffect
    {
        private int height;
        private ICharacter target;
        private string name;

        public JumpEffect(int height) {
            this.height = height;
        }

        public void Execute()
        {
            target.SetJumpStrategy(new ModifiedJumpStrategy(10));
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
