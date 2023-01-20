using Sonic.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Sonic.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        private SelfCastSpell selfCastSpell;

        public SelfCastSpellBuilder() {
            selfCastSpell = new SelfCastSpell();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            SpellEffectFactory spellEffectFactory = new SpellEffectFactory();
            IEffect effect = spellEffectFactory.Create(effectName);
            selfCastSpell.AddEffect((ICommand) effect);
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            return selfCastSpell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            selfCastSpell.SetCost(cost);
            return this;
        }
    }
}
