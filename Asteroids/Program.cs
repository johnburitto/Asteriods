using WindowAPI;
using OpenTK.Windowing.Common;

var builder = new WindowBuilder();
var window = builder
    .WithSize(1920, 1080)
    .WithWindowBorder(WindowBorder.Resizable)
    .WithWindowState(WindowState.Maximized)
    .WithTitle("Asteroids")
    .WithApi(ContextAPI.OpenGL)
    .WithApiVersion(4, 6)
    .WithProfile(ContextProfile.Core)
    .WithFlags(ContextFlags.ForwardCompatible)
    .WithNumberOfSamples(0)
    .Buid();

window.Run();