using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef
{
    public class ShopContext : DbContext
    {
        public static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            // builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });

        private const string connectionString = @"
            Data Source = localhost,1433;
            Initial Catalog = shopdata;
            User ID = sa;
            Password = Password123;
            TrustServerCertificate = true;
        ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}