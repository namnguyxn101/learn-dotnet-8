namespace scaffold
{
    class Program
    {
        static void Main()
        {
            // dotnet ef dbcontext scaffold -o Models -d "connectionString" "Microsoft.EntityFrameworkCore.SqlServer"
            // dotnet ef dbcontext scaffold -o Models -d "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=sa;Password=Password123;TrustServerCertificate=true" "Microsoft.EntityFrameworkCore.SqlServer"
            
        }
    }
}