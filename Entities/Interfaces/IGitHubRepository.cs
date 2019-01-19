using ServerApi.Entities.Models;

namespace ServerApi.Entities.Interfaces
{
    public interface IGitHubRepository : IRepository<GitHub>
    {
        void DropGitHubTable();

        void CreateGitHubTable();
    }
}