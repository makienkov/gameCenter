using System.Windows;
using System.Windows.Controls;

namespace gameCenter.Projects.Car
{

    internal abstract class GameObject
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public Image Representation { get; set; }  // using System.Windows.Controls;

		public GameObject (int x, int y, int speed, Image representation)
        {
            X = x;
            Y = y;
            Speed = speed;
            Representation = representation;
        }
        public abstract void Move();

        public void Draw()
        {
            Representation.Margin = new Thickness(X,Y,0,0);  // using System.Windows;
		}

    }

}
