using Core;
using Logging;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using WindowAPI;

namespace Asteroids
{
    internal class AsteroidsPool : ObjectPool<Asteroid>
    {
        public Player Player { get; set; }
        public Bullet Bullet { get; set; }
        private Random _rnd = new Random();
        private PlayerAsteroidColliderScenario _playerScenario = new PlayerAsteroidColliderScenario();
        private BulletAsteroidColliderScenario _bulletScenario = new BulletAsteroidColliderScenario();

        public override void InitItems(int number, GameWindow window)
        {
            base.InitItems(number, window);

            foreach (var el in Pool)
            {
                int x = _rnd.Next(-window.Size.X, window.Size.X);
                int y = _rnd.Next(-window.Size.Y, window.Size.Y);

                el.Object.Position.X = x < 150 && x > 0 ? x + 150 : x < 0 && x > -150 ? x - 150 : x;
                el.Object.Position.Y = y < 150 && y > 0 ? y + 150 : y < 0 && y > -150 ? y - 150 : y;

                el.State = ItemState.Enable;
            }
        }

        public void UpdateElements(Window window, FrameEventArgs args)
        {
           foreach (var el in Pool)
            {            
                if (el.State == ItemState.Enable)
                {
                    window.OnUpdateFrameEvent += el.Object.Update;
                }
                if (el.State == ItemState.Rendering)
                {
                    Physic2D.CheckColliding(_playerScenario, Player, el);
                    Physic2D.CheckColliding(_bulletScenario, Bullet, el);
                }
                if (el.State == ItemState.Disable)
                {
                    window.OnUpdateFrameEvent -= el.Object.Update;
                }
            }
        }

        public void RenderElements(Window window)
        {
            foreach (var el in Pool)
            {
                if (el.State == ItemState.Enable)
                {
                    window.OnRenderFrameEvent += el.Object.Render;
                    el.State = ItemState.Rendering;
                }
                else if (el.State == ItemState.Disable)
                {
                    window.OnRenderFrameEvent -= el.Object.Render;
                }
            }
        }

        public void RestartPool(Window window)
        {
            foreach (var el in Pool)
            {
                window.OnUpdateFrameEvent -= el.Object.Update;
                window.OnRenderFrameEvent -= el.Object.Render;

                el.State = ItemState.Enable;
            }
        }
    }
}
