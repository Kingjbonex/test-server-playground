using System.Text.Json.Serialization;

namespace TestServerPlayground.Services.Models
{
	public class SleeperLeague
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("total_rosters")]
        public int LeagueSize { get; set; }

        [JsonPropertyName("sport")]
        public string Sport { get; set; }
    }
}
