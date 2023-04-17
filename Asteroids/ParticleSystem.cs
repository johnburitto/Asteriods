using Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using WindowAPI;

namespace Asteroids
{
    public class ParticleSystem
    {
        private static List<Particle> _particles = new List<Particle>();  
        private static Random _random = new Random();

        public static void InitParticles(int number, Transform position, int lifeTime)
        {
            foreach (var el in _particles)
            {
                Game.Window.OnUpdateFrameEvent -= el.Update;
                Game.Window.OnRenderFrameEvent -= el.Render;
            }

            _particles.Clear();

            for (int i = 0; i < number; i++)
            {
                _particles.Add(new Particle()
                {
                    Position = position,
                    SpeedVector = new(_random.Next(-5, 5), _random.Next(-5, 5)),
                    Status = ParticleStatus.PreRender,
                    LifeTime = lifeTime
                });
            }
        }

        public static void UpdatePaticles(Window window, FrameEventArgs args)
        {
            foreach (var el in  _particles)
            {
                if (el.Status == ParticleStatus.PreRender)
                {
                    window.OnUpdateFrameEvent += el.Update;
                }
                else if (el.Status == ParticleStatus.Dead)
                {
                    window.OnUpdateFrameEvent -= el.Update;
                }
            }
        }

        public static void RenderPaticles(Window window)
        {
            foreach (var el in _particles)
            {
                if (el.Status == ParticleStatus.PreRender)
                {
                    window.OnRenderFrameEvent += el.Render;

                    el.Status = ParticleStatus.Alive;
                }
                else if (el.Status == ParticleStatus.Dead)
                {
                    window.OnRenderFrameEvent -= el.Render;
                }
            }
        }
    }

    public class Particle : GameObject
    {
        public DateTime StartTime = DateTime.Now;
        public int LifeTime {  get; set; }
        public ParticleStatus Status { get; set; }
        public Vector2 SpeedVector { get; set; }

        public Particle()
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
            Points?.Add(new Vector2(0f, 0f));

            Status = ParticleStatus.Alive;
        }

        public override void Update(GameWindow window, FrameEventArgs args)
        {
            if (Status == ParticleStatus.Alive)
            {
                Position.X += SpeedVector.X;
                Position.Y += SpeedVector.Y;
            }
        }

        public override void Render(GameWindow window)
        {
            if ((DateTime.Now - StartTime).TotalSeconds < LifeTime && Status == ParticleStatus.Alive)
            {
                PrimitiveRenderer.RenderPoints(this, window);
            }
            else
            {
                Status = ParticleStatus.Dead;
            }
        }
    }

    public enum ParticleStatus
    {
        Dead,
        PreRender,
        Alive
    }
}
