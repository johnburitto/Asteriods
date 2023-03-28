using Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Asteroids
{
    internal class Player : GameObject
    {
        public float Speed { get; set; }

        public Player()
        {
            Awake();
            Create();
        }

        protected override void Awake()
        {
            Points = new List<Vector2i>();
        }

        protected override void Create()
        {
            Points?.Add(new Vector2i(-30, -40));
            Points?.Add(new Vector2i(0, -20));
            Points?.Add(new Vector2i(30, -40));
            Points?.Add(new Vector2i(0, 40));
        }

        public override void Update(GameWindow window, FrameEventArgs args)
        {
            CheckBorder(window);
            MovePlayer(window.KeyboardState);
        }

        public override void Render(GameWindow window)
        {
            PrimitiveRenderer.RenderLineLoop(this, window);
        }

        private void MovePlayer(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.A))
            {
                Position.X -= Speed;
            }
            else if (state.IsKeyDown(Keys.D))
            {
                Position.X += Speed;
            }

            if (state.IsKeyDown(Keys.W))
            {
                Position.Y += Speed;
            }
            else if (state.IsKeyDown(Keys.S))
            {
                Position.Y -= Speed;
            }
        }
        
        private void CheckBorder(GameWindow window)
        {
            if (Position.X > window.Size.X)
            {
                Position.X = -window.Size.X;
            }
            else if (Position.X < -window.Size.X)
            {
                Position.X = window.Size.X;
            }


            if (Position.Y > window.Size.Y)
            {
                Position.Y = -window.Size.Y;
            }
            else if (Position.Y < -window.Size.Y)
            {
                Position.Y = window.Size.Y;
            }
        }
    }
}
