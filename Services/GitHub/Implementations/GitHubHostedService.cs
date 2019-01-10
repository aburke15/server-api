using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerApi.Services.GitHub.Interfaces;

namespace ServerApi.Services.GitHub.Implementations
{
    public class GitHubHostedService : IHostedService, IDisposable
    {
        private Timer _timer;

        public GitHubHostedService(IServiceProvider services) 
            => Services = services;

        private IServiceProvider Services { get; }

        public void Dispose() 
            => _timer?.Dispose();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var service = scope.ServiceProvider
                    .GetRequiredService<IGitHubScopedProcessingService>();

                service.Process();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) 
            => Task.CompletedTask;
    }
}