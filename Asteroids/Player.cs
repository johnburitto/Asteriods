using Core;
using Logging;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Asteroids
{
    internal class Player : GameObject
    {
        public float Speed { get; set; }
        public Vector2 SpeedVector = Vector2.Zero;
        public Collider Collider { get; set; }
        private float _oldAngle;

        public Player()
        {
            Awake();
            Create();
        }

        protected override void Awake()
        {
            Collider = new Collider();
            Points = new List<Vector2>();
        }

        protected override void Create()
        {
            Points?.Add(new Vector2(-30, -40));
            Points?.Add(new Vector2(0, -20));
            Points?.Add(new Vector2(30, -40));
            Points?.Add(new Vector2(0, 40));

            Collider.X = 60;
            Collider.Y = 80;
            Collider.InitPoints();
        }

        public override void Update(GameWindow window, FrameEventArgs args)
        {
            CalculateAngle(window);
            MoveInput(window.KeyboardState);
            Physic2D.RotateCollider(Collider, Position.Angle, ref _oldAngle);
            Animator.Rotate(this, ref _oldAngle);
            CheckBorder(window);
            MovePlayer();
        }

        public override void Render(GameWindow window)
        {
            PrimitiveRenderer.RenderLineLoop(this, window);
            PrimitiveRenderer.RenderCollider(Collider, Position, window);
        }

        private void MoveInput(KeyboardState state)
        {
            SpeedVector.X = state.IsKeyDown(Keys.D) ? 1 : state.IsKeyDown(Keys.A) ? -1 : 0;
            SpeedVector.Y = state.IsKeyDown(Keys.W) ? 1 : state.IsKeyDown(Keys.S) ? -1 : 0;
        }

        private void CheckBorder(GameWindow window)
        {
            if (Position.X > window.Size.X)
            {
                Position.X = -window.Size.X;

                if (SpeedVector.Y != 0)
                {
                    Position.Y = -Position.Y;
                }
            }
            else if (Position.X < -window.Size.X)
            {
                Position.X = window.Size.X;

                if (SpeedVector.Y != 0)
                {
                    Position.Y = -Position.Y;
                }
            }


            if (Position.Y > window.Size.Y)
            {
                Position.Y = -window.Size.Y;

                if (SpeedVector.X != 0)
                {
                    Position.X = -Position.X;
                }
            }
            else if (Position.Y < -window.Size.Y)
            {
                Position.Y = window.Size.Y;

                if (SpeedVector.X != 0)
                {
                    Position.X = -Position.X;
                }
            }
        }

        private void MovePlayer()
        {
            Position.X += SpeedVector.X * Speed;
            Position.Y += SpeedVector.Y * Speed;
        }

        private void CalculateAngle(GameWindow window)
        {
            var nativePosition = Position.GetNativeCoordinates(window);
            Vector2 firstPosition = new(window.MousePosition.X - nativePosition.X, window.Size.Y - window.MousePosition.Y - nativePosition.Y);
            Vector2 secondPosition = Vector2.UnitY * 10;

            var angle = MathF.Acos((firstPosition.X * secondPosition.X + firstPosition.Y * secondPosition.Y)
                / (MathF.Sqrt(MathF.Pow(firstPosition.X, 2) + MathF.Pow(firstPosition.Y, 2)) * MathF.Sqrt(MathF.Pow(secondPosition.X, 2) + MathF.Pow(secondPosition.Y, 2))));

            Position.Angle = float.IsNaN(angle) ? 0 : firstPosition.X > 0 ? angle : 2 * MathF.PI - angle;
        }
    }
}
