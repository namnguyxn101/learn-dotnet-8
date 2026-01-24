using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MigrationDemo
{
    public class WebContext : DbContext
    {
        private const string connectionString = @"
            Data Source = localhost,1433;
            Initial Catalog = webdb;
            User ID = sa;
            Password = Password123;
            TrustServerCertificate = true;
        ";

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                   .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information)
                   .AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasIndex(at => new { at.ArticleID, at.TagID })
                      .IsUnique();
            });
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ArticleTag> ArticleTags { get; set; }
    }
}