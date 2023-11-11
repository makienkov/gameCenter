using System.Windows.Controls;

namespace gameCenter.Projects.Car
{
	internal class PlayerCar : GameObject
	{
		public bool LeftKeyPressed { get; set; }
		public bool RightKeyPressed { get; set; }
		private readonly int _windowWidth;

		public PlayerCar(int x, int y, int speed, Image carImage, int windowWidth)
			: base(x, y, speed, carImage)
		{
			_windowWidth = windowWidth;
		}


		public override void Move()
		{
			// Debug.WriteLine("PlayerCar Image ActualWidth: " + Representation.ActualWidth);
			// using System.Diagnostics;


			if (LeftKeyPressed && (X > 0))
			{
				X -= Speed;
			}

			if (RightKeyPressed && (X + Representation.ActualWidth * 2 < _windowWidth))
			{
				X += Speed;
			}

			Draw();
		}
	}
}
