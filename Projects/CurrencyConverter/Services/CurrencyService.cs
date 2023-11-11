using gameCenter.Projects.CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace gameCenter.Projects.CurrencyConverter.Services
{
	internal class CurrencyService
	{
		// exchangeratesapi.io
		// json2csharp.com

		//{
		//    "success": true,
		//    "timestamp": 1519296206,
		//    "base": "EUR",
		//    "date": "2021-03-17",
		//    "rates": {
		//        "AUD": 1.566015,
		//        "CAD": 1.560132,
		//        "CHF": 1.154727,
		//        "CNY": 7.827874,
		//        "GBP": 0.882047,
		//        "JPY": 132.360679,
		//        "USD": 1.23396,
		//    }
		//}



		private const string BaseApiEndPoint = "http://api.exchangeratesapi.io/latest";
		private static readonly string ApiKey = Environment.GetEnvironmentVariable("exchangeratesapi_api_key");

		private HttpClient Http_Client = new();
		// work with file\appi\server -> use try \ catch -> so error handled no crash


		public async Task<Dictionary<string, double>?> GetExchangeRatesAsync() // Task - return async. wait to finish
		{
			string requestUrl = $"{BaseApiEndPoint}?access_key={ApiKey}";
			string response = await Http_Client.GetStringAsync(requestUrl); // await-async,  gets entire unparces resp.
			JsonSerializerOptions options = new JsonSerializerOptions
			{   // ExchangeResponse -> Success/Timestamp... w/Capital naming
				// we add this option - to ignore and match to variables 
				PropertyNameCaseInsensitive = true,
			};


			ExchangeResponse exchangeData = JsonSerializer.Deserialize<ExchangeResponse>(response, options);

			if (exchangeData == null || exchangeData.Rates == null)
				throw new InvalidOperationException("Failed to fetch exchange rates.");

			return exchangeData.Rates;
		}



	}
}
