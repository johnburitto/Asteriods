using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
namespace Core
{
    public abstract class GameObject
    {
        public Transform Position;
        public List<Vector2i>? Points;

        protected virtual void Awake()
        {

        }

        protected virtual void Create()
        {

        }

        public virtual void Update(KeyboardState state)
        {

        }

        public virtual void Render(WindowAPI.Window window)
        {

        }
    }
}
