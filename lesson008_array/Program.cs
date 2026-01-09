using System.Linq; // Thu vien mo rong nhieu chuc nang cho mang
// string[] ds;
// ds = new string[3];
// ds[0] = "Nguyen Van A";
// ds[1] = "Nguyen Van B";
// ds[2] = "Nguyen Van C";

// for (int i = 0; i < 3; i++) {
//     Console.WriteLine(ds[i]);
// }
//================================

// int[] mangSoNguyen = new int[3] { 4, 1, 7 };
// int[] mangSoNguyen2 = { 4, 9, 7, 11, 32, 5 };
// for (int i = 0; i < mangSoNguyen2.Length; i++)
// {
//     Console.Write($"{mangSoNguyen2[i]} ");
// }
// Console.WriteLine();
// // Dung foreach
// foreach (var number in mangSoNguyen2)
// {
//     Console.Write($"{number} ");
// }
//================================

// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// Console.WriteLine($"So phan tu: {numbers.Length}");
// Console.WriteLine($"Chieu: {numbers.Rank}");
// Console.WriteLine($"Min: {numbers.Min()}");
// Console.WriteLine($"Max: {numbers.Max()}");
// Console.WriteLine($"Tong cac pt trong mang: {numbers.Sum()}");

// Array.Sort(numbers);
// Console.WriteLine("Sau khi sap tang dan: ");
// foreach (var number in numbers)
// {
//     Console.Write($"{number} ");
// }
//================================

// Mang so thuc 2 chieu
// double[,] numbers = new double[2, 3] { {2, 3, 4.5}, {1, 9, 8} };
// int row = 2, col = 3;
// for (int i = 0; i < row; i++)
// {
//     for (int y = 0; y < col; y++)
//     {
//         Console.Write($"{numbers[i, y], -8} ");
//     }
//     Console.WriteLine();
// }
//================================

// Tim pt mang ma mang phai co thu tu tang dan
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// Array.Sort(numbers); // 4 5 7 9 11 32
// int posNum = Array.BinarySearch(numbers, 9);
// Console.WriteLine($"So 9 o vi tri: {posNum}");
//================================

// Sao chep mang
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// int[] newNumbers = new int[6];
// numbers.CopyTo(newNumbers, 0);
// foreach (var number in newNumbers)
// {
//     Console.Write($"{number} ");
// }
//================================

// Thiet lap gia tri pt mang ve mac dinh
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// foreach (var number in numbers)
// {
//     Console.Write($"{number} ");
// }
// Console.WriteLine();
// Array.Clear(numbers);
// foreach (var number in numbers)
// {
//     Console.Write($"{number} ");
// }
//================================

// Kiem tra ton tai
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// Console.WriteLine(Array.Exists(numbers, element => element == 11));
//================================

// Gan toan bo cac pt mang bang gia tri chi dinh
// int[] numbers = new int[5];
// Array.Fill(numbers, 1);
// foreach (var number in numbers)
// {
//     Console.Write($"{number} ");
// }
//================================

// Tim pt mang thoa man dieu kien, return pt dau tien
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// Console.WriteLine(Array.Find(numbers, element => element % 2 == 0));
//================================

// Tim pt mang thoa man dieu kien, return vi tri 
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// Console.WriteLine(Array.FindIndex(numbers, element => element == 9));
//================================

// Tim cac pt thoa man dieu kien, return ve mang
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// int[] newNumbers = Array.FindAll(numbers, element => element % 2 == 0);
// foreach (var number in newNumbers)
// {
//     Console.Write($"{number} ");
// }
//================================

// Tim pt mang, return vi tri
// int[] numbers = { 4, 9, 7, 11, 32, 5 };
// Console.WriteLine(Array.IndexOf(numbers, 7));
//================================

// Duyet qua tung pt roi xuat gia tri gap doi cua no
// int[] numbers = { 1, 2, 3, 4 };
// Array.ForEach(numbers, (number) => {
//     Console.Write($"{number * 2} ");
// });