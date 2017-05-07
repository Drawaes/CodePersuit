using CodePersuit.Service.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePersuit.Service.Core
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters();

            services
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IRepoRepository, RepoRepository>()
                .Configure<DapperConfig>(config =>
                {
                    config.ConfigurationString = $"server=localhost;database=CodePersuit;User ID=sa;Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};";
                });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            logger.AddConsole();
            app.UseMvc();
        }
    }
}
