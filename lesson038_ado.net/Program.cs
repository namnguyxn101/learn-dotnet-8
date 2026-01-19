using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

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

        using var command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "getproductinfo";
        command.CommandType = CommandType.StoredProcedure;

        var id = new SqlParameter("@id", 3);

        command.Parameters.Add(id);

        var dataReader = command.ExecuteReader();

        if (dataReader.HasRows)
        {
            dataReader.Read();

            var tenSanPham = dataReader["TenSanPham"];
            var tenDanhMuc = dataReader["TenDanhMuc"];

            Console.WriteLine($"{tenSanPham} - {tenDanhMuc}");
        }

        conn.Close();
    }
}