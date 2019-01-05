using Microsoft.EntityFrameworkCore;

namespace ServerApi.AppData
{
    public class ServerApiContext : DbContext
    {
        protected ServerApiContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}