using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServerApi.Entities.Dtos;
using ServerApi.Entities.Repositories.Interfaces;

namespace ServerApi.Controllers
{
    [Produces("application/json")]
    public class ReposController : BaseApiController
    {
        private const string RepoKey = "GitHubRepos";

        private readonly IMemoryCache _cache;
        private readonly IGitHubRepository _gitHubRepository;

        public ReposController(
            IMemoryCache cache,
            IGitHubRepository gitHubRepository)
        {
            _cache = cache;
            _gitHubRepository = gitHubRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGitHubProjects()
        {
            if (_cache.TryGetValue(RepoKey, out IEnumerable<GitHubDto> projects))
                return Ok(projects);

            var repos = (await _gitHubRepository.GetByCreatedAtDescendingAsync())
                .Select(x => new GitHubDto
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    CreatedAt = x.CreatedAt.ToLongDateString(),
                    Description = x.Description,
                    Forks = x.Forks,
                    HtmlUrl = x.HtmlUrl,
                    Language = x.Language,
                    Name = x.Name
                });

            _cache.Set(RepoKey, repos, TimeSpan.FromDays(5));

            return Ok(repos);
        }
    }
}