using Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Asteroids
{
    internal class Bullet : GameObject
    {
        public Collider Collider { get; set; }
        public BulletState State { get; set; }
        public float Speed { get; set; }
        public Vector2 SpeedVector { get; set; }
        public float _oldAngle;

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

            SpeedVector = Vector2.UnitY;

            Collider.X = 1;
            Collider.Y = 20;
            Collider.InitPoints();
        }

        public override void Update(GameWindow window, FrameEventArgs args)
        {
            if (State == BulletState.Render)
            {
                SpeedVector = Physic2D.RotateVector(SpeedVector, Position.Angle, _oldAngle);
                Animator.Rotate(this, ref _oldAngle);
                CheckBorder(window);
                MoveBullet();
            }
        }

        public override void Render(GameWindow window)
        {
            if (State == BulletState.Render)
            {
                PrimitiveRenderer.RenderLine(this, window);
                //PrimitiveRenderer.RenderCollider(Collider, Position, window);
            }
        }

        private void CheckBorder(GameWindow window)
        {
            State = (Position.X < -window.Size.X || Position.X > window.Size.X) ||
                (Position.Y < -window.Size.Y || Position.Y > window.Size.Y) ? BulletState.Hide : State;
        }

        private void MoveBullet()
        {
            Position.X += SpeedVector.X * Speed;
            Position.Y += SpeedVector.Y * Speed;
        }
    }

    enum BulletState
    {
        Hide,
        Render
    }
}
