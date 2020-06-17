using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestServerPlayground.Services;
using TestServerPlayground.Services.Models;
using TestServerPlayground.Tests.MockService;

namespace TestServerPlayground.Tests
{
	[TestFixture]
	public class Example4
	{
		[Test]
		public async Task Test1Async()
		{
			// Arrange
			var factory = new WebApplicationFactory<Startup>();

			// Create an HttpClient which is setup for the test host
			var client = factory.CreateClient();

			// Make a call to the base route
			HttpResponseMessage response = await client.GetAsync("/api/test");

			// Assert we got the successful response
			Assert.That(response.IsSuccessStatusCode, Is.True);

			// Assert the content is as expected
			string responseContent = await response.Content.ReadAsStringAsync();
			Assert.That(responseContent, Is.EqualTo("Hello, Testers! I am coming from WebApi."));
		}

		[Test]
		public async Task Test2()
		{
			var factory = new TestWebApplicationFactory<Startup>(services =>
			{
				// setup the swaps
				services.SwapTransient<ISleeperApiClient, MockSleeperApiClient>();
			});

			// Create an HttpClient which is setup for the test host
			var client = factory.CreateClient();

			// Make a call to the base route
			HttpResponseMessage response = await client.GetAsync("/api/sleeper/anyvalue");

			// Assert we got the successful response
			Assert.That(response.IsSuccessStatusCode, Is.True);

			// Assert the content is as expected
			string responseContent = await response.Content.ReadAsStringAsync();

			SleeperUser sleeperUser = JsonSerializer.Deserialize<SleeperUser>(responseContent);

			Assert.That(sleeperUser.Name, Is.EqualTo("Test User"));
		}
	}
}
