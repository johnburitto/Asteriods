using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Core
{
    public abstract class GameObject
    {
        public Transform Position;
        public List<Vector2>? Points;

        protected virtual void Awake()
        {

        }

        protected virtual void Create()
        {

        }

        public virtual void Update(GameWindow window, FrameEventArgs args)
        {

        }

        public virtual void Render(GameWindow window)
        {

        }
    }
}
