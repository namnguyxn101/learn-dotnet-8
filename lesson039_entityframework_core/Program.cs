using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ef
{
    class Program
    {
        static async Task CreateDatabase()
        {
            using var dbContext = new ShopContext();
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
            using var dbContext = new ShopContext();
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

        static async Task InsertData()
        {
            using var dbContext = new ShopContext();

            // Category c1 = new Category() { Name = "Dien thoai", Description = "Cac loai dien thoai"};
            // Category c2 = new Category() { Name = "Do uong", Description = "Cac loai do uong"};
            // await dbContext.AddAsync(c1);
            // await dbContext.AddAsync(c2);
            // -------------------------------------

            var c1 = await (from c in dbContext.Categories where c.CategoryId == 1 select c).FirstOrDefaultAsync();
            var c2 = await (from c in dbContext.Categories where c.CategoryId == 2 select c).FirstOrDefaultAsync();

            dbContext.Add(new Product() { Name = "iPhone XS Max", Price = 1000, CateID = 1 });
            dbContext.Add(new Product() { Name = "Samsung Galaxy S24 Ultra", Price = 900, Category = c1 });
            dbContext.Add(new Product() { Name = "Ruou vang Abc", Price = 500, Category = c2 });
            dbContext.Add(new Product() { Name = "Nokia Xyz", Price = 600, Category = c1 });
            dbContext.Add(new Product() { Name = "Cafe Abc", Price = 100, Category = c2 });

            await dbContext.SaveChangesAsync();
        }

        static async Task Main()
        {
            await DropDatabase();
            await CreateDatabase();
            // await InsertData();
        }
    }
}