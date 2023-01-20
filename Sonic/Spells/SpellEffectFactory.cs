using Sonic.Commands;

namespace Sonic.Spells
{
    public class SpellEffectFactory
    {
        public IEffect Create(string effectName) {
            IEffect effect = null;
            if (effectName.Split('+')[0] == "speed")
            {
                effect = new SpeedEffect(Int32.Parse(effectName.Split('+')[1]));
                effect.SetName(effectName);
            }
            else if (effectName.Split('+')[0] == "jump")
            {
                effect = new JumpEffect(Int32.Parse(effectName.Split('+')[1]));
                effect.SetName(effectName);
            }
            else if (effectName.Split('+')[0] == "resistance")
            {
                effect = new ResistanceEffect();
                effect.SetName(effectName);
            }
            else {
                throw new ArgumentException($"'{effectName}' is not a valid value.");
            }

            return effect;
        }
    }
}
