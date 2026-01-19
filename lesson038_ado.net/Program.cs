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
            Console.Write($"{col.ColumnName,-20}");
        }

        Console.WriteLine();

        int numberCols = table.Columns.Count;
        int index = 0;

        foreach (DataRow row in table.Rows)
        {
            Console.Write($"{index, -20}");
            for (int i = 0; i < numberCols; i++)
            {
                Console.Write($"{row[i],-20}");
            }

            // Console.Write($"{row[0], -20}");
            // Console.Write($"{row["HoTen"], -20}");
            // Console.Write($"{row["Tuoi"], -20}");
            Console.WriteLine();

            index++;
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

        var adapter = new SqlDataAdapter();
        adapter.TableMappings.Add("Table", "NhanVien");

        // SelectCommand
        adapter.SelectCommand = new SqlCommand("SELECT NhanviennID, Ho, Ten FROM Nhanvien", conn);
        // InsertCommand
        adapter.InsertCommand = new SqlCommand("INSERT INTO Nhanvien (Ho, Ten) VALUES (@Ho, @Ten)", conn);
        adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
        adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
        // UpdateCommand
        adapter.UpdateCommand = new SqlCommand("UPDATE Nhanvien SET Ho = @Ho, Ten = @Ten WHERE NhanviennID = @NhanviennID", conn);
        var idParamUpdate = adapter.UpdateCommand.Parameters.Add("@NhanviennID", SqlDbType.Int);
        idParamUpdate.SourceColumn = "NhanviennID";
        idParamUpdate.SourceVersion = DataRowVersion.Original;
        adapter.UpdateCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
        adapter.UpdateCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
        
        // DeleteCommand
        adapter.DeleteCommand = new SqlCommand("DELETE FROM Nhanvien WHERE NhanviennID = @NhanviennID", conn);
        var idParamDelete = adapter.DeleteCommand.Parameters.Add("@NhanviennID", SqlDbType.Int);
        idParamDelete.SourceColumn = "NhanviennID";
        idParamDelete.SourceVersion = DataRowVersion.Original;


        var dataSet = new DataSet();
        adapter.Fill(dataSet);

        DataTable? table = dataSet.Tables["NhanVien"];

        if (table != null) ShowDataTable(table);

        // Insert
        // var row = table?.Rows.Add();
        // if (row != null)
        // {
        //     row["Ho"] = "Tran Kim";
        //     row["Ten"] = "Cuong";
        // }
        // ------------------------------
        
        // Update
        // var row10 = table?.Rows[10];
        // if (row10 != null)
        // {
        //     row10["Ho"] = "Le Tinh";
        //     row10["Ten"] = "Anh";
        // }
        // ------------------------------

        // Delete
        var row10 = table?.Rows[10];
        if (row10 != null) row10.Delete();



        // DataAdapter cập nhật DataSet vào DB
        adapter.Update(dataSet);

        conn.Close();
    }
}