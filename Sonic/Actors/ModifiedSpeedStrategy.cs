
namespace Sonic.Actors
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        private int range;

        public ModifiedSpeedStrategy(int range)
        {
            this.range = range;
        }

        public double GetSpeed(double speed)
        {
            return speed + this.range;
        }
    }
}
