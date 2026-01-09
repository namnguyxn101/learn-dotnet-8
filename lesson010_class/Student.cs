using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson010_class
{
    public class Student : IDisposable
    {
        string Name = "";
        public Student(string Name)
        {
            Console.WriteLine("Khoi tao " + Name);
            this.Name = Name;
        }

        // PHƯƠNG THỨC HỦY
        // Được .NET tự thi hành khi nó thấy thiếu vùng nhớ
        ~Student()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Huy " + Name);
            Console.ResetColor();
        }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Huy (boi dispose) " + Name);
            Console.ResetColor();
        }
    }
}