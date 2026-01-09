/*
for (khoi_tao; dieu_kien; cap_nhat) 
{
    // Xu ly
}
*/
// Xuat cac so chan tu 0 -> 20
// int i;
// for (i = 0, Console.WriteLine("Khoi tao"); i <= 20; i++, Console.WriteLine("Cap nhat i"))
// {
//     if (i % 2 == 0)
//     {
//         Console.Write($"{i} \n");
//     }
// }
//=======================================

// int i = 1;
// while (i <= 10)
// {
//     Console.WriteLine($"2 x {i} = {2 * i}");
//     i++;
// }
//=======================================

// int i = 11;
// do
// {
//     Console.WriteLine($"2 x {i} = {2 * i}");
//     i++;
// } while (i <= 10);
//=======================================

// Dung vong lap khi i = 10
int i = 0;
while (i <= 20)
{
    if (i == 10) break;

    Console.Write($"{i} ");
    i++;
}
Console.WriteLine();
// Bo qua y tu 5 -> 15
int y = 0;
for ( ; y <= 20; y++)
{
    if (y >= 5 && y <= 15) continue;
    Console.Write($"{y} ");
}