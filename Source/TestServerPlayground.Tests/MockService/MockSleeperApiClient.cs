using System.Collections.Generic;
using System.Threading.Tasks;
using TestServerPlayground.Services;
using TestServerPlayground.Services.Models;

namespace TestServerPlayground.Tests.MockService
{
	public class MockSleeperApiClient : ISleeperApiClient
	{
		public Task<SleeperUser> GetUserAsync(string name)
		{
			return Task.FromResult(new SleeperUser { Name = "Test User" });
		}

		public Task<List<SleeperLeague>> GetUsersLeaguesAsync(string name)
		{
			throw new System.NotImplementedException();
		}
	}
}
