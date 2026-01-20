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

        static async Task Main()
        {
            await DropDatabase();
            await CreateDatabase();
        }
    }
}