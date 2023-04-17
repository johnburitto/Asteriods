using Core;

namespace Asteroids
{
    internal class BulletAsteroidColliderScenario : ColliderScenario<Bullet, ObjectPoolItem<Asteroid>>
    {
        protected override void Scenario(Bullet firstObj, ObjectPoolItem<Asteroid> secondObj)
        {
            if (firstObj.State != BulletState.Rendering && secondObj.State != ItemState.Rendering)
            {
                return;
            }

            var firstMinX = firstObj.Collider.Points[0].X + firstObj.Position.X;
            var firstMinY = firstObj.Collider.Points[0].Y + firstObj.Position.Y;
            var firstMaxX = firstObj.Collider.Points[1].X + firstObj.Position.X;
            var firstMaxY = firstObj.Collider.Points[1].Y + firstObj.Position.Y;

            var secondMinX = secondObj.Object.Collider.Points[0].X + secondObj.Object.Position.X;
            var secondMinY = secondObj.Object.Collider.Points[0].Y + secondObj.Object.Position.Y;
            var secondMaxX = secondObj.Object.Collider.Points[2].X + secondObj.Object.Position.X;
            var secondMaxY = secondObj.Object.Collider.Points[2].Y + secondObj.Object.Position.Y;

            if (firstMinX > secondMinX && firstMinX < secondMaxX && firstMinY > secondMinY && firstMinY < secondMaxY ||
                firstMaxX > secondMinX && firstMaxX < secondMaxX && firstMaxY > secondMinY && firstMaxY < secondMaxY)
            {
                firstObj.State = BulletState.Hide;
                secondObj.State = ItemState.Disable;

                ParticleSystem.InitParticles(20, secondObj.Object.Position, 1);
                Game.Score += 100;
                MediaSystem.PlaySound("explosion.wav");
            }
        }
    }
}
