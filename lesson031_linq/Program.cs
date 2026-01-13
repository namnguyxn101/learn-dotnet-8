// LINQ - Language Integrated Query: Ngôn ngữ truy vấn tích hợp
// Truy vấn của LINQ khá giống với SQL
// Nguồn dữ liệu: IEnumerable, IEnumerable<T> (Array, List, Stack, Queue, ...)
// Ứng dụng thực tế các nguồn dữ liệu có thể là file: XML, SQL
// Những nguồn dữ liệu bên ngoài này sẽ được nạp vào chương trình và được thể hiện thông qua các lớp như Array, List, Stack, ....

using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;

public class Product
{
    public int ID { set; get; }
    public string Name { set; get; }         // tên
    public double Price { set; get; }        // giá
    public string[] Colors { set; get; }     // các màu sắc
    public int Brand { set; get; }           // ID Nhãn hiệu, hãng
    public Product(int id, string name, double price, string[] colors, int brand)
    {
        ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
    }
    // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
    public override string ToString()
       => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

}

public class Brand
{
    public string Name { set; get; } = string.Empty;
    public int ID { set; get; }
}

class Program
{
    public static void Main()
    {
        var brands = new List<Brand>()
        {
            new Brand{ID = 1, Name = "Công ty AAA"},
            new Brand{ID = 2, Name = "Công ty BBB"},
            new Brand{ID = 4, Name = "Công ty CCC"},
        };

        var products = new List<Product>()
        {
            new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
            new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
            new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
            new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
            new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
            new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
            new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
        };

        // Lấy ra những sp có giá 400
        // var query = from p in products
        //             where p.Price == 400
        //             select p;
        // foreach (var product in query)
        // {
        //     Console.WriteLine(product); 
        // }
        // ==============================

        // Linq API - Select
        // var kq = products.Select(
        //     (p) =>
        //     {
        //         return new
        //         {
        //             Ten = p.Name,
        //             Gia = p.Price,
        //         };
        //     }
        // );

        // foreach (var item in kq)
        // {
        //     Console.WriteLine(item);
        // }
        // ==============================

        // Linq API - Where
        // var kq = products.Where(
        //     (p) =>
        //     {
        //         return p.Name.Contains("tr");
        //     }
        // );

        // foreach (var item in kq)
        // {
        //     Console.WriteLine(item);
        // }
        // ==============================

        // Linq API - SelectMany
        // var kq = products.SelectMany(
        //     (p) =>
        //     {
        //         return p.Colors;
        //     }
        // );

        // foreach (var item in kq)
        // {
        //     Console.WriteLine(item);
        // }
        // ==============================

        // Linq API - Max, Min, Sum, Average
        // int[] numbers = {1, 2, 4, 6, 4, 2, 8, 9};

        // Console.WriteLine("Max: " + numbers.Max());
        // Console.WriteLine("Min: " + numbers.Min());
        // Console.WriteLine("Sum: " + numbers.Sum());
        // Console.WriteLine("Average: " + numbers.Average());
        // // Tổng các số lẻ
        // Console.WriteLine("Sum of odd numbers: " + numbers.Where(n => n % 2 != 0).Sum());
        // // Giá thấp nhất
        // Console.WriteLine("The lowest price in products list: " + products.Min(p => p.Price));
        // ==============================

        // Linq API - Join
        // var kq = products.Join(brands, p => p.Brand, b => b.ID, (product, brand) =>
        // {
        //     return new
        //     {
        //         Ten = product.Name,
        //         ThuongHieu = brand.Name,
        //     };  
        // });

        // foreach (var item in kq)
        // {
        //     Console.WriteLine(item);
        // }
        // ==============================

        // Linq API - GroupJoin
        // var kq = brands.GroupJoin(products, b => b.ID, p => p.Brand,
        //     (brand, products) =>
        //     {
        //         return new
        //         {
        //             ThuongHieu = brand.Name,
        //             CacSanPham = products,
        //         };
        //     }
        // );

        // foreach (var gr in kq)
        // {
        //     Console.WriteLine(gr.ThuongHieu);

        //     foreach (var p in gr.CacSanPham)
        //     {
        //         Console.WriteLine(p);
        //     }
        // }
        // ==============================

        // Linq API - Take
        // Lấy 3 sản phẩm đầu tiên
        // products.Take(3).ToList().ForEach(p => Console.WriteLine(p));
        // ==============================

        // Linq API - Skip
        // Bỏ qua 2 sản phẩm đầu tiên
        // products.Skip(2).ToList().ForEach(p => Console.WriteLine(p));

        // ==============================
        // Linq API - OrderBy (tăng dần) / OrderByDescending (giảm dần)
        // products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));
        // ==============================

        // Linq API - Reverse
        // int[] numbers = {1, 2, 4, 6, 4, 2, 8, 9};
        // numbers.Reverse().ToList().ForEach(n => Console.WriteLine(n));
        // ==============================

        // Linq API - GroupBy
        // var kq = products.GroupBy(p => p.Brand);

        // foreach (var group in kq)
        // {
        //     Console.WriteLine(group.Key);
        //     foreach (var p in group)
        //     {
        //         Console.WriteLine(p);
        //     }
        // }
        // ==============================

        // Linq API - Distinct
        // products.SelectMany(p => p.Colors).Distinct().ToList()
        //         .ForEach(p => Console.WriteLine(p));
        // ==============================

        // Linq API - Single / SingleOrDefault
        // Single trả về phần tử thỏa mãn điều kiện. Nếu có nhiều hơn 1 phần tử hoặc không có phần tử nào thì ném exception.
        // SingleOrDefault giống Single nhưng thay vì ném exception thì sẽ trả về null.
        // var p = products.Single(p => p.Price == 600);
        // Console.WriteLine(p);

        // var p = products.SingleOrDefault(p => p.Price == 1000);
        // if (p != null) Console.WriteLine(p);
        // ==============================

        // Linq API - Any
        // Kiểm tra có ít nhất 1 sản phẩm có giá 700 không
        // Console.WriteLine(products.Any(p => p.Price == 700));
        // ==============================

        // Linq API - All
        // Kiểm tra mọi sản phẩm có giá từ 200 trở lên không
        // Console.WriteLine(products.All(p => p.Price >= 200));
        // ==============================

        // Linq API - Count
        // Số sản phẩm trong danh sách
        // Console.WriteLine(products.Count());

        // Số sản phẩm có giá trên 300
        // Console.WriteLine(products.Count(p => p.Price > 300));
        // ==============================

        // Example Linq API
        // In ra tên sản phẩm, tên thương hiệu, có giá [300; 400], giá giảm dần.
        // products.Where(p => p.Price >= 300 && p.Price <= 400)
        //         .OrderByDescending(p => p.Price)
        //         .Join(brands, p => p.Brand, b => b.ID,
        //         (product, brand) =>
        //         {
        //             return new
        //             {
        //             SanPham = product.Name,
        //             Gia = product.Price,
        //             ThuongHieu = brand.Name,
        //             };
        //         })
        //         .ToList()
        //         .ForEach(info =>
        //         {
        //             Console.WriteLine($"{info.SanPham, 15} {info.ThuongHieu, 15} {info.Gia, 5}");
        //         });
        // ==============================

        // Linq Query Syntax
        // Lấy sản phẩm có giá <= 500 và màu xanh
        // var qr = from product in products
        //          from colors in product.Colors
        //          where product.Price <= 500 && colors == "Xanh"
        //          orderby product.Price descending
        //          select new
        //          {
        //            Ten = product.Name,
        //            Gia = product.Price,
        //            CacMau = product.Colors,  
        //          };

        // qr.ToList().ForEach(info =>
        // {
        //     Console.WriteLine($"{info.Ten, 15} {info.Gia, 5} {string.Join(',', info.CacMau)}");
        // });
        // ==============================

        // Linq Query Syntax
        // Nhóm sản phẩm theo giá
        // var qr = from p in products
        //          group p by p.Price into gr
        //          orderby gr.Key
        //          let sl = "So luong la " + gr.Count()
        //          select new
        //          {
        //              Gia = gr.Key,
        //              CacSanPham = gr.ToList(),
        //              SoLuong = sl,
        //          };

        // qr.ToList().ForEach(info =>
        // {
        //     Console.WriteLine(info.Gia);
        //     Console.WriteLine(info.SoLuong);

        //     info.CacSanPham.ToList().ForEach(p => Console.WriteLine(p));
        // });
        // ==============================

        // Linq Query Syntax
        // Lấy thông tin sản phẩm gồm tên sản phẩm, giá, tên thương hiệu (ko có thì xuất No Brand)
        var qr = from product in products
                 join brand in brands on product.Brand equals brand.ID into t
                 from b in t.DefaultIfEmpty()
                 select new
                 {
                    Ten = product.Name,
                    Gia = product.Price,
                    ThuongHieu = (b != null) ? b.Name : "No Brand",
                 };

        qr.ToList().ForEach(info =>
        {
            Console.WriteLine($"{info.Ten, 15} {info.ThuongHieu, 15} {info.Gia, 5}");
        });
        // ==============================
    }
}