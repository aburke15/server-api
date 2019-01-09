using Microsoft.EntityFrameworkCore;
using ServerApi.AppData.Interfaces;
using ServerApi.AppData.Models;

namespace ServerApi.AppData.Implementations
{
    public class GitHubRepository : Repository<GitHub>, IGitHubRepository
    {
        private const string CreateTable = @"
            CREATE TABLE IF NOT EXISTS GitHub (
            ID int NOT NULL AUTO_INCREMENT,
            created_on timestamp NOT NULL,
            created_at varchar(100) NOT NULL,
            description varchar(500) NULL,
            forks int NULL,
            html_url varchar(200) NOT NULL,
            language varchar(25) NULL,
            name varchar(50) NOT NULL,
            PRIMARY KEY(ID));";
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