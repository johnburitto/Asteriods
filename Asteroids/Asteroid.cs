using Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Asteroids
{
    internal class Asteroid : GameObject
    {
        public Asteroid()
        {
            Awake();
            Create();
        }

        protected override void Awake()
        {
            Points = new List<Vector2>();
        }

        protected override void Create()
        {
            Position.X = 100;
            Position.Y = 100;

            Points?.Add(new(-50, -100));
            Points?.Add(new(50, -100));
            Points?.Add(new(100, 0));
            Points?.Add(new(50, 100));
            Points?.Add(new(-50, 100));
            Points?.Add(new(-100, 0));
        }

        public override void Update(GameWindow window, FrameEventArgs args)
        {

        }

        public override void Render(GameWindow window)
        {
            PrimitiveRenderer.RenderLineLoop(this, window);
        }
    }
}
