using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;

namespace Core
{
    public static class PrimitiveRenderer
    {
        public static void RenderLineLoop(GameObject obj, GameWindow window)
        {
            GL.Begin(PrimitiveType.LineLoop);

            for (int i = 0; i < obj.Points?.Count; i++)
            {
                GL.Vertex2((obj.Position.X + obj.Points[i].X) / window.Size.X, 
                    (obj.Position.Y + obj.Points[i].Y) / window.Size.Y);
            }

            GL.End();
        }
    }
}
