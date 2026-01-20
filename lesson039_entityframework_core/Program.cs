using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ef
{
    class Program
    {
        static async Task CreateDatabase()
        {
            using var dbContext = new ProductDbContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var result = await dbContext.Database.EnsureCreatedAsync();

            if (result)
            {
                Console.WriteLine($"Tao db {dbName} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong tao duoc db {dbName}");
            }
        }

        static async Task DropDatabase()
        {
            using var dbContext = new ProductDbContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var result = await dbContext.Database.EnsureDeletedAsync();

            if (result)
            {
                Console.WriteLine($"Xoa db {dbName} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong xoa duoc db {dbName}");
            }
        }

        static async Task InsertProduct()
        {
            using var dbContext = new ProductDbContext();

            var p1 = new Product()
            {
                ProductName = "San pham 1",
                ProviderName = "Cong ty 1"
            };

            await dbContext.AddAsync(p1);

            var p2 = new Product()
            {
                ProductName = "San pham 2",
                ProviderName = "Cong ty 2"
            };

            await dbContext.AddAsync(p2);

            var products = new List<Product>
            {
                new Product { ProductName = "San pham 3", ProviderName = "CTY A" },
                new Product { ProductName = "San pham 4", ProviderName = "CTY B" },
                new Product { ProductName = "San pham 5", ProviderName = "CTY C" },
            };

            dbContext.AddRange(products);

            int numRowsAffected = await dbContext.SaveChangesAsync();

            Console.WriteLine($"Da chen {numRowsAffected} du lieu");
        }

        static async Task ReadProducts()
        {
            using var dbContext = new ProductDbContext();

            var products = await dbContext.Products.ToListAsync();
            products.ForEach(p => p.PrintInfo());
            // ---------------------------------

            // var query = from p in dbContext.Products
            //             where (p.ProviderName ?? "").Contains("CTY")
            //             orderby p.ProductId descending
            //             select p;

            // var products = await query.ToListAsync();

            // foreach (var product in products)
            // {
            //     product.PrintInfo();
            // }
            // -------------------------------

            // Product? product = await (from p in dbContext.Products
            //                           where p.ProductId == 4
            //                           select p).FirstOrDefaultAsync();

            // if (product != null)
            // {
            //     product.PrintInfo();
            // }
        }

        static async Task RenameProduct(int id, string name)
        {
            using var dbContext = new ProductDbContext();

            Product? product = await (from p in dbContext.Products
                                      where p.ProductId == id
                                      select p).FirstOrDefaultAsync();

            if (product != null)
            {
                EntityEntry<Product> entry = dbContext.Entry(product);
                entry.State = EntityState.Detached;

                product.ProductName = name;

                int numRowsAffected = await dbContext.SaveChangesAsync();

                Console.WriteLine($"Da cap nhat {numRowsAffected} dong du lieu");
            }
        }

        static async Task DeleteProduct(int id)
        {
            using var dbContext = new ProductDbContext();

            Product? product = await (from p in dbContext.Products
                                      where p.ProductId == id
                                      select p).FirstOrDefaultAsync();

            if (product != null)
            {
                dbContext.Remove(product);

                int numRowsAffected = await dbContext.SaveChangesAsync();

                Console.WriteLine($"Da xoa {numRowsAffected} dong du lieu");
            }
        }

        static async Task Main()
        {
            // Entity --> Database, Table
            // Database - SQL Server
            // Class biểu diễn CSDL -> kế thừa từ DbContext

            // await CreateDatabase();
            // await DropDatabase();

            // await InsertProduct();
            // await RenameProduct(1, "iPhone");
            await DeleteProduct(5);
            await ReadProducts();
        }
    }
}