using OpenTK.Windowing.Desktop;

namespace Core
{
    public struct Transform
    {
        public float X;
        public float Y;
        public float Angle;

        public Transform(float x, float y)
        {
            X = x;
            Y = y;
            Angle = 0;
        }

        public Transform(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }

        public Transform GetNativeCoordinates(GameWindow window) => new((window.Size.X + X) / 2, (window.Size.Y + Y) / 2);
    }
}
