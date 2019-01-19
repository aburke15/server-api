using Microsoft.EntityFrameworkCore;
using ServerApi.Entities.ModelConfigurations;
using ServerApi.Entities.Models;

namespace ServerApi.Entities
{
    public class ServerApiDbContext : DbContext
    {
        public ServerApiDbContext()
        { }
        
        public ServerApiDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GitHubConfiguration());
        }
        
        public virtual DbSet<GitHub> GitHub { get; set; }
    }
}