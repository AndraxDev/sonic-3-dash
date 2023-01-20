using Sonic.Actors;
using Sonic.commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Sonic.actors
{
    internal class Enemy : AbstractCharacter
    {
        protected Animation animation;
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand moveLeft;
        private ICommand moveRight;
        private bool is_rotated = false;
        private Player player;
        private int vision;
        private int random = 0;
        private int random_step_counter = 0;
        private bool random_path_passed = false;

        public Enemy(Player player, int x, int y, double speed, int vision)
        {
            this.animation = new Animation("resources/sprites/enemy.png", 59, 32);

            this.SetPosition(x, y);

            this.SetAnimation(this.animation);

            this.speed = speed;
            this.player = player;

            this.moveUp = new Move(this, speed, 0, -1);
            this.moveDown = new Move(this, speed, 0, 1);
            this.moveLeft = new Move(this, speed, -1, 0);
            this.moveRight = new Move(this, speed, 1, 0);
            this.vision = vision;

            Random rand = new Random();
            random = rand.Next(50, 200);
        }

        public void SetTarget(IActor player) {
            // Setting null as target will remove target
            this.player = (Player)player;
        }

        public override void Update()
        {
            if (StandsOn(player)) {
                this.RemoveFromWorld();
            }
            else if (IntersectsWithActor(this.player))
            {
                player.Damage();
            }

            if (DoesTargetDetected())
            {
                if (!DetectCollisionX())
                {
                    if (DetectDirection())
                    {
                        this.animation.Start();
                        if (!is_rotated) this.animation.FlipAnimation();
                        is_rotated = true;
                        this.moveLeft.Execute();
                    }
                    else
                    {
                        if (is_rotated) this.animation.FlipAnimation();
                        is_rotated = false;
                        this.animation.Start();
                        this.moveRight.Execute();
                    }
                }
                else {
                    this.animation.Stop();
                }
            }
            else {
                if (random_path_passed)
                {
                    if (is_rotated)
                    {
                        this.animation.FlipAnimation();
                        is_rotated = false;
                    }
                    else
                    {
                        this.animation.FlipAnimation();
                        is_rotated = true;
                    }

                    random_step_counter = 0;
                    Random rand = new Random();
                    random = rand.Next(50, 200);
                    random_path_passed = false;
                }
                else {
                    if (random_step_counter >= random) {
                        random_path_passed = true;
                    }
                    if (!is_rotated)
                    {
                        this.animation.Start();
                        this.moveRight.Execute();
                    }
                    else
                    {
                        this.animation.Start();
                        this.moveLeft.Execute();
                    }

                    random_step_counter++;
                }
            }
        }

        private bool DoesTargetDetected() {
            if (player != null)
            {
                int dx = Math.Abs(this.GetX() - player.GetX());
                int dy = Math.Abs(this.GetY() - player.GetY());
                // Console.WriteLine(dx);
                return dx <= vision && dy <= vision;
            }
            else return false;
        }

        private bool DetectCollisionX() {
            if (player != null)
            {
                int dx = Math.Abs(this.GetX() - player.GetX());
                return dx <= 10;
            }
            else return false;
        }

        private bool DetectDirection() {
            // Return true if Enemy located on a right side

            if (player != null)
            {
                return this.GetX() > player.GetX();
            }
            else return false;
        }
    }
}
