using Sonic.actors;
using Sonic.commands;
using Sonic.Commands;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class PlayerDyingState : ICharacterState
    {
        private Player actor;
        private Animation animation;
        private int m1 = 0;
        private int m2 = 0;
        public PlayerDyingState(Player actor)
        {
            this.animation = new Animation("resources/sprites/died.png", 34, 43);
            this.actor = actor;
        }

        public void Jump(int height)
        {
            
        }

        public void Update()
        {
            actor.SetAnimation(animation);

            if (m1 < 30) {
                actor.SetPosition(actor.GetX(), actor.GetY() - 6);
            }
            if (m1 >= 30) {
                if (m2 < 100)
                {
                    actor.SetPosition(actor.GetX(), actor.GetY() + 6);
                }
                m2++;
            }
            m1++;
        }
    }
}
