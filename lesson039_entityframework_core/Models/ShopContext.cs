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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            // Cách 1
            // var entity = modelBuilder.Entity(typeof(Product));

            // Cách 2
            // var entity = modelBuilder.Entity<Product>();

            // Cách 3
            // modelBuilder.Entity<Product>(entity =>
            // {
                
            // });
            // -------------------------------------

            modelBuilder.Entity<Product>(entity =>
            {
                // Table mapping
                entity.ToTable("Products");

                // PK
                entity.HasKey(p => p.ProductId);

                // Index
                entity.HasIndex(p => p.Price).HasDatabaseName("index-products-price");

                // Relative (One to Many)
                // entity.HasOne(p => p.Category)
                //       .WithMany()
                //       .HasForeignKey("CateID")
                //       .OnDelete(DeleteBehavior.Cascade)
                //       .HasConstraintName("FK_Products_Categories");


                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products) // Collect navigation
                      .HasForeignKey("CateID")
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_Products_Categories");
            });

            // One-to-One
            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasOne(cd => cd.Category)
                      .WithOne(c => c.CategoryDetail)
                      .HasForeignKey<CategoryDetail>(cd => cd.CategoryDetailID)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryDetail> CategoryDetail { get; set; }
    }
}