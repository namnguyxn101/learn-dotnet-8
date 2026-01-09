// int a;
// Console.Write("Nhap a: ");
// a = Convert.ToInt32(Console.ReadLine());

// switch(a)
// {
//     case 1:
//         Console.WriteLine("One");
//     break;
//     case 2:
//         Console.WriteLine("Two");
//     break;
//     case 3:
//         Console.WriteLine("Three");
//     break;
//     case 4:
//         Console.WriteLine("Four");
//     break;
//     case 5:
//         Console.WriteLine("Five");
//     break;
//     default:
//         Console.WriteLine("Try another number");
//     break;
// }
//==================================================

int a, b;
Console.Write("Nhap so nguyen a: ");
a = Convert.ToInt32(Console.ReadLine());

Console.Write("Nhap so nguyen b: ");
b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Chon chuc nang: ");
Console.WriteLine("1. Tinh tong");
Console.WriteLine("2. Tinh hieu");
Console.WriteLine("3. Tinh tich");
Console.WriteLine("4. Tinh thuong");

L1:
char c = Console.ReadKey().KeyChar;
Console.WriteLine();

switch(c)
{
    case '1':
        Console.WriteLine($"Tong = {a + b}");
    break;
    case '2':
        Console.WriteLine($"Hieu = {a - b}");
    break;
    case '3':
        Console.WriteLine($"Tich = {a * b}");
    break;
    case '4':
        Console.WriteLine($"Thuong = {a / b}");
    break;
    default:
        Console.WriteLine("Chon chuc nang khac");
    goto L1;
}