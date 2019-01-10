using System;
using Newtonsoft.Json;

namespace ServerApi.AppData.Dtos
{
    public class GitHubRepoDto
    {
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "forks")]
        public int Forks { get; set; }

        [JsonProperty(PropertyName = "html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string ProgrammingLanguage { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string RepoName { get; set; }
    }
}