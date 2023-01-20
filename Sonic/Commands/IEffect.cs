using Sonic.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Commands
{
    public interface IEffect
    {
        public void SetTarget(ICharacter target);
        public string GetName();
        public void SetName(string name);
    }
}
