using gameCenter.Projects.CurrencyConverter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace gameCenter.Projects.CurrencyConverter
{
	/// <summary>
	/// Interaction logic for CurrencyConverterView.xaml
	/// </summary>
	public partial class CurrencyConverterView
	{

		private readonly CurrencyService _currencyService;
		private Dictionary<string, double>? _exchangeRates;

		public CurrencyConverterView()
		{
			InitializeComponent();
			_currencyService = new CurrencyService();
			LoadCurrencies(); //not common to run async function inside a constructor

		}

		private async void LoadCurrencies()
		{
			try
			{
				//We need to execute the method await _currencyService.GetExchangeRatesAsync()
				_exchangeRates = await _currencyService.GetExchangeRatesAsync();
				//get string[] of the keys of the dictionary
				var currencies = _exchangeRates!.Keys.ToArray();
				//set the ItemsSource of the combo boxes to the string array of the currencies names
				FromCurrencyComboBox.ItemsSource = currencies;
				ToCurrencyComboBox.ItemsSource = currencies;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading currencies: {ex.Message}");
			}
		}

		private void btnConvert_Click(object sender, RoutedEventArgs e)
		{
			// Check if the AmountTextBox is not empty and both ComboBoxes have a selected item
			if (string.IsNullOrWhiteSpace(AmountTextBox.Text) ||
			    FromCurrencyComboBox.SelectedItem == null ||
			    ToCurrencyComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please enter an amount and select both currencies.", "Input Error");
				return; // Return to prevent further execution if the validation fails
			}

			try
			{
				var fromCurrency = FromCurrencyComboBox.SelectedItem.ToString();
				var toCurrency = ToCurrencyComboBox.SelectedItem.ToString();
				var amount = double.Parse(AmountTextBox.Text);

				var baseToFromRate = _exchangeRates![fromCurrency!];
				var baseToToRate = _exchangeRates![toCurrency!];
				var convertedAmount = (baseToToRate / baseToFromRate) * amount;
				txtResult.Text = $"Converted Amount: {amount} {fromCurrency} is {convertedAmount:0.00} {toCurrency}";
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error during conversion: {ex.Message}");
			}
		}



	}
}
