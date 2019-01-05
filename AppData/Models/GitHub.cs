namespace ServerApi.AppData.Models
{
    public class GithubRepo : Entity
    {
        public string CreatedAt { get; set; }

        public string Description { get; set; }

        public int Forks { get; set; }

        public string HtmlUrl { get; set; }

        public string Language { get; set; }

        public string Name { get; set; }
    }
}