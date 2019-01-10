using Microsoft.EntityFrameworkCore;
using ServerApi.AppData.ModelConfigurations;
using ServerApi.AppData.Models;

namespace ServerApi.AppData
{
    public class ServerApiContext : DbContext
    {
        public ServerApiContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GitHubConfiguration());
        }
        
        public virtual DbSet<GitHub> GitHub { get; set; }
    }
}