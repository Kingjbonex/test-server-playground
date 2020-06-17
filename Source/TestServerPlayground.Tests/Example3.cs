using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestServerPlayground.Services;
using TestServerPlayground.Services.Models;
using TestServerPlayground.Tests.MockService;

namespace TestServerPlayground.Tests
{
    [TestFixture]
	public class Example3
	{
        [Test]
        public async Task Test1()
        {
            // Configure the Host Builder
            IHostBuilder hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();

                    // Specify the environment
                    webHost.UseStartup<TestServerPlayground.Startup>();
                });

            // Build and start the Host
            IHost host = await hostBuilder.StartAsync();

            // Create an HttpClient to send requests to the TestServer
            HttpClient client = host.GetTestClient();

            string username = "kingjbonex";

            // Make a call to the base route
            HttpResponseMessage response = await client.GetAsync($"/api/sleeper/{username}");

            // Assert we got the successful response
            Assert.That(response.IsSuccessStatusCode, Is.True);

            // Assert the content is as expected
            string responseContent = await response.Content.ReadAsStringAsync();

            SleeperUser sleeperUser = JsonSerializer.Deserialize<SleeperUser>(responseContent);

            Assert.That(sleeperUser.Name, Is.EqualTo(username));
        }

        [Test]
        public async Task Test2()
        {
            // Configure the Host Builder
            IHostBuilder hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();

                    // Specify the environment
                    webHost.UseStartup<TestServerPlayground.Startup>();

                    webHost.ConfigureTestServices(services =>
                    {

                        //Remove SleeperApiClient
                        services.Remove(services.Single(x => x.ServiceType == typeof(ISleeperApiClient)));

                        //Add MockSleeperApiClient
                        services.AddTransient(typeof(ISleeperApiClient), typeof(MockSleeperApiClient));
                    });
                });

            // Build and start the Host
            IHost host = await hostBuilder.StartAsync();

            // Create an HttpClient to send requests to the TestServer
            HttpClient client = host.GetTestClient();

            // Make a call to the base route
            HttpResponseMessage response = await client.GetAsync($"/api/sleeper/anyvalue");

            // Assert we got the successful response
            Assert.That(response.IsSuccessStatusCode, Is.True);

            // Assert the content is as expected
            string responseContent = await response.Content.ReadAsStringAsync();

            SleeperUser sleeperUser = JsonSerializer.Deserialize<SleeperUser>(responseContent);

            Assert.That(sleeperUser.Name, Is.EqualTo("Test User"));
        }
    }
}
