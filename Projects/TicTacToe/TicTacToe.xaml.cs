using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gameCenter.Projects.TicTacToe
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class TicTacToe
	{
		private char _currentPlayer = 'X';
		private readonly char[,] _gameBoard = new char[3, 3];

		public TicTacToe()
		{
			InitializeComponent();
			InitializeGameBoard();
		}

		private void InitializeGameBoard()
		{
			for (int row = 0; row < 3; row++)
			{
				for (int col = 0; col < 3; col++)
				{
					_gameBoard[row, col] = ' ';
				}
			}
		}

		private void OnButtonClick(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			int row = Grid.GetRow(button);
			int col = Grid.GetColumn(button);

			if (_gameBoard[row, col] == ' ' && !IsGameFinished())
			{
				_gameBoard[row, col] = _currentPlayer;
				button.Content = _currentPlayer;

				// Check for a win or draw before switching players
				if (IsGameFinished())
				{
					UpdateStatusLabel($"Player {_currentPlayer} wins!");
				}
				else if (IsBoardFull())
				{
					UpdateStatusLabel("It's a draw!");
				}
				else
				{
					// Only switch players if the game is not finished
					_currentPlayer = (_currentPlayer == 'X') ? 'O' : 'X';
				}
			}
		}


		private bool IsGameFinished()
		{
			return CheckForWin('X') || CheckForWin('O');
		}

		private bool IsBoardFull()
		{
			for (int row = 0; row < 3; row++)
			{
				for (int col = 0; col < 3; col++)
				{
					if (_gameBoard[row, col] == ' ')
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool CheckForWin(char player)
		{
			for (int i = 0; i < 3; i++)
			{
				if (_gameBoard[i, 0] == player && _gameBoard[i, 1] == player && _gameBoard[i, 2] == player)
					return true;
			}

			for (int i = 0; i < 3; i++)
			{
				if (_gameBoard[0, i] == player && _gameBoard[1, i] == player && _gameBoard[2, i] == player)
					return true;
			}

			if (_gameBoard[0, 0] == player && _gameBoard[1, 1] == player && _gameBoard[2, 2] == player)
				return true;

			if (_gameBoard[0, 2] == player && _gameBoard[1, 1] == player && _gameBoard[2, 0] == player)
				return true;

			return false;
		}

		private void UpdateStatusLabel(string message)
		{
			StatusLabel.Text = message;
		}

	}
}
