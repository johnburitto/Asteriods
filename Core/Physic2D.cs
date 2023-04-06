namespace Core
{
    public static class Physic2D
    {
        public static void RotateCollider(Collider collider, float currentAngle, ref float oldAngle)
        {
            var cos = MathF.Cos(oldAngle - currentAngle);
            var sin = MathF.Sin(oldAngle - currentAngle);

            for (int i = 0; i < collider.Points.Count; i++)
            {
                collider.Points[i] = new(collider.Points[i].X * cos - collider.Points[i].Y * sin, collider.Points[i].X * sin + collider.Points[i].Y * cos);
            }
        }

        public static void CheckColliding<T, V>(ColliderScenario<T, V> scenario, T firstObj, V secondObj)
        {
            scenario.ExecuteScenario(firstObj, secondObj);
        }
    }
}
