using CodePersuit.Service.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Converters;

namespace CodePersuit.Service.Core
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters()
                .AddJsonOptions(j =>
                {
                    j.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Code Persuit API", Version = "v1", License = new License() { Name = "MIT" } });
            });

            services
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IRepoRepository, RepoRepository>();
            
            services.Configure<DapperConfig>(config =>
                {
                    config.ConfigurationString = $"server=localhost;database=CodePersuit;User ID=sa;Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};";
                });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            logger.AddConsole();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Code Persuit API");
            });
        }
    }
}
