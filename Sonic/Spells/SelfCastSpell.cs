using Sonic.Actors;
using Sonic.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Sonic.Spells
{
    public class SelfCastSpell : ISpell
    {
        private List<IEffect> effects;
        private int cost = 0;

        public SelfCastSpell() { 
            effects = new List<IEffect>();
        }

        public void SetCost(int cost) {
            this.cost = cost;
        }

        public ISpell AddEffect(ICommand effect)
        {
            if (!(effect is IEffect)) throw new InvalidCastException($"Cannot cast ICommand to IEffect, maybe it is not an effect.");
            effects.Add((IEffect) effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            foreach (var effect in effects) {
                this.effects.Add((IEffect)effect);
            }
        }

        public void ApplyEffects(ICharacter target)
        {
            foreach (IEffect effect in effects) { 
                effect.SetTarget(target);
                ((ICommand) effect).Execute();
            }
        }

        public int GetCost()
        {
            return this.cost;
        }
    }
}
