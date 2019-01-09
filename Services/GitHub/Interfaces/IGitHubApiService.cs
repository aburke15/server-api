using System.Collections.Generic;
using ServerApi.AppData.Dtos;

namespace ServerApi.Services.GitHub.Interfaces
{
    public interface IGitHubApiService
    {
        IEnumerable<GitHubRepoDto> GetRepositories();
    }
}