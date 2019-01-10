using System.Linq;
using ServerApi.AppData.Interfaces;
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
                    x.CreatedAt,
                    x.Description,
                    x.Forks,
                    x.HtmlUrl,
                    x.ProgrammingLanguage,
                    x.RepoName
                })
                .OrderByDescending(x => x.CreatedAt);

            foreach (var repo in repos)
            {
                var gitHub = new AppData.Models.GitHub
                {
                    CreatedAt = repo.CreatedAt.ToLongDateString(),
                    Description = repo.Description,
                    Forks = repo.Forks,
                    HtmlUrl = repo.HtmlUrl,
                    ProgrammingLanguage = repo.ProgrammingLanguage,
                    RepoName = repo.RepoName
                };
                
                _gitHubRepository.Add(gitHub);
            }

            _gitHubRepository.SaveChanges();
        }
    }
}