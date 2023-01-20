using Sonic.actors;
using Sonic.Spells;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic.Actors
{
    public class Booster : AbstractActor, IInteractible
    {

        private Player player;
        private int state;
        private Animation booster_broken;
        private Animation booster_speed;
        private Animation booster_rings;
        private Animation booster_jump;
        private Animation booster_resistance;
        private Animation animation;
        private bool is_broken = false;

        public Booster(int x, int y, int state) {
            this.booster_broken = new Animation("resources/sprites/booster_broken.png", 32, 32);
            this.booster_speed = new Animation("resources/sprites/booster_speed.png", 32, 32);
            this.booster_rings = new Animation("resources/sprites/booster_rings.png", 32, 32);
            this.booster_jump = new Animation("resources/sprites/booster_jump.png", 32, 32);
            this.booster_resistance = new Animation("resources/sprites/booster_resistance.png", 32, 32);

            this.SetPosition(x, y);
            this.state = state;

            if (state == 0) animation = booster_speed;
            else if (state == 1) animation = booster_rings;
            else if (state == 2) animation = booster_jump;
            else if (state == 3) animation = booster_resistance;
            else { 
                throw new InvalidBoosterException($"Value {state} is not compatible with this booster.");
            }
            this.SetAnimation(animation);
            this.GetAnimation().Start();
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (!is_broken)
            {
                if (player.GetState() is PlayerLivingState)
                {
                    if (IntersectsWithActor(player))
                    {
                        if (state == 0) {
                            SpellDirector spellDirector = new SpellDirector(player);

                            ISpell spell = spellDirector.Build("speed+5");
                            ((IWizard)player).Cast(spell);
                        }
                        else if (state == 1) {
                            player.SetRingsCount(player.GetRingsCount() + 10);
                        }
                        else if (state == 2)
                        {
                            SpellDirector spellDirector = new SpellDirector(player);

                            ISpell spell = spellDirector.Build("jump+10");
                            ((IWizard)player).Cast(spell);
                        }
                        else if (state == 3)
                        {
                            SpellDirector spellDirector = new SpellDirector(player);
                            player.SetResistensCounter(3000);
                            ISpell spell = spellDirector.Build("resistance+1");
                            ((IWizard)player).Cast(spell);
                        }

                        this.GetWorld().SetWall(this.GetX() / 16, this.GetY() / 16 + 1, false);
                        this.GetWorld().SetWall(this.GetX() / 16 + 1, this.GetY() / 16 + 1, false);
                        is_broken = true;
                    }
                }
            } else {
                this.SetAnimation(booster_broken);
                this.GetAnimation().Start();
            }
        }
    }
}
