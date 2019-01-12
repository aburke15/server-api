using Microsoft.EntityFrameworkCore;
using ServerApi.AppData.Interfaces;
using ServerApi.AppData.Models;
using ServerApi.Entities;

namespace ServerApi.AppData.Implementations
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
        
        private readonly ServerApiContext _context;

        public GitHubRepository(ServerApiContext context) 
            : base(context) => _context = context;

        public void DropGitHubTable()
            => _context.Database.ExecuteSqlCommand(DropTable);

        public void CreateGitHubTable()
            => _context.Database.ExecuteSqlCommand(CreateTable);
    }
}