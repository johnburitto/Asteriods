﻿using Core;
using Logging;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using WindowAPI;

namespace Asteroids
{
    internal class AsteroidsPool : ObjectPool<Asteroid>
    {
        public Player Player { get; set; }
        public Bullet Bullet { get; set; }
        private Random _rnd = new Random();
        private PlayerAsteroidColliderScenario _playerScenario = new PlayerAsteroidColliderScenario();
        private BulletAsteroidColliderScenario _bulletScenario = new BulletAsteroidColliderScenario();

        public override void InitItems(int number, GameWindow window)
        {
            base.InitItems(number, window);

            foreach (var el in Pool)
            {
                el.Object.Position.X = _rnd.Next(-window.Size.X, window.Size.X);
                el.Object.Position.Y = _rnd.Next(-window.Size.Y, window.Size.Y);
            }
        }

        public void UpdateElements(Window window, FrameEventArgs args)
        {
            foreach (var el in Pool)
            {
                window.OnUpdateFrameEvent += el.Object.Update;

                if (el.State == ItemState.Rendering)
                {
                    Physic2D.CheckColliding(_playerScenario, Player, el);
                    Physic2D.CheckColliding(_bulletScenario, Bullet, el);
                }
            }
        }

        public void RenderElements(Window window)
        {
            foreach (var el in Pool)
            {
                if (el.State == ItemState.Enable)
                {
                    window.OnRenderFrameEvent += el.Object.Render;
                    el.State = ItemState.Rendering;
                }
                else if (el.State == ItemState.Disable)
                {
                    window.OnRenderFrameEvent -= el.Object.Render;
                }
            }
        }

        public void RestartPool()
        {
            foreach (var el in Pool)
            {
                el.State = ItemState.Enable;
            }
        }
    }
}
