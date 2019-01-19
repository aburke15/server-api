using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServerApi.AppData.Dtos;
using ServerApi.Entities.Interfaces;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ReposController : ControllerBase
    {
        private const string RepoKey = "GithubRepos";

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
        public async Task<IActionResult> GetProjects()
        {
            if (_cache.TryGetValue(RepoKey, out IEnumerable<GitHubDto> projects))
                return Ok(projects);
            
            var repos = (await _gitHubRepository.GetAsync())
                .Select(x => new GitHubDto
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Forks = x.Forks,
                    HtmlUrl = x.HtmlUrl,
                    Language = x.Language,
                    Name = x.Name
                })
                .OrderBy(x => x.CreatedOn);

            _cache.Set(RepoKey, repos, TimeSpan.FromDays(5));

            return Ok(repos);
        }
    }
}