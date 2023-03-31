using Logging;
using OpenTK.Windowing.Common;
using WindowAPI;

namespace Asteroids
{
    internal static class GameUtils
    {
        private static float _frameTime = 0;
        private static int _fps = 0;

        public static void FPSCounter(Window window, FrameEventArgs args)
        {
            _frameTime += (float)args.Time;
            _fps++;

            if (_frameTime > 1.0f)
            {
                Logger.Debug($"FPS => {_fps}");

                _fps = 0;
                _frameTime = 0.0f;
            }
        }
    }
}
