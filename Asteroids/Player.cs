using Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Asteroids
{
    internal class Player : GameObject
    {
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
            Position.X = 100;
            Position.Y = 100;

            Points?.Add(new Vector2i(-30, -40));
            Points?.Add(new Vector2i(0, -20));
            Points?.Add(new Vector2i(30, -40));
            Points?.Add(new Vector2i(0, 40));
        }

        public override void Update(KeyboardState state)
        {
            MovePlayer(state);
        }

        public override void Render(WindowAPI.Window window)
        {
            PrimitiveRenderer.RenderLineLoop(this, window);
        }

        private void MovePlayer(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Left))
            {
                Position.X--;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                Position.X++;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                Position.Y--;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                Position.Y++;
            }
        }
    }
}
