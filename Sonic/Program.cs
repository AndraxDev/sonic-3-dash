using Sonic.actors;
using Sonic.Actors;
using Sonic.commands;
using Sonic.Factories;
using Sonic.Spells;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using TiledSharp;

namespace Sonic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("Sonic the Hedgehog 3 Dash", 1280, 720);
            
            container.SetMap("resources/maps/greenhill.tmx");
            container.GetWorld().SetPhysics(new Gravity());
            container.GetWorld().SetFactory(new ActorFactory());
            container.SetCameraFollowStyle(Merlin2d.Game.Enums.CameraFollowStyle.CenteredInsideMapPreferBottom);
            container.GetWorld().AddInitAction(world =>
            {
                Player actor = (Player)world.GetActors().Find(x => x.GetName() == "Sonic");
                actor.SetContainer(container);

                foreach (IActor actor1 in world.GetActors()) {
                    if (actor1 is IInteractible)
                    {
                        ((IInteractible)actor1).SetPlayer(actor);
                    }
                }

                foreach (IActor actor1 in world.GetActors())
                {
                    if (actor1 is Enemy)
                    {
                        ((Enemy)actor1).SetTarget(actor);
                    }
                }

                world.CenterOn(actor);
            });

            container.SetCameraZoom(2.0f);
            container.Run();
        }
    }
}