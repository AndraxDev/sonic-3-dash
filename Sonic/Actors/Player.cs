using Sonic.Actors;
using Sonic.Items;
using Sonic.Spells;
using Merlin2d.Game;

namespace Sonic.actors
{
    public class Player : AbstractCharacter, IWizard
    {
        protected Animation walkAnimation;
        protected Animation jumpAnimation;
        protected Animation sprintAnimation;
        protected Animation damageAnimation;

        private ICharacterState state;
        private int rings = 0;
        private Message msg;
        private Message msg2;
        private bool msgState = false;
        private int damage_timeout = 0;
        private bool damageMessage = false;
        private bool damageState = false;
        private ISpeedStrategy speedStrategy;
        private IJumpStrategy jumpStrategy;
        private int resistaceCounter = 0;
        private GameContainer container;

        public Player(int x, int y, double speed) {
            this.walkAnimation = new Animation("resources/sprites/sonic.png", 40, 40);
            walkAnimation.SetDuration(4);
            this.jumpAnimation = new Animation("resources/sprites/sonic_jumping.png", 40, 40);
            jumpAnimation.SetDuration(10);
            this.sprintAnimation = new Animation("resources/sprites/sonic.png", 40, 40);
            sprintAnimation.SetDuration(4);
            this.damageAnimation = new Animation("resources/sprites/damaged.png", 40, 32);
            damageAnimation.SetDuration(4);

            this.SetPosition(x, y);

            this.SetAnimation(this.walkAnimation);

            speedStrategy = new NormalSpeedStrategy();
            this.SetSpeedStrategy(speedStrategy);
            
            jumpStrategy = new NormalJumpStrategy();
            this.SetJumpStrategy(jumpStrategy);

            this.speed = speedStrategy.GetSpeed(speed);

            state = new PlayerLivingState(this, walkAnimation, jumpAnimation, sprintAnimation, damageAnimation);
            this.health = 20;
            this.msg = new Message("Rings: 0", 10, 10);
            this.msg2 = new Message("Resistance counter: 0", 10, 70);
            this.SetRingsCount(0);
        }

        public void SetContainer(GameContainer container) {
            this.container = container;
        }

        public double GetSpeed()
        {
            return this.speed;
        }

        public void SetDamageState(bool state) {
            this.damageState = state;
        }

        public bool GetDamageState() {
            return damageState;
        }

        public override void Update()
        {
            if (GetResistance() && resistaceCounter == 0) {
                resistaceCounter = 3000; // 1 second = 60 ticks
            }

            if (resistaceCounter > 0)
            {
                this.GetWorld().RemoveMessage(msg2);
                this.GetWorld().AddMessage(msg2);
                resistaceCounter--;
                if (resistaceCounter == 0)
                {
                    this.GetWorld().RemoveMessage(msg2);
                    SetResistance(false);
                }
            }

            msg2.SetText($"Resistance time: {(int) (resistaceCounter / 50)}");
            

            if (msgState)
            {
                this.GetWorld().RemoveMessage(msg);
                this.GetWorld().AddMessage(msg);
                msgState = false;
            }
            state.Update();

            if (damage_timeout > 0) damage_timeout--;

            // this.msg2.SetText($"Damage timeout: {this.damage_timeout.ToString()}");
            if (!damageMessage)
            {
                // this.GetWorld().AddMessage(msg2);
                damageMessage = true;
            }
        }

        public void Die() {
            this.GetWorld().RemoveMessage(msg2);
            SetResistance(false);
            this.resistaceCounter = 0;
            this.container.SetCameraFollowStyle(Merlin2d.Game.Enums.CameraFollowStyle.None);
            this.SetPhysics(false);
            this.state = new PlayerDyingState(this);
        }

        public void Jump(int height) {
            this.state.Jump(height);
        }

        public int GetRingsCount()
        {
            return rings;
        }

        public void ResetJumping() {
            if (state is PlayerLivingState) {
                this.SetPhysics(true);
                ((PlayerLivingState)state).ResetJumping();
            }
        }

        public ICharacterState GetState() {
            return this.state;
        }

        public void SetState(ICharacterState state)
        {
            this.state = state;
        }

        public void SetResistensCounter(int c) {
            this.resistaceCounter = c;
        }

        public void Damage() {
            if (!GetResistance())
            {
                if (state is PlayerLivingState)
                {
                    if (damage_timeout == 0)
                    {
                        if (this.GetRingsCount() > 0)
                        {
                            SetDamageState(true);
                            SpawnRings(this.GetRingsCount(), this.GetX());
                            this.Jump(10);
                            this.SetRingsCount(0);
                        }
                        else
                        {
                            this.Die();
                        }
                        damage_timeout = 100;
                    }
                }
            }
        }

        private void SpawnRings(int count, int x) {
            if (count > 10) count = 10;

            int x1 = x;
            int x2 = x + this.GetWidth();
            int x3 = 0;

            for (int i = 0; i < count; i++) {
                if (i % 2 == 0)
                {
                    x3 = x1 - 30 - (i * 5);
                }
                else {
                    x3 = x2 + 30 + (i * 5);
                }

                Ring r = new Ring(x3, this.GetY());
                r.SetPlayer(this);
                r.SetPhysics(true);
                this.GetWorld().AddActor(r);
            }
        }

        public void SetRingsCount(int rings)
        {
            if (rings >= 0) this.rings = rings;
            this.msg.SetText($"Rings: {this.rings}");
            msgState = true;
        }

        public void ChangeMana(int delta)
        {
            // Spells are managed by boosters so this method is unnecessary
        }

        public int GetMana()
        {
            // Spells are managed by boosters so this method is unnecessary
            return 0;
        }

        public void Cast(ISpell spell)
        {
            spell.ApplyEffects(this);
        }
    }
}
