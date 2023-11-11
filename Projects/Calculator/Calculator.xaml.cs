using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace gameCenter.Projects.Calculator
{
    public partial class Calculator
    {
        private double _lastNumber, _result;
        private SelectedOperator _selectedOperator;

        public Calculator()
        {
            InitializeComponent();
            ClearButton_Click(null!, null!);
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender is Button button)
            {
                selectedValue = int.Parse(button.Content.ToString()!);
            }

            if (ResultTextBox.Text == "0")
            {
                ResultTextBox.Text = selectedValue.ToString();
            }
            else
            {
                ResultTextBox.Text += selectedValue.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (double.TryParse(ResultTextBox.Text, out _lastNumber))
                {
                    ResultTextBox.Text = "0";
                }

                if (button.Content.ToString() == "+")
                    _selectedOperator = SelectedOperator.Addition;
                else if (button.Content.ToString() == "-")
                    _selectedOperator = SelectedOperator.Subtraction;
                else if (button.Content.ToString() == "*")
                    _selectedOperator = SelectedOperator.Multiplication;
                else if (button.Content.ToString() == "/")
                    _selectedOperator = SelectedOperator.Division;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultTextBox.Text, out newNumber))
            {
                switch (_selectedOperator)
                {
                    case SelectedOperator.Addition:
                        _result = _lastNumber + newNumber;
                        break;
                    case SelectedOperator.Subtraction:
                        _result = _lastNumber - newNumber;
                        break;
                    case SelectedOperator.Multiplication:
                        _result = _lastNumber * newNumber;
                        break;
                    case SelectedOperator.Division:
                        if (newNumber == 0)
                        {
                            MessageBox.Show("Division by zero is not allowed", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        _result = _lastNumber / newNumber;
                        break;
                }

                ResultTextBox.Text = _result.ToString(CultureInfo.CurrentCulture);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "0";
            _lastNumber = 0;
            _result = 0;
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}