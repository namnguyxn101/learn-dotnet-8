using MyLib;

// Extension method
// Lop tinh static
static class Abc
{
    // Muốn mở rộng phương thức cho lớp nào thì tham số đầu tiên phải là đối tượng của lớp đó.
    // Thêm từ khóa this.
    public static void Print(this string s, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(s);
        Console.ResetColor();
    }
}

class Program
{
    static void Main()
    {
        // string s = "Xin chao cac ban";
        // s.Print(ConsoleColor.Green);
        // s.Print(ConsoleColor.Red);
        //=============================================

        double a = 2.5;
        Console.WriteLine(a.BinhPhuong());
        Console.WriteLine(a.CanBacHai());
    }
}