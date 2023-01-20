﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class NormalJumpStrategy : IJumpStrategy
    {
        public int GetJumpHeight(int height)
        {
            return height;
        }
    }
}
