/*
    <Access Modifiers> <return type> <name method>(<parameters>)
    {
        // Xu ly
    }
*/
// static string XinChao(string firstname = "A", string lastname = "Nguyen Van")
// {
//     string fullname = $"{lastname} {firstname}";
//     return $"Xin chao {fullname}";
// }

// Console.WriteLine(XinChao());
// Console.WriteLine(XinChao("Nam", "Nguyen Phuong"));
// Console.WriteLine(XinChao(lastname: "Nguyen Le Nhat", firstname: "Nam"));
//=======================================================

using lesson009_methods;

Console.WriteLine(TinhToan.Tong(3, 4));
Console.WriteLine(TinhToan.Tong(5.5f, 2));
int a = 10;
Console.WriteLine($"{TinhToan.BinhPhuong(ref a)} (ref)");
int b = 10;
int kq;
TinhToan.BinhPhuong(b, out kq);
Console.WriteLine($"{kq} (out)");