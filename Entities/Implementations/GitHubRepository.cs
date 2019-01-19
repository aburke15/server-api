using Microsoft.EntityFrameworkCore;
using ServerApi.Entities.Interfaces;
using ServerApi.Entities.Models;

namespace ServerApi.Entities.Implementations
{
    public class GitHubRepository : Repository<GitHub>, IGitHubRepository
    {
        private const string CreateTable = @"
            CREATE TABLE IF NOT EXISTS GitHub (
            Id int NOT NULL AUTO_INCREMENT,
            CreatedOn timestamp NOT NULL,
            CreatedAt varchar(100) NULL,
            Description varchar(500) NULL,
            Forks int NULL,
            HtmlUrl varchar(200) NULL,
            Language varchar(25) NULL,
            Name varchar(50) NULL,
            PRIMARY KEY(Id));";
        private const string DropTable = "DROP TABLE IF EXISTS GitHub;";
        
        private readonly ServerApiDbContext _context;

        public GitHubRepository(ServerApiDbContext context) 
            : base(context) => _context = context;

        public void DropGitHubTable()
            => _context.Database.ExecuteSqlCommand(DropTable);

        public void CreateGitHubTable()
            => _context.Database.ExecuteSqlCommand(CreateTable);
    }
}