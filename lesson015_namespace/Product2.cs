using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanPham
{
    public partial class Product
    {
        public Manufactory? manufactory { set; get; }
        public class Manufactory
        {
            public string? Name { set; get; }
            public string? Address { set; get; }
        }
        public string? Description { set; get; }
    }
}