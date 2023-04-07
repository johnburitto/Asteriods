using Core;

namespace Asteroids
{
    internal class PlayerAsteroidColliderScenario : ColliderScenario<Player, ObjectPoolItem<Asteroid>>
    {
        protected override void Scenario(Player firstObj, ObjectPoolItem<Asteroid> secondObj)
        {
            var firstMinX = firstObj.Collider.Points[0].X + firstObj.Position.X;
            var firstMinY = firstObj.Collider.Points[0].Y + firstObj.Position.Y;
            var firstMaxX = firstObj.Collider.Points[2].X + firstObj.Position.X;
            var firstMaxY = firstObj.Collider.Points[2].Y + firstObj.Position.Y;
            
            var secondMinX = secondObj.Object.Collider.Points[0].X + secondObj.Object.Position.X;
            var secondMinY = secondObj.Object.Collider.Points[0].Y + secondObj.Object.Position.Y;
            var secondMaxX = secondObj.Object.Collider.Points[2].X + secondObj.Object.Position.X;
            var secondMaxY = secondObj.Object.Collider.Points[2].Y + secondObj.Object.Position.Y;

            if (firstMinX > secondMinX && firstMinX < secondMaxX && firstMinY > secondMinY && firstMinY < secondMaxY ||
                firstMaxX > secondMinX && firstMaxX < secondMaxX && firstMaxY > secondMinY && firstMaxY < secondMaxY) 
            {
                Game.RestartGame();
            }
        }
    }
}
