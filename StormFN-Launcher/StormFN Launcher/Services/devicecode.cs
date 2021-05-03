using System;
using System.Text.Json.Serialization;

namespace StormFN_Launcher.Services
{
	public class devicecode
	{
		[JsonPropertyName("user_code")]
		public int user_code { get; set; }

		[JsonPropertyName("device_code")]
		public string device_code { get; set; }

		[JsonPropertyName("verification_uri")]
		public string verification_uri { get; set; }

		[JsonPropertyName("verification_uri_complete")]
		public string verification_uri_complete { get; set; }

		[JsonPropertyName("prompt")]
		public string prompt { get; set; }

		[JsonPropertyName("expires_in")]
		public string expires_in { get; set; }

		[JsonPropertyName("interval")]
		public string interval { get; set; }

		[JsonPropertyName("client_id")]
		public string client_id { get; set; }
	}
}
