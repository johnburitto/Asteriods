namespace Core
{
    public static class Animator
    {
        public static void Rotate(GameObject obj, ref float oldAngle) 
        {
            var cos = MathF.Cos(oldAngle - obj.Position.Angle);
            var sin = MathF.Sin(oldAngle - obj.Position.Angle);

            for (int i = 0; i < obj.Points?.Count; i++)
            {
                obj.Points[i] = new(obj.Points[i].X * cos - obj.Points[i].Y * sin, obj.Points[i].X * sin + obj.Points[i].Y * cos);
            }

            oldAngle = obj.Position.Angle;
        }
    }
}
