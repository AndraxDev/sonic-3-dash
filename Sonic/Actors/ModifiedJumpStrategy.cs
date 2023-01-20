using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class ModifiedJumpStrategy : IJumpStrategy
    {
        private int range;

        public ModifiedJumpStrategy(int range)
        {
            this.range = range;
        }

        public int GetJumpHeight(int height)
        {
            return height + range;
        }
    }
}
