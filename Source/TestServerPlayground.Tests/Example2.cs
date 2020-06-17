using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestServerPlayground.Tests
{
    [TestFixture]
	public class Example2
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

            // Make a call to the base route
            HttpResponseMessage response = await client.GetAsync("/api/test");

            // Assert we got the successful response
            Assert.That(response.IsSuccessStatusCode, Is.True);

            // Assert the content is as expected
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.That(responseContent, Is.EqualTo("Hello, Testers! I am coming from WebApi."));
        }
    }
}
