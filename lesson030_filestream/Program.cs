using System.Text;

// string path = "data.dat";

// using var stream = new FileStream(path: path, FileMode.OpenOrCreate);

// // Lưu dữ liệu
// byte[] buffer = { 1, 2, 3 };
// int offset = 0;
// int count = 3;
// stream.Write(buffer, offset, count);

// // Đọc dữ liệu
// int sobytedocduoc = stream.Read(buffer, offset, count);
// // Nếu sobytedocduoc = 0 -> nó nằm ở cuối file

// // int, double --> byte[]
// int num1 = 2;
// var bytes_num1 = BitConverter.GetBytes(num1);
// // byte[] --> int, double, ...
// BitConverter.ToInt32(bytes_num1, 0); // Param 2 là chỉ mục bắt đầu của mảng byte

// // string -> byte[]
// string s = "Hello world";
// var bytes_s = Encoding.UTF8.GetBytes(s);

// Encoding.UTF8.GetString(bytes_s, 0, 10);
// // Param 2 là chỉ mục bắt đầu của mảng byte
// // Param 3 là số byte
// ==============================================

class Product
{
    public int ID { get; set; }
    public double Price { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Save(Stream stream)
    {
        // int --> 4 byte
        var bytes_id = BitConverter.GetBytes(ID);
        stream.Write(bytes_id, 0, 4);

        // double --> 8 byte
        var bytes_price = BitConverter.GetBytes(Price);
        stream.Write(bytes_price, 0, 8);

        // Chuỗi name
        var bytes_name = Encoding.UTF8.GetBytes(Name);
        var bytes_leng = BitConverter.GetBytes(bytes_name.Length);
        stream.Write(bytes_leng, 0, 4);
        stream.Write(bytes_name, 0, bytes_name.Length);
    }

    public void Restore(Stream stream)
    {
        // int --> 4 byte
        var bytes_id = new byte[4];
        stream.Read(bytes_id, 0, 4);
        ID = BitConverter.ToInt32(bytes_id, 0);

        // double --> 8 byte
        var bytes_price = new byte[8];
        stream.Read(bytes_price, 0, 8);
        Price = BitConverter.ToDouble(bytes_price, 0);

        // Chuỗi name
        var bytes_leng = new byte[4];
        stream.Read(bytes_leng, 0, 4);
        int leng = BitConverter.ToInt32(bytes_leng, 0);
        
        var bytes_name = new byte[leng];
        stream.Read(bytes_name, 0, leng);
        Name = Encoding.UTF8.GetString(bytes_name, 0, leng);
    }
}

class Program
{
    public static void Main()
    {
        string path = "data.dat";
        using var stream = new FileStream(path, FileMode.OpenOrCreate);

        // Write
        // Product product = new Product()
        // {
        //     ID = 10,
        //     Price = 789,
        //     Name = "iPhone XS Max",
        // };

        // product.Save(stream);
        // =====================================

        // Read
        Product product = new Product();

        product.Restore(stream);

        Console.WriteLine($"ID: {product.ID} - Name: {product.Name} - Price: {product.Price}");
    }
}