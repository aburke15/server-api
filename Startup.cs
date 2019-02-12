using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerApi.Entities;
using ServerApi.Entities.Repositories.Implementations;
using ServerApi.Entities.Repositories.Interfaces;
using ServerApi.Services.GitHub.Implementations;
using ServerApi.Services.GitHub.Interfaces;

namespace ServerApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) 
            => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddCors(options =>
                options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("http://me.aburke.io");
                })
            );

            services.AddDbContext<ServerApiDbContext>(
                options => options.UseMySQL(
                    _configuration.GetConnectionString("CoffeeLakeConnection"))
            );
            
            // service types
            services.AddHostedService<GitHubHostedService>();
            services.AddScoped<IGitHubScopedProcessingService, GitHubScopedProcessingService>();
            services.AddScoped<IGitHubApiService, GitHubApiService>();
            
            // repository types
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IGitHubRepository, GitHubRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
                app.UseDeveloperExceptionPage();

            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
        }
    }
}
