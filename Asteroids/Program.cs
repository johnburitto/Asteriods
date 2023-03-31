using WindowAPI;
using OpenTK.Windowing.Common;
using Asteroids;
using Core;
using Logging;

var player = new Player();
var asteroidsPool = new AsteroidsPool();
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

player.Speed = 10;
asteroidsPool.InitItems(3, window);

window.OnUpdateFrameEvent += GameUtils.FPSCounter;
window.OnUpdateFrameEvent += player.Update;
window.OnRenderFrameEvent += player.Render;
window.OnRenderFrameEvent += asteroidsPool.RenderElements;

window.Run();
