// syntax: delegate (Type) biến = phương thức
public delegate void ShowLog(string message);

class Program
{
    static void Info(string s)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(s);
        Console.ResetColor();
    }

    static void Warning(string s)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(s);
        Console.ResetColor();
    }

    static int Tong(int a, int b) => a + b;
    static int Hieu(int a, int b) => a - b;

    static void TinhTong(int a, int b, ShowLog log)
    {
        int kq = a + b;
        log.Invoke($"Tong la {kq}");
    }

    static void Main()
    {
        // ShowLog log;
        // log = Info;
        // // log("Xin chao");
        // // Hoặc
        // // Phương thức Invoke dùng để gọi các phương thức lưu trong biến
        // log.Invoke("Xin chao");
        //=========================================

        // ShowLog? log = null;
        // log += Info;
        // log += Info;
        // log += Info;
        // log += Warning;
        // log += Warning;
        // log += Info;
        // log.Invoke("Xin chao");
        //=========================================

        // // Action (void), Func(có kiểu trả về) : delegate - generic
        // // Action action;                  // ~ delegate void KIEU();
        // // Action<string, int> action1;    // ~ delegate void KIEU(string s, int i);

        // Action<string> action2;         // ~ delegate void KIEU(string s);
        // action2 = Info;
        // action2 += Warning;
        // action2.Invoke("Thong bao tu Action");

        // // Func<int> f1;                       // ~ delegate int KIEU();
        // // Khi dùng Func thì kiểu trả về được liệt kê ở cuối cùng
        // // Func<int, double, string> f2;       // ~ delegate string KIEU(int i, double d);

        // Func<int, int, int> TinhToan;
        // int a = 10, b = 5;
        // TinhToan = Tong;
        // Console.WriteLine($"Kq: {TinhToan(a, b)}");
        //=========================================

        Action<int, int, ShowLog> tong = TinhTong;
        tong(4, 6, Warning);
    }
}