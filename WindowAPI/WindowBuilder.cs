using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace WindowAPI
{
    public class WindowBuilder
    {
        private NativeWindowSettings _settings = new NativeWindowSettings();
        private Window? _window;

        public WindowBuilder WithSize(int width, int height)
        {
            _settings.Size = new Vector2i(width, height);

            return this;
        }
        
        public WindowBuilder WithLocation(int xPos, int yPos)
        {
            _settings.Location = new Vector2i(xPos, yPos);

            return this;
        }
        
        public WindowBuilder WithWindowBorder(WindowBorder border)
        {
            _settings.WindowBorder = border;

            return this;
        }
        
        public WindowBuilder WithWindowState(WindowState state)
        {
            _settings.WindowState = state;

            return this;
        }
        
        public WindowBuilder WithTitle(string title)
        {
            _settings.Title = title;

            return this;
        }
        
        public WindowBuilder WithFlags(ContextFlags flags)
        {
            _settings.Flags = flags;

            return this;
        }
        
        public WindowBuilder WithApiVersion(int major, int minor)
        {
            _settings.APIVersion = new Version(major, minor);

            return this;
        }

        public WindowBuilder WithProfile(ContextProfile profile)
        {
            _settings.Profile = profile;

            return this;
        }
        
        public WindowBuilder WithApi(ContextAPI api)
        {
            _settings.API = api;

            return this;
        }

        public WindowBuilder WithNumberOfSamples(int numberOfSamples)
        {
            _settings.NumberOfSamples = numberOfSamples;

            return this;
        }

        public WindowBuilder WithVsync()
        {
            _window = _window ?? new Window(GameWindowSettings.Default, _settings);
            _window.VSync = VSyncMode.On;

            return this;    
        }

        public Window Buid()
        {
            _window = _window ?? new Window(GameWindowSettings.Default, _settings);

            return _window;
        }
    }
}
