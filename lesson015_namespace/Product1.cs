using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanPham
{
    public partial class Product
    {
        public string? Name { set; get; }
        public decimal Price { set; get; }

        public string GetInfo()
        {
            return $"San pham: {Name}\nGia: {Price}\nMo ta: {Description}\nHang san xuat: {manufactory?.Name}\nNoi san xuat: {manufactory?.Address}";
        }
    }
}