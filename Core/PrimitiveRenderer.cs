using OpenTK.Graphics.OpenGL;
using WindowAPI;

namespace Core
{
    public static class PrimitiveRenderer
    {
        public static void RenderLineLoop(GameObject obj, Window window)
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
