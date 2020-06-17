using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestServerPlayground.Services.Models;

namespace TestServerPlayground.Services
{
    public class SleeperApiClient : ISleeperApiClient
    {
        /// <summary>
        /// The base address for the Sleeper API
        /// </summary>
        public static readonly Uri SleeperApiUrl = new Uri("https://api.sleeper.app/");

        private readonly HttpClient _httpClient;

        public SleeperApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = SleeperApiUrl;
        }

        /// <summary>
        /// https://api.sleeper.app/v1/user/<username>
        /// </summary>
        /// <param name="name">Name of User account.</param>
        /// <returns></returns>
        public async Task<SleeperUser> GetUserAsync(string name)
        {
            var response = await _httpClient.GetAsync($"/v1/user/{name}");
            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SleeperUser>(responseAsString);
        }

        /// <summary>
        /// https://api.sleeper.app/v1/user/<user_id>/leagues/<sport>/<season>
        /// </summary>
        /// <param name="name">Name of User account.</param>
        /// <returns></returns>
        public async Task<List<SleeperLeague>> GetUsersLeaguesAsync(string name)
        {
            var response = await _httpClient.GetAsync($"/v1/user/{name}/leagues/nfl/2020");
            var responseAsString = await response.Content.ReadAsStringAsync();
            List<SleeperLeague> leagues = JsonSerializer.Deserialize<List<SleeperLeague>>(responseAsString);
            return leagues;
        }
    }
}