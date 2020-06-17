using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestServerPlayground.Tests
{
    public class TestWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        public Action<IServiceCollection> Registrations { get; set; }

        public TestWebApplicationFactory() : this(null)
        {
        }

        public TestWebApplicationFactory(Action<IServiceCollection> registrations = null)
        {
            Registrations = registrations ?? (collection => { });
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                Registrations?.Invoke(services);
            });
        }
    }
}