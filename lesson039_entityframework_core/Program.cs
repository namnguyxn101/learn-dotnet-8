using Microsoft.EntityFrameworkCore;

namespace ef
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbContext = new ProductDbContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var result = dbContext.Database.EnsureCreated();

            if (result)
            {
                Console.WriteLine($"Tao db {dbName} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong tao duoc db {dbName}");
            }
        }

        static void DropDatabase()
        {
            using var dbContext = new ProductDbContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var result = dbContext.Database.EnsureDeleted();

            if (result)
            {
                Console.WriteLine($"Xoa db {dbName} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong xoa duoc db {dbName}");
            }
        }
        
        static void Main()
        {
            // Entity --> Database, Table
            // Database - SQL Server
            // Class biểu diễn CSDL -> kế thừa từ DbContext

            // CreateDatabase();
            DropDatabase();
        }
    }
}