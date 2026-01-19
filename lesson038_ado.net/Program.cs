using System.Data.Common;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        // string sqlConnection = "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=sa;Password=Password123;TrustServerCertificate=True";

        var sqlStringBuilder = new SqlConnectionStringBuilder();
        sqlStringBuilder["Server"] = "localhost,1433";
        sqlStringBuilder["Database"] = "xtlab";
        sqlStringBuilder["UID"] = "sa";
        sqlStringBuilder["PWD"] = "Password123";
        sqlStringBuilder["TrustServerCertificate"] = true;

        string sqlConnection = sqlStringBuilder.ToString();

        using var conn = new SqlConnection(sqlConnection);

        // Console.WriteLine(conn.State);

        conn.Open();

        using DbCommand command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "SELECT TOP (5) * FROM Sanpham;";

        var dataReader = command.ExecuteReader();
        
        while (dataReader.Read())
        {
            Console.WriteLine($"{dataReader["TenSanpham"], 30} - Gia: {dataReader["Gia"]}");
        }

        conn.Close();
    }
}