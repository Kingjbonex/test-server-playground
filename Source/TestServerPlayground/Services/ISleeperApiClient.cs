using System.Collections.Generic;
using System.Threading.Tasks;
using TestServerPlayground.Services.Models;

namespace TestServerPlayground.Services
{
    public interface ISleeperApiClient
    {
        Task<SleeperUser> GetUserAsync(string name);

        Task<List<SleeperLeague>> GetUsersLeaguesAsync(string name);
    }
}
