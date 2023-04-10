using Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Asteroids
{
    internal class Asteroid : GameObject
    {
        public Collider Collider { get; set; }

        public Asteroid()
        {
            Awake();
            Create();
        }

        protected override void Awake()
        {
            Points = new List<Vector2>();
            Collider = new Collider();
        }

        protected override void Create()
        {
            Position.Angle = new Random().Next(1, 3) * 0.00001f;

            Points?.Add(new(-50, -100));
            Points?.Add(new(50, -100));
            Points?.Add(new(100, 0));
            Points?.Add(new(50, 100));
            Points?.Add(new(-50, 100));
            Points?.Add(new(-100, 0));

            Collider.X = 200;
            Collider.Y = 200;
            Collider.InitPoints();
        }

        public override void Update(GameWindow window, FrameEventArgs args)
        {
            Animator.Rotate(this);
        }

        public override void Render(GameWindow window)
        {
            PrimitiveRenderer.RenderLineLoop(this, window);
        }
    }
}
