using Sonic.actors;
using Merlin2d.Game;

namespace Sonic.Actors
{
    public class EmeraldDoor : Door, IDoor, IInteractible
    {
        private Animation animation;
        private Animation closed;
        private Animation opened;
        private Player player;
        
        public EmeraldDoor(int x, int y, bool state) : base(x, y, state)
        {
            closed = new Animation("resources/sprites/emerald_door_closed.png", 32, 64);
            opened = new Animation("resources/sprites/emerald_door_opened.png", 32, 64);
            LoadAnimation();
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void LoadAnimation() {
            if (IsClosed()) this.SetAnimation(closed);
            else this.SetAnimation(opened);
            this.GetAnimation().Start();
        }

        public override void Update()
        {
            LoadAnimation();

            if (IntersectsWithActor(player) && IsClosed())
            {
                player.SetPosition(player.GetX() - (int)player.GetSpeedStrategy().GetSpeed(player.GetSpeed()), player.GetY());
            }

            bool emeraldIsPicked = true;
            foreach (AbstractActor actor in player.GetWorld().GetActors()) {
                if (actor.GetName() == "Emerald") emeraldIsPicked = false;
            }

            if (emeraldIsPicked) Open();
            else Close();
        }
    }
}
