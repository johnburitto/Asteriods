using OpenTK.Mathematics;

namespace Core
{
    public static class Physic2D
    {
        public static void RotateCollider(Collider collider, float currentAngle, float oldAngle)
        {
            var cos = MathF.Cos(oldAngle - currentAngle);
            var sin = MathF.Sin(oldAngle - currentAngle);

            for (int i = 0; i < collider.Points.Count; i++)
            {
                collider.Points[i] = new(collider.Points[i].X * cos - collider.Points[i].Y * sin, collider.Points[i].X * sin + collider.Points[i].Y * cos);
            }
        }

        public static Vector2 RotateVector(Vector2 oldVector, float currentAngle, float oldAngle)
        {
            var cos = MathF.Cos(oldAngle - currentAngle);
            var sin = MathF.Sin(oldAngle - currentAngle);

            return new(oldVector.X * cos - oldVector.Y * sin, oldVector.X * sin + oldVector.Y * cos);
        }

        public static void CheckColliding<T, V>(ColliderScenario<T, V> scenario, T firstObj, V secondObj)
        {
            scenario.ExecuteScenario(firstObj, secondObj);
        }
    }
}
