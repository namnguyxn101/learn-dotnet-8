// string FullName = "Nguyen Phuong Nam";
// string Greeting = "Xin chao";
// string Message = $"{Greeting} {FullName}!";
// Console.WriteLine(Message);
//========================================

// string Message;
// int year = 2024;
// Message = "Hoc ve chuoi ki tu \"string\"";
// Console.WriteLine(Message);

// Message = @"Xin chao        ""2024""

// Hoc lap trinh C#
// ";
// Console.WriteLine(Message);

// Message = $"Xin chao {year, 10}, nam sau la nam {year + 1}";
// Console.WriteLine(Message);

// Message = $"Xin chao {year, -10}, nam sau la nam {year + 1}";
// Console.WriteLine(Message);

// string FullName = "Nguyen Phuong Nam";
// int BirthYear = 2004;
// string Gender = "Nam";
// Message = $@"
// Ho ten: {FullName}
// Nam sinh: {BirthYear}
// Gioi tinh: {Gender}";
// Console.WriteLine(Message);
//========================================

// string Message;
// Message = "Xin chao, toi ten Nam";
// int Size = Message.Length;
// Console.WriteLine(Size);

// for (int i = 0; i < Size; i++)
// {
//     char c = Message[i];
//     Console.WriteLine($"Chi so {i} la ki tu: {c, 3}");
// }

// foreach (var kiTu in Message)
// {
//     Console.Write(kiTu + "__");
// }
//========================================

// string Message;
// Message = "    Xin chao, toi ten Nam   ";
// Console.WriteLine(Message);

// Message = Message.Trim();
// Console.WriteLine(Message);

// Message = "    ***Xin chao, toi ten Nam)))      ";
// Console.WriteLine(Message);

// Message = Message.Trim();
// Message = Message.TrimStart('*');
// Message = Message.TrimEnd(')');
// Console.WriteLine(Message);
//========================================

// string Message;
// Message = "Hello world";
// Console.WriteLine(Message.ToUpper());
// Console.WriteLine(Message.ToLower());
//========================================

// string Message;
// Message = "Phuong Nam, xin chao cac ban!";
// Message = Message.Replace("xin chao", "chao mung");
// Console.WriteLine(Message);
//========================================

// string Message;
// Message = "Phuong Nam, xin chao cac ban!";
// Message = Message.Insert(10, " 2024");
// Console.WriteLine(Message);
//========================================

// string Message;
// Message = "Phuong Nam, xin chao cac ban!";
// Message = Message.Substring(12, 8);
// Console.WriteLine(Message);
//========================================

// string Message;
// Message = "Phuong Nam, xin chao cac ban!";
// Message = Message.Remove(10, 5);
// Console.WriteLine(Message);
//========================================

// string Message;
// Message = "Phuong Nam, xin chao cac ban!";
// string[] SubStrings = Message.Split(' ');
// foreach (var s in SubStrings)
// {
//     Console.WriteLine(s);
// }
//========================================

// string Message;
// string[] SubStrings = { "Hoc", "Lap", "Trinh", "C#" };
// Message = string.Join('_', SubStrings);
// Console.WriteLine(Message);
//========================================

using System.Text;
// StringBuilder: Lớp này tạo ra một đối tượng dùng để xây dựng nên các chuỗi
StringBuilder thongBao = new StringBuilder();
thongBao.Append("Xin");
thongBao.Append(" chao cac ban");
thongBao.Replace("Xin chao", "Chao mung");

string chuoiKQ = thongBao.ToString();
Console.WriteLine(chuoiKQ);
// Khi xây dựng chuỗi nên dùng StringBuilder vì hiệu năng của nó tốt hơn chuỗi thông thường
// Mỗi khi ta thực hiện thao tác trên StringBuilder thì nó thực hiện trên 1 vùng đệm bộ nhớ duy nhất