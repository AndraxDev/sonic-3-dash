using Sonic.actors;
using Sonic.Actors;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Items
{
    public class Box : AbstractActor, IItem, IUsable
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }

        void IUsable.Use(IActor actor)
        {
            throw new NotImplementedException();
        }
    }
}
