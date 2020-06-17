using System.Text.Json.Serialization;

namespace TestServerPlayground.Services.Models
{
	public class SleeperUser
	{
		[JsonPropertyName("username")]
		public string Name { get; set; }

		[JsonPropertyName("user_id")]
		public string UserID { get; set; }
	}
}
