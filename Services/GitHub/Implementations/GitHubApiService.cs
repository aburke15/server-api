using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RestSharp;
using ServerApi.AppData.Dtos;
using ServerApi.Services.GitHub.Interfaces;

namespace ServerApi.Services.GitHub.Implementations
{
    public class GitHubApiService : IGitHubApiService
    {
        private const string GitHubApiRepo = "GitHubApiUrl";
        private readonly IConfiguration _configuration;

        public GitHubApiService(IConfiguration configuration) 
            => _configuration = configuration;

        public IEnumerable<GitHubRepoDto> GetRepositories()
        {
            var client = new RestClient(new Uri(
                _configuration.GetValue<string>(GitHubApiRepo)
            ));

            var response = client.Get<List<GitHubRepoDto>>(new RestRequest());

            return response.Data;
        }   
    }
}