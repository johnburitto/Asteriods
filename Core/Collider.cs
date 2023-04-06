using OpenTK.Mathematics;

namespace Core
{
    public class Collider
    {
        public float X { get; set; }
        public float Y { get; set; }
        public List<Vector2> Points { get; set; }

        public Collider()
        {
            Points = new List<Vector2>();
        }

        public void InitPoints()
        {
            Points = new() 
            {
                new(-X/2, -Y/2),
                new(X/2, -Y/2),
                new(X/2, Y/2),
                new(-X/2, Y/2)
            };
        } 
    }
}
