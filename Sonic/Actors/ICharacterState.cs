using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public interface ICharacterState
    {
        public void Update();
        public void Jump(int height);
    }
}
