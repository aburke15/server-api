using System.Collections.Generic;
using ServerApi.Entities.Dtos;

namespace ServerApi.Services.GitHub.Interfaces
{
    public interface IGitHubApiService
    {
        IEnumerable<GitHubRepoDto> GetGitHubRepositories();
    }
}