using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;
using System.Drawing;

namespace Core
{
    public static class PrimitiveRenderer
    {
        public static void RenderLineLoop(GameObject obj, GameWindow window)
        {
            GL.MatrixMode(MatrixMode.Projection);

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.LineLoop);

            for (int i = 0; i < obj.Points?.Count; i++)
            {
                GL.Vertex3((obj.Position.X + obj.Points[i].X) / window.Size.X, 
                    (obj.Position.Y + obj.Points[i].Y) / window.Size.Y, 1);
            }

            GL.End();
        }

        public static void RenderLine(GameObject obj, GameWindow window)
        {
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);

            for (int i = 0; i < obj.Points?.Count; i++)
            {
                GL.Vertex2((obj.Position.X + obj.Points[i].X) / window.Size.X, 
                    (obj.Position.Y + obj.Points[i].Y) / window.Size.Y);
            }

            GL.End();
        }

        public static void RenderCollider(Collider collider, Transform position, GameWindow window)
        {
            GL.Color3(Color.Green);
            GL.Begin(PrimitiveType.LineLoop);

            for (int i = 0; i < collider.Points.Count; i++)
            {
                GL.Vertex2((position.X + collider.Points[i].X) / window.Size.X,
                    (position.Y + collider.Points[i].Y) / window.Size.Y);
            }

            GL.End();
            GL.Color3(Color.White);
        }
    }
}
