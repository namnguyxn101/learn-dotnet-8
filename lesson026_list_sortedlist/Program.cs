// List<int> ds1 = new List<int>() { 1, 2, 3 };
// ds1.Add(4);
// ds1.Add(5);
// ds1.AddRange(new int[] { 6, 7, 8 });

// Chèn pt vào vị trí chỉ định
// ds1.Insert(0, 9);

// Chèn một loạt pt vào vị trí chỉ định
// ds1.InsertRange(1, new int[] { 11, 9, 4 });

// Xóa pt tại vị trí chỉ định
// ds1.RemoveAt(2);

// Xóa pt đầu tiên có giá trị chỉ định
// ds1.Add(5);
// ds1.Add(5);
// ds1.Remove(5);

// Xóa các pt thỏa mãn delegate
// ds1.RemoveAll(x => x % 2 != 0);

// Xóa toàn bộ các pt
// ds1.Clear();

// for (int i = 0; i < ds1.Count; i++)
// {
//     Console.WriteLine($"Vi tri {i}: {ds1[i]}");
// }
//===================================

// List<int> ds1 = new List<int>() { 3, 1, 10, 28, 5, 9, 52 };

// Trả về pt đầu tiên thỏa mãn delegate
// var n = ds1.Find(x => x > 5);
// Console.WriteLine(n);

// Trả về danh sách các phần tử thỏa delegate
// var ds2 = ds1.FindAll(x => x % 3 == 0);
// foreach (var n in ds2)
// {
//     Console.Write($"{n} ");
// }
//===================================

class Product
{
    public int ID { set; get; }
    public string Name { set; get; } = string.Empty;
    public double Price { set; get; }
    public string Origin { set; get; } = string.Empty;
}

class Program
{
    static void Main()
    {
        // List<Product> products = new List<Product>()
        // {
        //     new Product() { ID = 1, Name = "iPhone X", Price = 800, Origin = "The US" },
        //     new Product() { ID = 2, Name = "Samsung", Price = 1000, Origin = "Korea" },
        //     new Product() { ID = 3, Name = "Sony", Price = 600, Origin = "Japan" },
        //     new Product() { ID = 4, Name = "Xiaomi", Price = 900, Origin = "China" },
        // };

        // // var p = products.Find(p => p.Origin == "Japan");
        // // if (p != null)
        // // {
        // //     Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
        // // }

        // // var PList = products.FindAll(p => p.Price <= 900);
        // // foreach (var p in PList)
        // // {
        // //     Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
        // // }

        // products.Sort(
        //     // Tăng dần
        //     (p1, p2) => {
        //         if (p1.Price == p2.Price) return 0;
        //         if (p1.Price < p2.Price) return -1;
        //         return 1;
        //     }
        // );
        // // Hoặc
        // // products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
        //===========================================

        SortedList<string, Product> products = new SortedList<string, Product>();
        products["sanpham1"] = new Product() { ID = 1, Name = "iPhone X", Price = 800, Origin = "The US" };
        products["sanpham2"] = new Product() { ID = 2, Name = "Samsung", Price = 1000, Origin = "Korea" };
        products.Add("sanpham3", new Product() { ID = 3, Name = "Sony", Price = 600, Origin = "Japan" });

        // var p = products["sanpham1"];

        // var keys = products.Keys;
        // var values = products.Values;

        // foreach (var k in keys)
        // {
        //     Console.WriteLine(k);
        // }
        // Console.WriteLine("---------------------");
        // foreach (var v in values)
        // {
        //     Console.WriteLine(v.Name);
        // }

        foreach (KeyValuePair<string, Product> item in products)
        {
            var key = item.Key;
            var val = item.Value;

            Console.WriteLine($"{key} - {val.Name}");
        }
    }
}