class SinhVien
{
    public string? HoTen { set; get; }
    public int NamSinh { set; get; }
    public string? NoiSinh { set; get; }
}

// Dynamic - Kiểu dữ liệu động
class Student
{
    public string? Name { set; get; }
    public int Age { set; get; }
    public void Hello() => Console.WriteLine(Name);

    // Dynamic - Kiểu dữ liệu động
    public static void PrintInfo(dynamic obj)
    {
        obj.Name = "Phuong Nam";
        obj.Hello();
        Console.WriteLine(obj.Age);
    }
}

class Program
{
    static void Main()
    {
        // // Anonymous - Kiểu dữ liệu vô danh
        // // Object - Thuộc tính - chỉ đọc
        // // new {thuoctinh = giatri, thuoctinh2 = giatri2}
        // var sanpham = new { 
        //     Ten = "iPhone 15 Pro Max",
        //     Gia = 1000,
        //     NamSX = 2024
        // };
        // // sanpham.Ten = "iPhone X"; // error
        // Console.WriteLine($"Ten: {sanpham.Ten}");
        // Console.WriteLine($"Gia: {sanpham.Gia}");
        //=======================================

        // List<SinhVien> CacSV = new List<SinhVien>() {
        //     new SinhVien() {HoTen = "Nam", NamSinh = 2004, NoiSinh = "Tien Giang"},
        //     new SinhVien() {HoTen = "Ngoc", NamSinh = 2002, NoiSinh = "Thanh Hoa"},
        //     new SinhVien() {HoTen = "Tan", NamSinh = 2005, NoiSinh = "An Giang"},
        //     new SinhVien() {HoTen = "Chien", NamSinh = 2003, NoiSinh = "Binh Duong"},
        // };

        // var DSSV = from sv in CacSV
        //            where sv.NamSinh <= 2004
        //            select new { sv.HoTen, sv.NamSinh, sv.NoiSinh };

        // foreach (var sv in DSSV)
        // {
        //     Console.WriteLine($"{sv.HoTen} - {sv.NamSinh} - {sv.NoiSinh}");
        // }
        //=======================================

        Student.PrintInfo(new Student());
    }
}