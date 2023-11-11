using System;
using System.Windows.Controls;

namespace gameCenter.Projects.Car
{
    internal class Obstacle : GameObject
    {
        private readonly int _direction;

        public Obstacle(int x, int y, int speed, Image carImage) : base(x, y, speed, carImage)
        {
            var rand = new Random();
            _direction = rand.Next(-1,2);
        }

        public override void Move()
        {
            Y += Speed;
            X += _direction * Speed;
            Draw();
        }
    }

}
