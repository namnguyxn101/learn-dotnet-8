/*
Lambda - Anonymous function
Cách viết 1
(tham_so) => bieu_thuc;

Cách viết 2
(tham_so) => {
    cac_bieu_thuc;
    return bieu_thuc_tra_ve;
}
*/
// Action ThongBao = () => Console.WriteLine("Xin chao cac ban");
// ThongBao.Invoke();

// Action<string, string> Welcome = (msg, name) =>
// {
//     Console.ForegroundColor = ConsoleColor.DarkCyan;
//     Console.WriteLine($"{msg} {name}");
//     Console.ResetColor();
// };
// Welcome.Invoke("Xin chao", "Nam Nguyen");

// Func<int, int, int> TinhToan = (x, y) => x + y;
// Console.WriteLine($"9 + 4 = {TinhToan.Invoke(9, 4)}");
//=====================================

// int[] mang = { 3, 1, 2, 9, 4, 8, 5, 7, 6 };
// var kq = mang.Select(x => x * x);
// foreach (var element in kq)
// {
//     Console.Write(element + " ");
// }
//=====================================

// int[] mang = { 3, 1, 2, 9, 4, 8, 5, 7, 6 };
// mang.ToList().ForEach(element =>
// {
//     if (element % 2 != 0)
//     {
//         Console.WriteLine(element);
//     }
// });
//=====================================

int[] mang = { 3, 1, 2, 9, 4, 8, 5, 7, 6 };
var kq = mang.Where(x => x % 3 == 0);
foreach (var element in kq)
{
    Console.WriteLine(element);
}