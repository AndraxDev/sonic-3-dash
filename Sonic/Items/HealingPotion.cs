using Sonic.actors;
using Sonic.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Items
{
    public class HealingPotion : AbstractActor, IItem, IUsable
    {
        private bool used;
        private int dose;
        private Animation fullAnimation;
        private Animation emptyAnimation;

        public HealingPotion(int x, int y, int dose) {
            this.dose = dose;
            this.used = false;

            this.fullAnimation = new Animation("resource/sprites/healingpotion.png", 16, 16);
            this.emptyAnimation = new Animation("resources/sprites/healingpotion_empty.png", 16, 16);

            this.SetPosition(x, y);
            this.SetAnimation(fullAnimation);
            this.GetAnimation().Start();
        }

        public override void Update()
        {
            
        }

        void IUsable.Use(IActor actor)
        {
            if (!used) {
                used = true;
                this.SetAnimation(emptyAnimation);
                this.GetAnimation().Start();

                if (actor is ICharacter) {
                    (actor as ICharacter).ChangeHealth(dose);
                }
            }
        }
    }
}
