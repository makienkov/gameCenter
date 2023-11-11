using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace gameCenter.Projects.Car
{
    /// <summary>
    /// Interaction logic for CarBomb.xaml
    /// </summary>
    public partial class CarBomb
    {
        private readonly PlayerCar _playerCar;
        private readonly List<Obstacle> _obstacles;
        private readonly Random _random;

        public CarBomb()
        {
            InitializeComponent();
            _playerCar = new PlayerCar(200, 300, 2, PlayerCarImage, (int)this.Width);
			_obstacles = new List<Obstacle>();
            _random = new Random();

            var gameTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(20)
            };
            gameTimer.Tick += GameLoop!;
            gameTimer.Start();
         
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left:
                    _playerCar.LeftKeyPressed = true;
                    break;
                case Key.Right:
                    _playerCar.RightKeyPressed = true;
                    break;
            }
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left:
                    _playerCar.LeftKeyPressed = false;
                    break;
                case Key.Right:
                    _playerCar.RightKeyPressed = false;
                    break;
            }
        }


        private void GameLoop(object sender, EventArgs e)
        {
            _playerCar.Move();

            if (_random.Next(0, 50) == 1) // 20ms -> 50 times/sec -> 1 bomb per second will generate
            {
                var obstacleImage = new Image
                {
                    Source = new BitmapImage(new Uri("/Projects/Car/bomb.jpg", UriKind.Relative)),
                    Width = 50,
                    Height = 50
				};
                Obstacle obstacle = new Obstacle(_random.Next(0, (int)Width), 0, 2, obstacleImage);
                _obstacles.Add(obstacle);
                GameCanvas.Children.Add(obstacleImage);
            }

            double collisionBuffer = 1;

			foreach (var obstacle in _obstacles)
			{
				obstacle.Move();

				bool isCollision = _playerCar.Representation.Margin.Left + _playerCar.Representation.ActualWidth - collisionBuffer > obstacle.Representation.Margin.Left
								   && _playerCar.Representation.Margin.Left < obstacle.Representation.Margin.Left + obstacle.Representation.ActualWidth
								   && _playerCar.Representation.Margin.Top + _playerCar.Representation.ActualHeight - collisionBuffer > obstacle.Representation.Margin.Top
								   && _playerCar.Representation.Margin.Top < obstacle.Representation.Margin.Top + obstacle.Representation.ActualHeight;

				if (isCollision)
				{
					// End the game
					((sender as DispatcherTimer)!).Stop();

					// Display Game Over message
					MessageBox.Show("Game Over!");

					break;
				}
			}

			// Call the method to remove off-screen obstacles
			RemoveOffScreenObstacles();

			Debug.WriteLine("# of obstacles " + _obstacles.Count.ToString());

		}

		private void RemoveOffScreenObstacles()
		{
			for (int i = _obstacles.Count - 1; i >= 0; i--)
			{
				var obstacle = _obstacles[i];
				if (obstacle.Y > this.Height) // Check if the obstacle has moved past the bottom of the window
				{
					GameCanvas.Children.Remove(obstacle.Representation); // Remove from the canvas
					_obstacles.RemoveAt(i); // Remove from the obstacles list
				}
			}
		}



	}


}
