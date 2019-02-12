using System.Linq;
using ServerApi.Entities.Repositories.Interfaces;
using ServerApi.Services.GitHub.Interfaces;

namespace ServerApi.Services.GitHub.Implementations
{
    public class GitHubScopedProcessingService : IGitHubScopedProcessingService
    {
        private readonly IGitHubApiService _gitHubApiService;
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubScopedProcessingService(
            IGitHubApiService gitHubApiService,
            IGitHubRepository gitHubRepository)
        {
            _gitHubApiService = gitHubApiService;
            _gitHubRepository = gitHubRepository;
        }

        public void Process()
        {
            _gitHubRepository.DropGitHubTable();
            _gitHubRepository.CreateGitHubTable();
            _gitHubRepository.AddIndexOnCreatedAt();

            var repos = (_gitHubApiService.GetGitHubRepositories())
                .Select(x => new Entities.Models.GitHub
                {
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Forks = x.Forks,
                    HtmlUrl = x.HtmlUrl,
                    Language = x.Language,
                    Name = x.Name
                });
            
            _gitHubRepository.AddRange(repos);
        }
    }
}