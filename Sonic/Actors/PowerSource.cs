using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Sonic.actors
{
    public class PowerSource : AbstractSwitchable, ISwitchable, IObservable
    {
        private List<IObserver>? observers = new List<IObserver>();

        public PowerSource(int x, int y) : base(x, y)
        {
            this.onAnimation = new Animation("resources/sprites/source_on.png", 56, 60);
            this.offAnimation = new Animation("resources/sprites/source_off.png", 56, 60);
            UpdateAnimation(offAnimation);
        }

        public override void Update()
        {
            if (Input.GetInstance().IsKeyPressed(Input.Key.E))
                this.Toggle();
        }

        public override void Toggle()
        {
            base.Toggle();

            foreach (IObserver observer in observers)
            {
                observer.Notify(this);
            }
        }

        public void Subscribe(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            if (this.observers.Contains(observer))
                this.observers.Remove(observer);
        }
    }
}
