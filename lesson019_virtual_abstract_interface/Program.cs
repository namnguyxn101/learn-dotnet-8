// using Virtual;
// using Abstract;
using Interface;

class Program
{
    static void Main()
    {
        // Samsung s = new Samsung();
        // s.ProductInfo();
        //========================================

        // Samsung s = new Samsung();
        // s.Test();
        //========================================

        IHinhHoc hcn = new HinhChuNhat(3, 5);
        Console.WriteLine($"Dien tich hcn: {hcn.TinhDienTich()}");
        Console.WriteLine($"Chu vi hcn: {hcn.TinhChuVi()}");

        IHinhHoc ht = new HinhTron(1);
        Console.WriteLine($"Dien tich ht: {ht.TinhDienTich()}");
        Console.WriteLine($"Chu vi ht: {ht.TinhChuVi()}");
    }
}