namespace ServerApi.AppData.Models
{
    public class GitHub : Entity
    {
        public string CreatedAt { get; set; }

        public string Description { get; set; }

        public int Forks { get; set; }

        public string HtmlUrl { get; set; }

        public string ProgrammingLanguage { get; set; }

        public string RepoName { get; set; }
    }
}