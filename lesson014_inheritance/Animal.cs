using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson014_inheritance
{
    /*
        Tính kế thừa
        A, B
        B kế thừa A
        A - lớp cơ sở (cha)
        B - lớp kế thừa (con)
    */
    // Để tránh các lớp khác kế thừa đến class nào đó, sử dụng "sealed".
    // VD: sealed class Animal {}
    public class Animal
    {
        public int Legs { set; get; }

        public Animal()
        {
            Console.WriteLine("Khoi tao Animal (1)");
            Legs = 0;
        }

        public Animal(int Legs)
        {
            Console.WriteLine($"Khoi tao Animal (2)");
            this.Legs = Legs;
        }

        public void ShowLegs()
        {
            Console.WriteLine($"So chan: {Legs}");
        }
    }
}