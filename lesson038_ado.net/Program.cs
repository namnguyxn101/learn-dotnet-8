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
        command.CommandText = "SELECT * FROM Danhmuc WHERE DanhmucID >= @DanhmucID;";

        // var danhMucId = new SqlParameter("@DanhmucID", 5);
        // command.Parameters.Add(danhMucId);
        // // Gán lại giá trị khác
        // danhMucId.Value = 3;
        // ---> Gọn hơn
        var danhMucId = command.Parameters.AddWithValue("@DanhmucID", 5);
        danhMucId.Value = 3;

        // =-=-=-=- ExecuteReader : Dùng khi cần kết quả trả về nhiều dòng -=-=-=-=
        // using var dataReader = command.ExecuteReader();

        // if (dataReader.HasRows)
        // {
        //     while (dataReader.Read())
        //     {
        //         // Nếu biết type của field và thứ tự thì dùng (Theo thứ tự):
        //         var id = dataReader.GetInt32(0);

        //         // Nếu biết tên của field thì dùng:
        //         var tenDanhMuc = dataReader["TenDanhMuc"];

        //         // Nếu chỉ biết thứ tự thì có thể dùng:
        //         var moTa = dataReader[2];

        //         Console.WriteLine($"{id} - {tenDanhMuc} - {moTa}");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("No data");
        // }

        // =-=-=-=- ExecuteScalar : Trả về 1 giá trị (row 1, column 1) -=-=-=-=
        // var returnValue = command.ExecuteScalar();
        // Console.WriteLine(returnValue);

        // =-=-=-=- ExecuteNonQuery : Trả về số dòng bị ảnh hưởng (Insert, Update, Delete) -=-=-=-=
        command.CommandText = "INSERT INTO Shippers (Hoten, Sodienthoai) VALUES (@Hoten, @Sodienthoai)";
        command.Parameters.AddWithValue("@Hoten", "Abc");
        command.Parameters.AddWithValue("@Sodienthoai", 123456);
        
        var kq = command.ExecuteNonQuery();
        Console.WriteLine($"So dong bi anh huong: {kq}");

        conn.Close();
    }
}