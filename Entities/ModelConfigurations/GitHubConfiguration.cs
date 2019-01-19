using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApi.Entities.Models;

namespace ServerApi.Entities.ModelConfigurations
{
    public class GitHubConfiguration : IEntityTypeConfiguration<GitHub>
    {
        public void Configure(EntityTypeBuilder<GitHub> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedOn)
                .HasColumnType("timestamp")
                .IsRequired();
            
            builder.Property(x => x.CreatedAt)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Forks)
                .ValueGeneratedNever();

            builder.Property(x => x.HtmlUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Language)
                .HasMaxLength(25);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}