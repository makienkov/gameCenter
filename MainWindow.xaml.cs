using gameCenter.Projects;
using gameCenter.Projects.CurrencyConverter;
using gameCenter.Projects.Project1;
using gameCenter.Projects.TodoList;
using gameCenter.Projects.TicTacToe;
using gameCenter.Projects.Calculator;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using gameCenter.Projects.Car;

namespace gameCenter
{
	public partial class MainWindow
	{

		public MainWindow()
		{
			InitializeComponent();

			DateLabel.Content = DateTime.UtcNow.AddHours(-1).ToString("dddd, dd MMMM yyyy HH:mm:ss");

			DispatcherTimer clock = new()
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			clock.Tick += ShowCurrentDate!;
			clock.Start();

		}

		private void ShowCurrentDate(object sender, EventArgs e)
		{
			DateLabel.Content = DateTime.UtcNow.AddHours(2).ToString("dddd, dd MMMM yyyy HH:mm:ss");
		}

		private void Image_MouseEnter(object sender, MouseEventArgs e)
		{
			Image image = (sender as Image)!;
			image.Opacity = 0.7;
			GameText.Content = (image.Name) switch
			{
				"Image1" => "a User Management System",
				"Image2" => "Currency Convertor",
				"Image3" => "Tic Tac Toe Game",
				"Image4" => "Car Game",
				"Image5" => "Calculator",
				"Image6" => "Task Management Software",
				_ => "please pick an app"
			};
		}

		private void Image_MouseLeave(object sender, MouseEventArgs e)
		{
			(sender as Image)!.Opacity = 1;
			GameText.Content = "please pick a game";
		}

		private void ShowProjectWindow(Window projectWindow)
		{
			Hide();
			projectWindow.ShowDialog();
			projectWindow.Close();
			Show();
		}

		private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{

			ProjectPresentation page = new();

			string introImage1 = "User Management System: \n";
			introImage1 += "Using this program you can: \n";
			introImage1 += "Add and Remove users,  \n";
			introImage1 += "Mark user as Login and Freeze,  \n";
			introImage1 += "Update user data,  \n";
			introImage1 += "Save the modified data to file so that it will be loaded on next startup,  \n";
			introImage1 += "Close the window to continue..  \n";

			page.OnStartUp(introImage1, Image1.Source);

			ShowProjectWindow(page);

			Project1 project1 = new();
			ShowProjectWindow(project1);

		}

		private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ProjectPresentation page = new();

			var introImage2 = "Currency convertor: \n";
			introImage2 += "Using this program you can: \n";
			introImage2 += "Calculate the value of other currency,  \n";
			introImage2 += "This program uses real API service,  \n";
			introImage2 += "So internet connection is required.  \n";
			introImage2 += "exchangeratesapi_api_key = global system variable name with the API key for exchangeratesapi.io  \n";
			introImage2 += "Close the window to continue..  \n";

			page.OnStartUp(introImage2, Image2.Source);

			ShowProjectWindow(page);
			CurrencyConverterView project2 = new();
			ShowProjectWindow(project2);
		}

		private void Image3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ProjectPresentation page = new();

			var introImage3 = "Tic Tac Toe Game: \n";
			introImage3 += "3 in row or diagonal to win ! \n";
			introImage3 += "Close the window to continue..  \n";

			page.OnStartUp(introImage3, Image3.Source);

			ShowProjectWindow(page);
			TicTacToe project3 = new();
			ShowProjectWindow(project3);
		}

		private void Image4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ProjectPresentation page = new();

			var introImage4 = "Car Bombs Game: \n";
			introImage4 += "Try to evade the bombs to win ! \n";
			introImage4 += "Close the window to continue..  \n";

			page.OnStartUp(introImage4, Image4.Source);

			ShowProjectWindow(page);
			CarBomb project4 = new();
			ShowProjectWindow(project4);
		}

		private void Image5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ProjectPresentation page = new();

			var introImage5 = "Calculator: \n";
			introImage5 += "+,-,%,* for integer numbers \n";
			introImage5 += "Close the window to continue..  \n";

			page.OnStartUp(introImage5, Image5.Source);

			ShowProjectWindow(page);
			Calculator project5 = new();
			ShowProjectWindow(project5);
		}


		private void Image6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ProjectPresentation page = new();

			var introImage6 = "Task Management Software: \n";
			introImage6 += "Using this program you can: \n";
			introImage6 += "Manage the tasks you plan to complete,  \n";
			introImage6 += "Mark as done tasks completed,  \n";
			introImage6 += "Close the window to continue..  \n";

			page.OnStartUp(introImage6, Image6.Source);

			ShowProjectWindow(page);

			TodoList project6 = new();
			ShowProjectWindow(project6);
		}


	}
}
