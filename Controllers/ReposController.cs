using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServerApi.AppData.Implementations;
using ServerApi.AppData.Models;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ReposController : ControllerBase
    {
        private const string RepoKey = "Github Repos";

        private readonly IMemoryCache _cache;
        //private readonly IGithubRepoRepository GithubRepo;

        public ReposController(
            IMemoryCache cache)
            //IGithubRepoRepository githubRepo)
        {
            _cache = cache;
            //GithubRepo = githubRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            throw new NotImplementedException();
//            if (Cache.TryGetValue(RepoKey, out IEnumerable<GithubDataDto> projects))
//                return Ok(projects);
//            
//            var repos = (await GitHubRepository.GetAsync())
//                .Select(x => new GithubDataDto
//                {
//                    Id = x.Id,
//                    CreatedOn = x.CreatedOn,
//                    CreatedAt = x.CreatedAt,
//                    Description = x.Description,
//                    Forks = x.Forks,
//                    HtmlUrl = x.HtmlUrl,
//                    Language = x.Language,
//                    Name = x.Name
//                })
//                .OrderBy(x => x.CreatedOn);
//
//            Cache.Set(RepoKey, repos, TimeSpan.FromDays(5));
//
//            return Ok(repos);
        }
    }
}