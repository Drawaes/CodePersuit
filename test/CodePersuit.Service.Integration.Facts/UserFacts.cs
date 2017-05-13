using System;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using CodePersuit.Service.Sdk;
using System.Threading.Tasks;

namespace CodePersuit.Service.Integration.Facts
{
    public class UserFacts : IDisposable
    {
        private IWebHost _host;

        public UserFacts()
        {
            _host = new WebHostBuilder()
                .UseUrls("http://localhost:7777")
                .UseKestrel()
                .UseStartup<Core.Startup>()
                .Build();
            _host.Start();
        }

        [Fact]
        public async Task CanLoadUserFact()
        {
            var client = new CodePersuitAPI(new Uri("http://localhost:7777"));
            var user = await client.GetUserByUsernameAsync("Drawaes");

            Assert.Equal(1, user.UserId);
            Assert.Equal("Drawaes", user.Username);
        }

        [Fact]
        public async Task UserNotFoundFact()
        {
            var client = new CodePersuitAPI(new Uri("http://localhost:7777"));

            await Assert.ThrowsAsync<Microsoft.Rest.HttpOperationException>(async () => await client.GetUserByUsernameAsync("randomUser"));
        }

        public void Dispose() => _host.Dispose();
    }
}

