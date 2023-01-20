using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.actors
{
    public class AbstractSwitchable : AbstractActor, ISwitchable
    {
        protected Animation? onAnimation;
        protected Animation? offAnimation;
        protected Animation? animation;
        protected bool is_on;

        protected AbstractSwitchable(int x, int y)
        {
            this.SetPosition(x, y);
        }

        public virtual void Toggle()
        {
            this.is_on = !this.is_on;

            if (is_on)
            {
                UpdateAnimation(onAnimation);
            }
            else
            {
                UpdateAnimation(offAnimation);
            }
        }

        public virtual void TurnOn()
        {
            if (!this.is_on) this.Toggle();
        }

        public virtual void TurnOff()
        {
            if (this.is_on) this.Toggle();
        }

        public virtual bool IsOn()
        {
            return this.is_on;
        }

        protected void UpdateAnimation(Animation anim)
        {
            this.animation = anim;
            this.SetAnimation(this.animation);
            this.animation.Start();
        }

        public override void Update()
        {
            // throw new NotImplementedException();
        }
    }
}
