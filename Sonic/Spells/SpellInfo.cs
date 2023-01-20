using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Spells
{
    public class SpellInfo
    {
        public SpellInfo() 
        { 

        }

        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }

        public static implicit operator SpellInfo(string data)
        {
            string[] values = data.Split(';');
            return new SpellInfo
            {
                Name = values[0],
                SpellType = values[1] == "projectile" ? SpellType.ProjectileSpell : SpellType.SelfCastSpell,
                AnimationPath = values[2],
                AnimationWidth = int.Parse(values[3]),
                AnimationHeight = int.Parse(values[4]),
                EffectNames = values[5].Split(',')
            };
        }
    }
}
