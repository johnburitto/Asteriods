using Core;
using OpenTK.Windowing.Common;
using WindowAPI;

namespace Asteroids
{
    internal class Game
    {
        private static Window? _window;
        private static Player? _player;
        private static Bullet? _bullet;
        private static AsteroidsPool? _asteroidsPool;
        private static int _numberOfAsteroids = 3;
        public static int Score = 0;
        public static int HightScore = 0;

        public static void InitGame()
        {
            _player = new Player();
            _bullet = new Bullet();
            _asteroidsPool = new AsteroidsPool();
            _window = new WindowBuilder()
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
            _asteroidsPool.InitItems(_numberOfAsteroids, _window);
            _asteroidsPool.Player = _player;
            _asteroidsPool.Bullet = _bullet;

            HightScore = Int32.Parse(File.ReadAllText("hightScore.txt"));

            _window.MouseDown += _player.OnClick;

            _window.OnUpdateFrameEvent += GameUtils.FPSCounter;
            _window.OnUpdateFrameEvent += _player.Update;
            _window.OnUpdateFrameEvent += _bullet.Update;
            _window.OnUpdateFrameEvent += _asteroidsPool.UpdateElements;
            _window.OnUpdateFrameEvent += ParticleSystem.UpdatePaticles;
            _window.OnUpdateFrameEvent += NextLevel;
            _window.OnRenderFrameEvent += _player.Render;
            _window.OnRenderFrameEvent += _bullet.Render;
            _window.OnRenderFrameEvent += _asteroidsPool.RenderElements;
            _window.OnRenderFrameEvent += ParticleSystem.RenderPaticles;
            _window.OnRenderFrameEvent += ShowScore;
            _window.OnCloseEvent += SaveScore;
        }

        public static void StartGame()
        {
            _window?.Run();
        }

        public static void RestartLevel()
        {
            _player?.RestartPlayer();
            _asteroidsPool?.RestartPool(_window);
        }

        public static void NextLevel(Window window, FrameEventArgs args)
        {
            if (_asteroidsPool.IsAllObjectDisabled)
            {
                _numberOfAsteroids++;
                _player?.RestartPlayer();
                _asteroidsPool?.RenderElements(window);
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
            File.WriteAllText("hightScore.txt", Score.ToString());
        }
    }
}
