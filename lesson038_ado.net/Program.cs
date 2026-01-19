using System.Data.Common;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        // string sqlConnection = "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=sa;Password=Password123;TrustServerCertificate=True";

        var sqlStringBuilder = new MySqlConnectionStringBuilder();
        sqlStringBuilder["Server"] = "localhost";
        sqlStringBuilder["Port"] = "3307";
        sqlStringBuilder["Database"] = "xtlab";
        sqlStringBuilder["UID"] = "root";
        sqlStringBuilder["PWD"] = "abc123";
        // sqlStringBuilder["TrustServerCertificate"] = true;

        string sqlConnection = sqlStringBuilder.ToString();

        using var conn = new MySqlConnection(sqlConnection);

        // Console.WriteLine(conn.State);

        conn.Open();

        using DbCommand command = new MySqlCommand();
        command.Connection = conn;
        command.CommandText = "SELECT * FROM Sanpham LIMIT 0, 10;";

        var dataReader = command.ExecuteReader();
        
        while (dataReader.Read())
        {
            Console.WriteLine($"{dataReader["TenSanpham"], 30} - Gia: {dataReader["Gia"]}");
        }

        conn.Close();
    }
}