using Logging;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace WindowAPI
{
    public class Window : GameWindow
    {
        public Action<Window, FrameEventArgs>? OnUpdateFrameEvent;
        public Action<Window>? OnRenderFrameEvent;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Logger.Debug(GL.GetString(StringName.Version));
            Logger.Debug(GL.GetString(StringName.Vendor));
            Logger.Debug(GL.GetString(StringName.Renderer));
            Logger.Debug(GL.GetString(StringName.ShadingLanguageVersion));
        }

        protected override void OnLoad()
        {
            base.OnLoad();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            OnUpdateFrameEvent?.Invoke(this, args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            OnRenderFrameEvent?.Invoke(this);

            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }

        public override void Close()
        {
            Logger.Information("App has been closed");

            base.Close();
        }
    }
}
