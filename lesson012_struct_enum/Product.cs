using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson012_struct_enum
{
    // Class - Kiểu tham chiếu
    // Struct - Kiểu tham trị
    public struct Product
    {
        // DATA
        public string Name;
        public double Price;

        // PROPERTIES
        public string Info
        {
            get
            {
                return $"{Name} - {Price}";
            }
        }

        // CONSTRUCTOR
        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        // METHOD
        public void ShowInfo()
        {
            Console.WriteLine($"Ten san pham: {Name} - Gia: {Price}");
        }
    }
}