using System.Collections.Generic;
using System.Threading.Tasks;
using ServerApi.Entities.Models;

namespace ServerApi.Entities.Repositories.Interfaces
{
    public interface IGitHubRepository : IRepository<GitHub>
    {
        void DropGitHubTable();

        void CreateGitHubTable();

        void AddIndexOnCreatedAt();

        Task<IEnumerable<GitHub>> GetByCreatedAtDescendingAsync();
    }
}