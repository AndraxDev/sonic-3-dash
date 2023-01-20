using Sonic.Actors;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Commands
{
    public class ResistanceEffect : ICommand, IEffect
    {
        private ICharacter target;
        private string name;

        public ResistanceEffect() { 
            
        }

        public void Execute()
        {
            target.SetResistance(true);
        }

        public string GetName()
        {
            return this.name;
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
