using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestServerPlayground.Services;
using TestServerPlayground.Services.Models;

namespace TestServerPlayground.Tests
{
	[TestFixture]
	public class Example5
	{
		[Test]
		public async Task Test1()
		{
			Mock<ISleeperApiClient> mockClient = new Mock<ISleeperApiClient>();

			var factory = new TestWebApplicationFactory<Startup>(services =>
			{
				// setup the swaps
				services.SwapTransient<ISleeperApiClient>(provider => mockClient.Object);
			});

			mockClient.Setup(x => x.GetUserAsync(It.IsAny<string>())).ReturnsAsync(new SleeperUser { Name = "My Moq User" });

			// Create an HttpClient which is setup for the test host
			var client = factory.CreateClient();

			// Make a call to the base route
			HttpResponseMessage response = await client.GetAsync($"/api/sleeper/anyvalue");

			// Assert we got the successful response
			Assert.That(response.IsSuccessStatusCode, Is.True);

			// Assert the content is as expected
			string responseContent = await response.Content.ReadAsStringAsync();

			SleeperUser sleeperUser = JsonSerializer.Deserialize<SleeperUser>(responseContent);

			Assert.That(sleeperUser.Name, Is.EqualTo("My Moq User"));

			mockClient.Verify(x => x.GetUserAsync(It.IsAny<string>()), Times.Once);
		}
	}
}
