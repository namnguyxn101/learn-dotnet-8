/*
Cu phap: Kieu_du_lieu ten_bien;
Ten_bien:
    - a..z; A..Z
    - 0..9
    - _
    - Ko bắt đầu bằng số
    - Ko trùng keywords NNLT
*/
// string studentName;
// int studentAge;

// char a;
// bool b;

// Mặc định khi gán 1 số thực cho biến nó sẽ hiểu đó là double.
// Nên nếu khai báo kiểu float phải thêm "f" sau số đó.
// float c;
// c = 12.23f;
// hoặc
// c = (float)12.23;

// string là 1 class kế thừa từ object.
// Nên nó có thể gán cho 1 biến kiểu object.
// studentName = "Phuong Nam";
// object d = studentName;

// Nếu 3 biến cùng KDL thì có thể.
// int x = 2, y = 5, z = 9;
//=======================================

// Console.Title = "Vi du su dung Console";
// Console.Clear();

// // Thiết lập màu chữ
// Console.ForegroundColor = ConsoleColor.Cyan;
// // Thiết lập màu nền
// Console.BackgroundColor = ConsoleColor.DarkYellow;

// Console.WriteLine();
// Console.WriteLine();
// Console.WriteLine("Xin chao, day la chuong trinh nhap xuat du lieu console");

// Console.ResetColor();

// Console.Write("Gia tri cua c la: ");

// Dừng, chờ nhấn phím rồi chạy tiếp
// Console.ReadKey();

// Console.WriteLine(c);
//=======================================

// string fullName;
// Console.Write("Nhap ho ten: ");
// fullName = Console.ReadLine();

// Console.WriteLine("Xin chao {0}", fullName);
//=======================================

float a, b;

Console.WriteLine("Hay nhap so a: ");
a = float.Parse(Console.ReadLine()!);

Console.Write("Hay nhap so b: ");
b = Convert.ToSingle(Console.ReadLine());

Console.WriteLine("So a = {0}, b = {1}", a, b);
//=======================================

// Kiểu khai báo biến ngầm định, dùng "var".
// Phải khởi tạo biến khi dùng var.
// KDL của biến đc xác định bằng giá trị mà ta gán.
// Biến khai báo bằng var sẽ dùng KDL đó luôn, ko gán lại giá trị có KDL khác đc.
//var a = 1; // int
//Console.WriteLine(a);
//=======================================

// Khai báo hằng
// const double PI = 3.141592654;
// Console.WriteLine(PI);