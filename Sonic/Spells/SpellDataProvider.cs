using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Spells
{
    public class SpellDataProvider : ISpellDataProvider
    {

        private class SpellEffect 
        {
            public string Name { get; set; }
            public int Cost { get; set; }
        }

        private static SpellDataProvider instance;
        private Dictionary<string, SpellInfo> spellInfos;
        private Dictionary<string, int> effectInfos;

        private SpellDataProvider() 
        { 
            
        }

        public static SpellDataProvider GetInstance()
        {
            if (instance == null) instance = new SpellDataProvider();

            return instance;
        }

        private void LoadEffectInfos()
        {
            effectInfos = new Dictionary<string, int>();

            string json = File.ReadAllText("resources/effects.json");

            List<SpellEffect> parsed = JsonConvert.DeserializeObject<List<SpellEffect>>(json);

            foreach (SpellEffect effect in parsed) {
                effectInfos.Add(effect.Name, effect.Cost);
            }
        }

        public Dictionary<string, int> GetSpellEffects()
        {
            if (effectInfos == null) LoadEffectInfos();
            return this.effectInfos;
        }

        private void LoadSpellInfo()
        {
            string[] lines = File.ReadAllLines("resources/spell.csv");
            spellInfos = new Dictionary<string, SpellInfo>();

            foreach (string line in lines[1..])
            {
                // SpellInfo spellInfo = new SpellInfo(line);
                spellInfos.Add(line.Split(';')[0], line);
            }
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            if (spellInfos == null) LoadSpellInfo();
            return this.spellInfos;
        }
    }
}
