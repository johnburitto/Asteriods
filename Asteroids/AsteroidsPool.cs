using Core;
using Logging;
using OpenTK.Windowing.Desktop;
using WindowAPI;

namespace Asteroids
{
    internal class AsteroidsPool : ObjectPool<Asteroid>
    {
        private Random _rnd = new Random();

        public override void InitItems(int number, GameWindow window)
        {
            base.InitItems(number, window);

            foreach (var el in Pool)
            {
                el.Object.Position.X = _rnd.Next(-window.Size.X, window.Size.X);
                el.Object.Position.Y = _rnd.Next(-window.Size.Y, window.Size.Y);
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
    }
}
