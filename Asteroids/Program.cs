using WindowAPI;
using OpenTK.Windowing.Common;
using Logging;
using Asteroids;
using OpenTK.Windowing.GraphicsLibraryFramework;

float frameTime = 0;
int fps = 0;
var player = new Player();

var builder = new WindowBuilder();
var window = builder
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

window.OnUpdateFrameEvent += FPSCounter;
window.KeyboardEvent += player.Update;
window.OnRenderFrameEvent += player.Render;

window.Run();

void FPSCounter(FrameEventArgs args)
{
    frameTime += (float)args.Time;
    fps++;

    if (frameTime > 1.0f)
    {
        Logger.Debug($"FPS => {fps}");
        
        fps = 0;
        frameTime = 0.0f;
    }
}
