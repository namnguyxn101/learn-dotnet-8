using System;
using Demo;

namespace lesson001_helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            /*F
            Comment block
            */

            // Comment line

            Console.WriteLine("Hello world");
        }

        /// <summary>
        /// Phuong thuc tra ve tong cua 2 so nguyen
        /// </summary>
        /// <param name="a">so nguyen 1</param>
        /// <param name="b">so nguyen 2</param>
        /// <returns>Tong a + b</returns>
        static int Tong(int a, int b)
        {
            return a + b;
        }
    }
}

namespace Demo
{
    class Abc
    {
        static void Greet()
        {
            Console.WriteLine("Welcome to C#");
        }
    }
}