using ServerApi.AppData.Models;

namespace ServerApi.AppData.Implementations
{
    public class GitHubRepository : Repository<GitHub>
    {
        public GitHubRepository(ServerApiContext context)
            : base(context)
        { }
    }
}