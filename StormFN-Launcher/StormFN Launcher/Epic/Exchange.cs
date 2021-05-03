using System;
using System.Text.Json.Serialization;

namespace StormFN_Launcher.Epic
{
	public class Exchange
	{
		[JsonPropertyName("expiresInSeconds")]
		public int ExpiresInSeconds { get; set; }

		[JsonPropertyName("code")]
		public string Code { get; set; }

		[JsonPropertyName("creatingClientId")]
		public string CreatingClientId { get; set; }
	}
}
