using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Sonic.actors
{
    public class Crystal : AbstractSwitchable, ISwitchable, IObserver
    {
        private IObservable powerSource;

        public Crystal(int x, int y, IObservable powerSource) : base(x, y)
        {
            this.onAnimation = new Animation("resource/sprites/crystal_on.png", 56, 56);
            this.offAnimation = new Animation("resources/sprites/crystal_off.png", 56, 56);

            UpdateAnimation(offAnimation);
            this.AddSource(powerSource);
        }

        public void AddSource(IObservable source) {
            if (source != null)
            {
                this.powerSource = source;
                this.powerSource.Subscribe(this);
                this.Notify(this.powerSource);
            }

        }

        public void Notify(IObservable observable)
        {
            if (this.is_on != ((PowerSource) observable).IsOn())
                this.Toggle();
        }
    }
}
