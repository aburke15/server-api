using ServerApi.AppData.Models;

namespace ServerApi.AppData.Interfaces
{
    public interface IGitHubRepository : IRepository<GitHub>
    {
        void DropGitHubTable();

        void CreateGitHubTable();
    }
}