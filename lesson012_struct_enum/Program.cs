using lesson012_struct_enum;

// Product product1;
// product1.Name = "iPhone";
// product1.Price = 1000;

// Product product2 = new Product("Vivo", 700);
// product2 = product1;
// product2.Name = "Samsung";
// product2.Price = 900;

// Console.ForegroundColor = ConsoleColor.DarkCyan;
// product1.ShowInfo();
// product2.ShowInfo();
// Console.WriteLine(product2.Info);
// Console.ResetColor();
//==========================================

HocLuc hocluc = HocLuc.Kha;
Console.WriteLine((int)hocluc);
// switch(hocluc)
// {
//     case HocLuc.Kem: Console.WriteLine("Hoc luc kem"); break;
//     case HocLuc.TrungBinh: Console.WriteLine("Hoc luc trung binh"); break;
//     case HocLuc.Kha: Console.WriteLine("Hoc luc kha"); break;
//     case HocLuc.Gioi: Console.WriteLine("Hoc luc gioi"); break;
// }
switch((int)hocluc)
{
    case 123: Console.WriteLine("Hoc luc kem"); break;
    case 234: Console.WriteLine("Hoc luc trung binh"); break;
    case 345: Console.WriteLine("Hoc luc kha"); break;
    case 456: Console.WriteLine("Hoc luc gioi"); break;
}