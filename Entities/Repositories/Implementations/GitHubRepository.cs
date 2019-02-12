using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApi.Entities.Models;
using ServerApi.Entities.Repositories.Interfaces;

namespace ServerApi.Entities.Repositories.Implementations
{
    public class GitHubRepository : Repository<GitHub>, IGitHubRepository
    {
        private const string CreateTable = @"
            CREATE TABLE IF NOT EXISTS GitHub (
            Id int NOT NULL AUTO_INCREMENT,
            CreatedOn timestamp NOT NULL,
            CreatedAt timestamp NULL,
            Description varchar(500) NULL,
            Forks int NULL,
            HtmlUrl varchar(200) NULL,
            Language varchar(25) NULL,
            Name varchar(50) NULL,
            PRIMARY KEY(Id));";
        private const string DropTable = "DROP TABLE IF EXISTS GitHub;";
        private const string AddIndexToCreatedAt = "CREATE INDEX CreatedAt_IX ON GitHub(CreatedAt);";
        
        private readonly ServerApiDbContext _context;

        public GitHubRepository(ServerApiDbContext context) 
            : base(context) => _context = context;

        public void DropGitHubTable()
            => _context.Database.ExecuteSqlCommand(DropTable);

        public void CreateGitHubTable()
            => _context.Database.ExecuteSqlCommand(CreateTable);

        public void AddIndexOnCreatedAt()
            => _context.Database.ExecuteSqlCommand(AddIndexToCreatedAt);

        public async Task<IEnumerable<GitHub>> GetByCreatedAtDescendingAsync()
            => await _context.GitHub.OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        
    }
}