// float mark;
// string classification;
// Console.Write("Nhap so diem: ");
// mark = Convert.ToSingle(Console.ReadLine());

// if (mark < 5) {
//     classification = "Kem";
// } else if (mark < 6.5) {
//     classification = "Trung binh";
// } else if (mark < 8) {
//     classification = "Kha";
// } else if (mark < 9) {
//     classification = "Gioi"; 
// } else {
//     classification = "Xuat sac";
// }

// Console.WriteLine($"Ban la hoc sinh {classification}");
//=================================================

// Toan tu 3 ngoi (toan tu dieu kiem)
// (dieu_kien) ? bieu_thuc_1 : bieu_thuc_2;
// Neu dieu_kien la true thi return bieu_thuc_1
// Nguoc lai return bieu_thuc_2
int a = 4, b = 9;
int max = (a > b) ? a : b;
Console.WriteLine($"So lon nhat: {max}");

int c = 10;
max = a;
if (b > max)
{
    max = b;
}

if (c > max)
{
    max = c;
}
Console.WriteLine($"So lon nhat: {max}");