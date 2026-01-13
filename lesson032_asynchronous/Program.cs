using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

class Program
{
    // asynchronous - tạo ra các ứng dụng có khả năng chạy đa luồng (multi thread)
    public static void DoSomething(int seconds, string msg, ConsoleColor color)
    {
        // Khi gọi Thread.Sleep --> luồng đang chạy hiện tại sẽ dừng một khoảng thời gian (millisecond) do chúng ta chỉ định
        // Thread.Sleep(3000);

        lock (Console.Out)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{msg,10} ... Start");
            Console.ResetColor();
        }

        for (int i = 1; i <= seconds; i++)
        {
            // Khóa thuộc tính có kiểu TextWriter để đảm bảo console đặt màu chữ xong sau đó in text ra hoàn tất rồi mới mở khóa để luồng khóa đặt màu chữ khác
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10} {i,2}");
                Console.ResetColor();
            }

            Thread.Sleep(1000);
        }

        lock (Console.Out)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{msg,10} ... End");
            Console.ResetColor();
        }
    }

    public static async Task Task2()
    {
        Task t2 = new Task(
            () =>
            {
                DoSomething(10, "T2", ConsoleColor.Green);
            }
        );

        t2.Start();
        await t2;

        Console.WriteLine("T2 da hoan thanh");

        // Phương thức async ko cần trả về task vì nó đã trả về tại thời điểm gọi await
        // return t2;
    }

    public static async Task Task3()
    {
        Task t3 = new Task(
            (object? obj) =>
            {
                string TenTacVu = (string?)obj ?? string.Empty;
                DoSomething(4, TenTacVu, ConsoleColor.Yellow);
            }
            , "T3"
        );

        t3.Start();
        await t3;
        Console.WriteLine("T3 da hoan thanh");

        // Phương thức async ko cần trả về task vì nó đã trả về tại thời điểm gọi await
        // return t3;
    }

    public static async Task<string> Task4()
    {
        Task<string> t4 = new Task<string>(
            () =>
            {
                DoSomething(10, "T4", ConsoleColor.Cyan);
                return "Return from T4";
            }
        );

        t4.Start();
        var kq = await t4;

        Console.WriteLine("T4 da hoan thanh");
        return kq;
    }

    public static async Task<string> Task5()
    {
        Task<string> t5 = new Task<string>(
            (object? obj) =>
            {
                string t = (string?)obj ?? string.Empty;
                DoSomething(4, t, ConsoleColor.Red);
                return $"Return from {t}";
            }
            , "T5"
        );

        t5.Start();
        var kq = await t5;

        Console.WriteLine("T5 da hoan thanh");
        return kq;
    }

    // public static void Main()
    public static async Task Main()
    {
        var sw = Stopwatch.StartNew();

        // synchrounous
        // DoSomething(6, "T1", ConsoleColor.Magenta);
        // DoSomething(10, "T2", ConsoleColor.Green);
        // DoSomething(4, "T3", ConsoleColor.Yellow);

        // Console.WriteLine("Xong tat ca");
        // =======================================

        // asynchrounous
        // Lớp để biểu diễn các tác vụ chạy song song hoặc đồng thời với nhau: Task, Task<T>

        // Task t2 = new Task(Action); // ~ () => {}
        // Task t2 = new Task(
        //     () =>
        //     {
        //         DoSomething(10, "T2", ConsoleColor.Green);
        //     }
        // );

        // // Task t3 = new Task(Action<Object>, Object); // ~ (Object obj) => {} 
        // Task t3 = new Task(
        //     (object? obj) =>
        //     {
        //         string TenTacVu = (string?)obj ?? string.Empty;
        //         DoSomething(4, TenTacVu, ConsoleColor.Yellow);
        //     }
        //     , "T3"
        // );

        // t2.Start(); // Thread
        // t3.Start(); // Thread
        // DoSomething(6, "T1", ConsoleColor.Magenta); // Thread

        // // Wait() đảm bảo tác vụ phải hoàn thành rồi mới thực hiện mã bên dưới
        // // t2.Wait();
        // // t3.Wait();
        // // Thay vì viết wait cho từng task --> dùng Task.WaitAll([cac_tac_vu]);
        // Task.WaitAll(t2, t3);
        // =======================================

        // Các tác vụ thường sẽ đc khai báo trong các phương thức --> Tạo ra các phương thức trả về Task
        Task t2 = Task2();
        Task t3 = Task3();
        Task<string> t4 = Task4();
        Task<string> t5 = Task5();

        DoSomething(6, "T1", ConsoleColor.Magenta);

        // Bỏ vì đã thêm async cho pthuc Main
        // Task.WaitAll(t2, t3);
        await t2;
        await t3;

        var kq4 = await t4;
        var kq5 = await t5;

        Console.WriteLine(kq4);
        Console.WriteLine(kq5);

        sw.Stop();
        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine("Press any key");
        Console.ReadKey();
        Console.WriteLine();
    }
}