using WindowAPI;
using OpenTK.Windowing.Common;
using Logging;
using Asteroids;

var player = new Player();

player.Speed = 10;

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

window.OnUpdateFrameEvent += GameUtils.FPSCounter;
window.OnUpdateFrameEvent += player.Update;
window.OnRenderFrameEvent += player.Render;

window.Run();
