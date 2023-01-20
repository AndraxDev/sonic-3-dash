using Sonic.actors;
using Sonic.Actors;
using Sonic.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Sonic.Spells
{
    public class ProjectileSpell : AbstractActor, IMovable, ISpell
    {
        private List<IEffect> effects;
        private double speed;
        private ISpeedStrategy strategy;
        private IJumpStrategy jumpStrategy;
        private int cost = 0;
        private Animation animation;

        public ProjectileSpell(int speed) {
            this.speed = speed;
        }

        public void SetCost(int cost)
        {
            this.cost = cost;
        }

        public void SetAnimation(Animation animation) {
            this.animation = animation;
        }

        public override void Update()
        {
            
        }

        public ISpell AddEffect(ICommand effect)
        {
            if (!(effect is IEffect)) throw new InvalidCastException($"Cannot cast ICommand to IEffect, maybe it is not an effect.");
            effects.Add((IEffect)effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            foreach (var effect in effects)
            {
                this.effects.Add((IEffect)effect);
            }
        }

        public void ApplyEffects(ICharacter target)
        {
            foreach (IEffect effect in effects)
            {
                effect.SetTarget(target);
                ((ICommand)effect).Execute();
            }
        }

        public int GetCost()
        {
            return this.cost;
        }

        public double GetSpeed(double speed)
        {
            return strategy.GetSpeed(speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetJumpStrategy(IJumpStrategy strategy)
        {
            this.jumpStrategy = strategy;
        }
    }
}
