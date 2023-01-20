using Sonic.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Sonic.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        private ProjectileSpell projectileSpell;

        public ProjectileSpellBuilder()
        {
            projectileSpell = new ProjectileSpell(0);
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            SpellEffectFactory spellEffectFactory = new SpellEffectFactory();
            IEffect effect = spellEffectFactory.Create(effectName);
            projectileSpell.AddEffect((ICommand)effect);
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            return projectileSpell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            projectileSpell.SetAnimation(animation);
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            projectileSpell.SetCost(cost);
            return this;
        }
    }
}
