using Core;
using Logging;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Asteroids
{
    internal class Bullet : GameObject
    {
        public Collider Collider { get; set; }
        public BulletState State { get; set; }

        public Bullet()
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
            Points?.Add(new Vector2(0, -10));
            Points?.Add(new Vector2(0, 10));
        }

        public override void Update(GameWindow window, FrameEventArgs args)
        {
            if (State == BulletState.Render)
            {
                Position.Y++;
            }
        }

        public override void Render(GameWindow window)
        {
            if (State == BulletState.Render)
            {
                PrimitiveRenderer.RenderLine(this, window);
            }
        }

        public void OnClick(MouseButtonEventArgs args)
        {
            State = args.Button == MouseButton.Left ? BulletState.Render : State;
        }
    }

    enum BulletState
    {
        Hide,
        Render
    }
}
