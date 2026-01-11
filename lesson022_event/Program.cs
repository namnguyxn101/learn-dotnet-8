/*
publisher -> class - phát sự kiên
subscriber -> class - nhận sự kiện
*/
public delegate void SuKienNhapSo(int x);
class DuLieuNhap : EventArgs
{
    public int Data { set; get; }
    public DuLieuNhap(int x) => Data = x;
}

// publisher
class UserInput
{
    // public SuKienNhapSo? Sknhapso { set; get; } // chỉ thêm được 1 sự kiện
    // Khi khai báo biến kiểu delegate và có từ khóa event -> biến này chỉ có thể thực hiện += hoặc -=
    // public event SuKienNhapSo? Sknhapso;
    // Thư viện trong C# đã khai báo sẵn cho ta 1 cấu trúc delegate chuyên để khai báo tạo ra các sự kiện.
    public event EventHandler? Sknhapso;// ~ delegate void KIEU(object? sender, EventArgs args)

    public void Input()
    {
        do
        {
            Console.Write("Nhap vao mot so: ");
            string? s = Console.ReadLine();
            int i = Convert.ToInt32(s);
            // phát sự kiện
            // Sknhapso?.Invoke(i);
            Sknhapso?.Invoke(this, new DuLieuNhap(i));
        } while (true);
    }
}

// subscriber
class Can
{
    public void Sub(UserInput ui)
    {
        ui.Sknhapso += TinhCan;
    }
    public void TinhCan(object? sender, EventArgs e)
    {
        DuLieuNhap dulieunhap = (DuLieuNhap)e;
        int i = dulieunhap.Data;
        Console.WriteLine($"Can bac 2 cua {i} la {Math.Sqrt(i)}");
    }
}

class BinhPhuong
{
    public void Sub(UserInput ui)
    {
        ui.Sknhapso += TinhBP;
    }
    public void TinhBP(object? sender, EventArgs e)
    {
        DuLieuNhap dulieunhap = (DuLieuNhap)e;
        int i = dulieunhap.Data;
        Console.WriteLine($"Binh phuong cua {i} la {i * i}");
    }
}

class Program
{
    static void Main()
    {
        Console.CancelKeyPress += (sender, e) =>
        {
            Console.WriteLine("\nThoat ung dung");
        };

        // publisher
        UserInput userInput = new UserInput();

        userInput.Sknhapso += (sender, e) =>
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            Console.WriteLine($"Ban vua nhap so {duLieuNhap.Data}");
        };

        // subscriber
        Can can = new Can();
        can.Sub(userInput);

        // subscriber
        BinhPhuong binhPhuong = new BinhPhuong();
        binhPhuong.Sub(userInput);

        userInput.Input();
    }
}