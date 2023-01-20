using Sonic.actors;
using Sonic.commands;
using Sonic.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Sonic.Actors
{
    public class PlayerLivingState : ICharacterState
    {
        private Player actor;
        private ICommand moveLeft;
        private ICommand moveRight;
        private Jump jump;
        private bool is_rotated = false;
        private Animation walkAnimation;
        private Animation jumpAnimation;
        private Animation sprintAnimation;
        private Animation damageAnimation;
        private int animation_state = 0;

        public PlayerLivingState(Player actor, Animation walkAnimation, Animation jumpAnimation, Animation sprintAnimation, Animation damageAnimation)
        {
            this.actor = actor;

            this.moveLeft = new Move(actor, actor.GetSpeedStrategy().GetSpeed(actor.GetSpeed()), -1, 0);
            this.moveRight = new Move(actor, actor.GetSpeedStrategy().GetSpeed(actor.GetSpeed()), 1, 0);
            this.jump = new Jump(actor, actor.GetSpeed(), 15);

            this.walkAnimation = walkAnimation;
            this.jumpAnimation = jumpAnimation;
            this.sprintAnimation = sprintAnimation;
            this.damageAnimation = damageAnimation;
        }

        public void Update()
        {
            ((Move)moveLeft).SetSpeed(actor.GetSpeedStrategy().GetSpeed(actor.GetSpeed()));
            ((Move)moveRight).SetSpeed(actor.GetSpeedStrategy().GetSpeed(actor.GetSpeed()));
            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                actor.GetAnimation().Start();

                if (!is_rotated)
                {
                    walkAnimation.FlipAnimation();
                    jumpAnimation.FlipAnimation();
                    damageAnimation.FlipAnimation();
                }
                is_rotated = true;
                this.moveLeft.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                if (is_rotated)
                {
                    walkAnimation.FlipAnimation();
                    jumpAnimation.FlipAnimation();
                    damageAnimation.FlipAnimation();
                }
                is_rotated = false;
                actor.GetAnimation().Start();
                this.moveRight.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.SPACE))
            {
                if (jump.IsJumping() == 0)
                {
                    this.Jump(actor.GetJumpStrategy().GetJumpHeight(15));
                }
            }
            else
            {
                if (jump.IsJumping() == 0)
                {
                    actor.GetAnimation().Stop();
                    actor.GetAnimation().SetCurrentFrame(0);
                }
            }

            if (jump.IsJumping() == 1 || jump.IsJumping() == 2)
            {
                if (this.animation_state != 1)
                {
                    if (!actor.GetDamageState()) actor.SetAnimation(jumpAnimation);
                    else actor.SetAnimation(damageAnimation);
                    actor.GetAnimation().Start();
                }
                this.animation_state = 1;

                jump.Execute();
            } else if (jump.IsJumping() == 0) {
                if (this.animation_state != 0)
                {
                    actor.SetDamageState(false);
                    actor.SetAnimation(walkAnimation);
                }
                this.animation_state = 0;
            }
        }

        public void ResetJumping() {
            jump.SetJumping(0);
            jump.SetCurrentHeight(0);
        }

        public void Jump(int height)
        {
            if (jump.IsJumping() == 0)
            {
                jump.SetMaxHeight(height);
                if (!actor.GetDamageState()) actor.SetAnimation(jumpAnimation);
                else actor.SetAnimation(damageAnimation);
                actor.GetAnimation().Start();
                actor.SetPhysics(false);
                jump.SetJumping(1);
            }
        }
    }
}
