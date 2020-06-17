using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestServerPlayground.Services;
using TestServerPlayground.Services.Models;

namespace TestServerPlayground.Pages
{
	public class SleeperLeagueModel : PageModel
    {
        private readonly ILogger<SleeperLeagueModel> _logger;
        private readonly ISleeperApiClient _sleeperClient;

        public List<SleeperLeague> SleeperLeagues { get; internal set; }

        public SleeperLeagueModel(ILogger<SleeperLeagueModel> logger, ISleeperApiClient sleeperApiClient)
        {
            _logger = logger;
            _sleeperClient = sleeperApiClient;
        }

        public async Task OnGetAsync()
        {
            var user = await _sleeperClient.GetUserAsync("kingjbonex");

            SleeperLeagues = await _sleeperClient.GetUsersLeaguesAsync(user.UserID);
        }
    }
}
