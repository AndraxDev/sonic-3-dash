using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Spells
{
    public interface ISpellDirector
    {
        ISpell Build(string spellName);
    }
}
