using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Sonic.actors
{
    public abstract class AbstractActor : IActor
    {
        private String name;
        private int x;
        private int y;
        private IWorld? world;
        private Animation? animation;
        private bool physics = false;
        private bool removedFromWorld = true;
        private bool resistance;

        public AbstractActor()
        {
            name = "";
        }

        public AbstractActor(String name)
        {
            this.name = name;
        }

        public String GetName() {
            return this.name;
        }

        public void SetName(String name) {
            this.name = name;
        }

        public int GetX() { 
            return x;
        }

        public int GetY() {
            return y;
        }

        public int GetWidth() {
            return this.animation.GetWidth();
        }

        public int GetHeight() {
            return this.animation.GetHeight();
        }

        public void SetPosition(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public void OnAddedToWorld(IWorld world) {
            this.removedFromWorld = false;
            this.world = world;
        }

        public IWorld GetWorld() {
            return this.world;
        }

        public Animation GetAnimation() 
        { 
            return this.animation; 
        }

        public void SetAnimation(Animation animation) {
            this.animation = animation;
        }

        public bool IntersectsWithActor(IActor other) {
            int tX1 = this.GetX();
            int tX2 = this.GetX() + this.GetWidth();
            int oX1 = other.GetX();
            int oX2 = other.GetX() + other.GetWidth();
            int tY1 = this.GetY();
            int tY2 = this.GetY() + this.GetHeight();
            int oY1 = other.GetY();
            int oY2 = other.GetY() + other.GetHeight();

            if ((oX1 > tX1 && oX1 < tX2) || (tX1 > oX1 && tX1 < oX2) || (this.GetWidth() > other.GetWidth() && tX1 <= oX1 && oX2 < tX2) || (this.GetWidth() < other.GetWidth() && tX1 >= oX1 && oX2 > tX2)) {
                if ((oY1 > tY1 && oY1 < tY2) || (tY1 > oY1 && tY1 < oY2) || (this.GetHeight() > other.GetHeight() && tY1 <= oY1 && oY2 < tY2) || (this.GetHeight() < other.GetHeight() && tY1 >= oY1 && oY2 > tY2))
                {
                    return true;
                }
            }

            return false;
        }

        public bool StandsOn(IActor other)
        {
            int tX1 = this.GetX() + 5;
            int tX2 = this.GetX() + this.GetWidth() - 5;
            int oX1 = other.GetX();
            int oX2 = other.GetX() + other.GetWidth();
            int tY1 = this.GetY();
            int tY2 = this.GetY() + 15;
            int oY1 = other.GetY();
            int oY2 = other.GetY() + other.GetHeight();

            if ((oX1 > tX1 && oX1 < tX2) || (tX1 > oX1 && tX1 < oX2) || (this.GetWidth() > other.GetWidth() && tX1 <= oX1 && oX2 < tX2) || (this.GetWidth() < other.GetWidth() && tX1 >= oX1 && oX2 > tX2))
            {
                if ((oY2 > tY1 && oY2 < tY2))
                {
                    return true;
                }
            }

            return false;
        }

        public void SetPhysics(bool isPhysicsEnabled) {
            this.physics = isPhysicsEnabled;
        }

        public bool IsAffectedByPhysics() { 
            return this.physics;
        }

        public void RemoveFromWorld() { 
            this.removedFromWorld = true;
        }

        public bool RemovedFromWorld() {
            return this.removedFromWorld;
        }

        public bool GetResistance() { 
            return resistance;
        }

        public void SetResistance(bool resistance) {
            this.resistance = resistance;
        }

        public abstract void Update();
    }
}
