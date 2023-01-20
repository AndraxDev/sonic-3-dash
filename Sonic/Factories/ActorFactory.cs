using Sonic.actors;
using Sonic.Actors;
using Sonic.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Sonic.Factories
{
    internal class ActorFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor = null;

            if (actorType == "Player")
            {
                actor = new Player(x, y, 8.0f);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Enemy")
            {
                actor = new Enemy(null, x, y, 4.0f, 100);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "VerticalJumper1")
            {
                actor = new VJumper1(null, x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "VerticalJumper2")
            {
                actor = new VJumper2(null, x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Ring")
            {
                actor = new Ring(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Spikes")
            {
                actor = new Spikes(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "DeadArea")
            {
                actor = new DeadArea(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Shima")
            {
                int direction = actorName == "Shima1" ? 1 : -1;
                actor = new Shima(x, y, direction);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "BoosterSpeed")
            {
                actor = new Booster(x, y, 0);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "BoosterRings")
            {
                actor = new Booster(x, y, 1);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "BoosterJump")
            {
                actor = new Booster(x, y, 2);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "BoosterResistance")
            {
                actor = new Booster(x, y, 3);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Emerald")
            {
                actor = new Emerald(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Key")
            {
                actor = new Key(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "EmeraldDoor")
            {
                actor = new EmeraldDoor(x, y, true);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "KeyDoor")
            {
                actor = new KeyDoor(x, y, true);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Finish")
            {
                actor = new Finish(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else {
                throw new ArgumentException("Unknown type of 'actor'");
            }

            return actor;
        }
    }
}
