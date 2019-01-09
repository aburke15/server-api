using System;

namespace ServerApi.AppData.Dtos
{
    public class GitHubDto
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedAt { get; set; }

        public string Description { get; set; }

        public int Forks { get; set; }

        public string HtmlUrl { get; set; }

        public string Language { get; set; }

        public string Name { get; set; }
    }
}