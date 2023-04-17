using Core;
using OpenTK.Windowing.Common;
using WindowAPI;

namespace Asteroids
{
    internal class Game
    {
        public static Window? Window { get; private set; }
        private static Player? _player;
        private static Bullet? _bullet;
        private static AsteroidsPool? _asteroidsPool;
        private static int _numberOfAsteroids = 1;
        public static int Score = 0;
        public static int HightScore => int.Parse(File.ReadAllText("hightScore.txt"));

        public static void InitGame()
        {
            _player = new Player();
            _bullet = new Bullet();
            _asteroidsPool = new AsteroidsPool();
            Window = new WindowBuilder()
                .WithSize(1920, 1080)
                .WithWindowBorder(WindowBorder.Resizable)
                .WithWindowState(WindowState.Fullscreen)
                .WithTitle("Asteroids")
                .WithApi(ContextAPI.OpenGL)
                .WithApiVersion(4, 6)
                .WithProfile(ContextProfile.Compatability)
                .WithFlags(ContextFlags.Default)
                .WithNumberOfSamples(0)
                .WithVsync()
                .Buid();

            _bullet.Speed = 15;
            _player.Speed = 10;
            _player.Bullet = _bullet;
            _asteroidsPool.InitItems(_numberOfAsteroids, Window);
            _asteroidsPool.Player = _player;
            _asteroidsPool.Bullet = _bullet;

            Window.MouseDown += _player.OnClick;

            Window.OnUpdateFrameEvent += GameUtils.FPSCounter;
            Window.OnUpdateFrameEvent += NextLevel;
            Window.OnUpdateFrameEvent += _player.Update;
            Window.OnUpdateFrameEvent += _bullet.Update;
            Window.OnUpdateFrameEvent += _asteroidsPool.UpdateElements;
            Window.OnUpdateFrameEvent += ParticleSystem.UpdatePaticles;
            Window.OnRenderFrameEvent += _player.Render;
            Window.OnRenderFrameEvent += _bullet.Render;
            Window.OnRenderFrameEvent += _asteroidsPool.RenderElements;
            Window.OnRenderFrameEvent += ParticleSystem.RenderPaticles;
            Window.OnRenderFrameEvent += ShowScore;
            Window.OnCloseEvent += SaveScore;
        }

        public static void StartGame()
        {
            Window?.Run();
        }

        public static void RestartLevel()
        {
            _player?.RestartPlayer();
            _asteroidsPool?.RestartPool(Window);
        }

        public static void NextLevel(Window window, FrameEventArgs args)
        {
            if (_asteroidsPool.IsAllObjectDisabled)
            {
                _numberOfAsteroids++;
                _player?.RestartPlayer();
                _asteroidsPool?.RenderElements(window);
                _asteroidsPool?.RestartPool(Window);
                _asteroidsPool?.InitItems(_numberOfAsteroids, window);
            }
        }

        public static void ShowScore(Window window)
        {
            TextRenderer.RenderText(window, Score.ToString(), -window.Size.X + 50, window.Size.Y - 50);
            TextRenderer.RenderText(window, HightScore.ToString(), -window.Size.X + 50, window.Size.Y - 100);
        }

        public static void SaveScore()
        {
            if (Score > HightScore)
            {
                File.WriteAllText("hightScore.txt", Score.ToString());
            }
        }
    }
}
