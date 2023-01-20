using Sonic.actors;
using Merlin2d.Game.Actions;

namespace Sonic.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        protected double speed;
        protected ISpeedStrategy strategy = new NormalSpeedStrategy();
        protected IJumpStrategy jumpStrategy = new NormalJumpStrategy();
        protected int health;

        public override void Update()
        {
            
        }

        public void AddEffect(ICommand effect)
        {
            
        }

        public void ChangeHealth(int delta)
        {
            this.health += delta;
        }

        public void Die()
        {
            this.RemoveFromWorld();
        }

        public int GetHealth()
        {
            return health;
        }

        public double GetSpeed(double speed)
        {
            return strategy.GetSpeed(speed);
        }

        public void RemoveEffect(ICommand effect)
        {
            
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.strategy = strategy;
        }

        public ISpeedStrategy GetSpeedStrategy() {
            return this.strategy;
        }

        public void SetJumpStrategy(IJumpStrategy strategy)
        {
            this.jumpStrategy = strategy;
        }

        public IJumpStrategy GetJumpStrategy()
        {
            return this.jumpStrategy;
        }
    }
}
