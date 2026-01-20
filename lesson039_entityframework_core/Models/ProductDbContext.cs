using Microsoft.EntityFrameworkCore;

namespace ef
{
    public class ProductDbContext : DbContext
    {
        private const string connectionString = @"
            Data Source = localhost,1433;
            Initial Catalog = data01;
            User ID = sa;
            Password = Password123;
            TrustServerCertificate = true;
        ";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}