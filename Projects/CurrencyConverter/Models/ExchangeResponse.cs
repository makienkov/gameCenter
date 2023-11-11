using System.Collections.Generic;

namespace gameCenter.Projects.CurrencyConverter.Models
{
	internal class ExchangeResponse
	{
		// [JsonPropertyName("success") ]
		// alternative for using JsonSerializerOptions

		public bool Success { get; set; }
		public long Timestamp { get; set; }
		public string Base { get; set; }
		public string Date { get; set; }
		public Dictionary<string, double>? Rates { get; set; }


	}
}
