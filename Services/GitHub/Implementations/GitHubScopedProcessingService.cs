using System.Linq;
using ServerApi.Entities.Interfaces;
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

            var repos = (_gitHubApiService.GetRepositories())
                .Select(x => new
                {
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Forks = x.Forks,
                    HtmlUrl = x.HtmlUrl,
                    Language = x.Language,
                    Name = x.Name
                })
                .OrderByDescending(x => x.CreatedAt);

            foreach (var repo in repos)
            {
                var gitHub = new Entities.Models.GitHub
                {
                    CreatedAt = repo.CreatedAt.ToLongDateString(),
                    Description = repo.Description,
                    Forks = repo.Forks,
                    HtmlUrl = repo.HtmlUrl,
                    Language = repo.Language,
                    Name = repo.Name
                };
                
                _gitHubRepository.Add(gitHub);
            }

            _gitHubRepository.SaveChanges();
        }
    }
}