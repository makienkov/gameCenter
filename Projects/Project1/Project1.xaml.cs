using gameCenter.Projects.Project1.Models;
using gameCenter.Projects.Project1.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;

namespace gameCenter.Projects.Project1
{
	public partial class Project1 : Window
	{
		private readonly UsersListHandler _listHandler;
		private readonly List<User> _users;

		private int _selectedUserId;
		public Project1()
		{
			_listHandler = new();
			_users = _listHandler.UsersList;
			_selectedUserId = 0;

			InitializeComponent();

			UsersDataGrid.ItemsSource = _users;
		}

		private void On_Add_Button_Click(object sender, RoutedEventArgs e)
		{
			if (_listHandler.CheckIfEmailExists(UserEmail.Text))
			{
				MessageBox.Show("Email Already Taken!");
				return;
			}
			if (CheckFields() && Validate.UserName(UserName) && Validate.Email(UserEmail))
			{
				_listHandler.AddUser(
					new User(_users.Count + 1, UserName.Text, UserEmail.Text)
				);

				UpdateGrid();
				ClearFields();
			}
		}
		private void On_Remove_Button_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedUserId == 0)
			{
				MessageBox.Show("Please Pick a User!");
				return;
			}
			_listHandler.RemoveUser(_selectedUserId - 1);
			UpdateGrid();
		}
		private void On_Update_Button_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedUserId == 0)
			{
				MessageBox.Show("Please Pick a User!");
				return;
			}
			_listHandler.UpdateUser(
				new User(_selectedUserId, UserName.Text, UserEmail.Text)
			);

			UpdateGrid();
			ClearFields();
		}

		private void On_ToggleUserLog_Button_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedUserId == 0)
			{
				MessageBox.Show("Please Pick a User!");
				return;
			}
			if (_listHandler.ToggleLogUser(_selectedUserId))
			{
				UpdateGrid();
				return;
			}
			MessageBox.Show("User Status Is Freeze, cant log in!");
		}
		private void On_ToogleFreezeUser_Button_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedUserId == 0)
			{
				MessageBox.Show("Please Pick a User!");
				return;
			}
			_listHandler.ToogleFreezeUser(_selectedUserId);
			UpdateGrid();
		}

		private void On_UserEmail_LostFocus(object sender, EventArgs e)
		{
			Validate.Email(UserEmail);
		}

		private void On_UserName_LostFocus(object sender, RoutedEventArgs e)
		{
			Validate.UserName(UserName);

		}

		private void On_UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (UsersDataGrid.SelectedCells.Count >= 3)
			{
				var idCell = UsersDataGrid.SelectedCells[0];
				var nameCell = UsersDataGrid.SelectedCells[1];
				var emailCell = UsersDataGrid.SelectedCells[2];

				try
				{
					// Handle ID Cell
					if (idCell.Column != null && idCell.Item != null)
					{
						var idCellContent = idCell.Column.GetCellContent(idCell.Item) as TextBlock;
						if (idCellContent != null)
						{
							_selectedUserId = Convert.ToInt16(idCellContent.Text);
						}
						else
						{
							_selectedUserId = 0;
						}
					}

					// Handle Name Cell
					if (nameCell.Column != null && nameCell.Item != null)
					{
						var nameCellContent = nameCell.Column.GetCellContent(nameCell.Item) as TextBlock;
						if (nameCellContent != null)
						{
							UserName.Text = nameCellContent.Text;
						}
						else
						{
							UserName.Text = string.Empty;
						}
					}

					// Handle Email Cell
					if (emailCell.Column != null && emailCell.Item != null)
					{
						var emailCellContent = emailCell.Column.GetCellContent(emailCell.Item) as TextBlock;
						if (emailCellContent != null)
						{
							UserEmail.Text = emailCellContent.Text;
						}
						else
						{
							UserEmail.Text = string.Empty;
						}
					}
				}
				catch
				{
					// General catch for any unexpected exceptions
					_selectedUserId = 0;
					UserName.Text = string.Empty;
					UserEmail.Text = string.Empty;
				}
			}
			else
			{
				// Handle the case where there are not enough selected cells
				_selectedUserId = 0;
				UserName.Text = string.Empty;
				UserEmail.Text = string.Empty;
			}
		}


		private void ClearFields()
		{
			UserEmail.Text = string.Empty;
			UserName.Text = string.Empty;
			_selectedUserId = 0;
		}

		private bool CheckFields()
		{
			if (UserName.Text == String.Empty ||
				UserName.Text == null ||
				UserEmail.Text == String.Empty ||
				UserEmail.Text == null)
			{
				MessageBox.Show("Please Fill All Details!");
				return false;
			}
			return true;
		}

		private void UpdateGrid()
		{
			UsersDataGrid.ItemsSource = _users.ToList();
		}

		private void On_SaveData_Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Serialize the user list to JSON format
				string json = JsonConvert.SerializeObject(_users, Formatting.Indented);

				// Specify the file path where you want to save the data
				string filePath = "../../../Projects/Project1/users_data.json";

				// Write the JSON data to the file
				System.IO.File.WriteAllText(filePath, json);

				MessageBox.Show("Data saved to users_data.json successfully.", "Save Data", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred while saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}


	}
}
