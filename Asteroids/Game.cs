using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
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
            
            _window.MouseDown += _player.OnClick;

            _window.OnUpdateFrameEvent += GameUtils.FPSCounter;
            _window.OnUpdateFrameEvent += _player.Update;
            _window.OnUpdateFrameEvent += _bullet.Update;
            _window.OnUpdateFrameEvent += _asteroidsPool.UpdateElements;
            _window.OnRenderFrameEvent += _player.Render;
            _window.OnRenderFrameEvent += _bullet.Render;
            _window.OnRenderFrameEvent += _asteroidsPool.RenderElements;

        }

        public static void StartGame()
        {
            _window?.Run();
        }

        public static void RestartGame()
        {
            _player?.RestartPlayer();
            _asteroidsPool?.RestartPool();
        }
    }
}
