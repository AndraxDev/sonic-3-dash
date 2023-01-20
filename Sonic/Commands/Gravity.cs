using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Sonic.commands
{
    public class Gravity : IPhysics
    {
        private IWorld world;
        private Fall<IActor> fall = new Fall<IActor>(8);

        void ICommand.Execute()
        {
            List<IActor> actors = this.world.GetActors();


            actors.ForEach(x => {
                if (x.IsAffectedByPhysics()) 
                {
                    fall.Execute(x);
                }
            });
        }

        void IPhysics.SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}
