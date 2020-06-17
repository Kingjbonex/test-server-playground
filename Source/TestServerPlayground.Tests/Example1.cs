using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestServerPlayground.Tests
{
    [TestFixture]
    public class Example1
    {
        [Test, Description("Not testing anything, just verifying that we can inject in a response at the base route.")]
        public async Task Test1()
        {
            // Configure the Host Builder
            IHostBuilder hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();

                    // Specify the environment
                    webHost.UseEnvironment("Test");

                    System.Action<IApplicationBuilder> configureApp = app => app.Run(async ctx => await ctx.Response.WriteAsync("Hello, Testers!"));
                    webHost.Configure(configureApp);
                });

            // Build and start the Host
            IHost host = await hostBuilder.StartAsync();

            // Create an HttpClient to send requests to the TestServer
            HttpClient client = host.GetTestClient();

            // Make a call to the base route
            HttpResponseMessage response = await client.GetAsync("/");

            // Assert we got the successful response
            Assert.That(response.IsSuccessStatusCode, Is.True);

            // Assert the content is as expected
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.That(responseContent, Is.EqualTo("Hello, Testers!"));
        }
    }
}