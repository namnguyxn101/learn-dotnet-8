using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

class Program
{
    static void ShowDataTable(DataTable table)
    {
        Console.WriteLine($"Ten bang: {table.TableName}");

        foreach (DataColumn col in table.Columns)
        {
            Console.Write($"{col.ColumnName, -20}");
        }
        
        Console.WriteLine();

        int numberCols = table.Columns.Count;

        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < numberCols; i++)
            {
                Console.Write($"{row[i], -20}");
            }
            
            // Console.Write($"{row[0], -20}");
            // Console.Write($"{row["HoTen"], -20}");
            // Console.Write($"{row["Tuoi"], -20}");
            Console.WriteLine();
        }
    }
    
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

        var dataSet = new DataSet();
        var table = new DataTable("MyTable");

        // Thêm bảng vào data set
        dataSet.Tables.Add(table);

        table.Columns.Add("STT");
        table.Columns.Add("HoTen");
        table.Columns.Add("Tuoi");

        table.Rows.Add(1, "Nguyen Phuong Nam", 22);
        table.Rows.Add(2, "Hoang Van Son", 25);
        table.Rows.Add(3, "Ha Thi Tuong Vy", 21);

        ShowDataTable(table);

        conn.Close();
    }
}