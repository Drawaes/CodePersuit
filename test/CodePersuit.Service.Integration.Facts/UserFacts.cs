using System;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using CodePersuit.Service.Sdk;
using System.Threading.Tasks;

namespace CodePersuit.Service.Integration.Facts
{
    public class UserFacts
    {
        [Fact]
        public async Task CanLoadUserFact()
        {
            using (var host = new WebHostBuilder()
                .UseUrls("http://localhost:7777")
                .UseKestrel()
                .UseStartup<Core.Startup>()
                .Build())
            {
                host.Start();

                var client = new CodePersuitAPI(new Uri("http://localhost:7777"));
                var user = await client. GetUserByUsernameAsync("Drawaes");

                Assert.Equal(1, user.UserId);
                Assert.Equal("Drawaes", user.Username);
            }
        }
    }
}
