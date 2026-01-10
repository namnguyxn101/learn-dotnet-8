using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson014_inheritance
{
    public class Cat : Animal
    {
        protected string Food;
        
        public Cat()
        {
            Console.WriteLine("Khoi tao Cat (1)");
            Food = "";
        }

        public Cat(string Food, int Legs) : base(Legs)
        {
            Console.WriteLine("Khoi tao Cat (2)");
            this.Food = Food;
        }

        public void Eat()
        {
            Console.WriteLine($"Food: {Food}");
        }

        public new void ShowLegs()
        {
            Console.WriteLine($"Loai meo co {Legs} chan");
        }

        public void ShowInfo()
        {
            // Gọi đến ShowLegs của lớp cơ sở
            base.ShowLegs();
            // Gọi đến ShowLegs của lớp hiện tại
            ShowLegs();
        }
    }
}