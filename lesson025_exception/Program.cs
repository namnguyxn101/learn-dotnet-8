/*
// Khi khối try thực hiện nếu phát sinh lỗi thì nó sẽ thực hiện khối catch và đến hết chương trình
// Ngược lại khối catch sẽ được bỏ qua.
*/
// int a = 5;
// int b = 0;
// try
// {
//     var c = a / b; // Phát sinh đối tượng thuộc lớp Exception hoặc kế thừa lớp Exception.
//     Console.WriteLine(c);
// }
// catch (DivideByZeroException e)
// {
//     Console.WriteLine(e.Message);
//     Console.WriteLine(e.StackTrace);
//     Console.WriteLine(e.GetType().Name);
//     Console.WriteLine("Khong duoc chia cho 0");
// }
// catch (IndexOutOfRangeException e)
// {
//     Console.WriteLine(e.Message);
//     Console.WriteLine("Chi so mang khong hop le");
// }
// catch (Exception e)
// {
//     Console.WriteLine(e.Message);
// }

// Console.WriteLine("Ket thuc");
//======================================

// string path = "text.txt";
// try
// {
//     string s = File.ReadAllText(path);
//     Console.WriteLine(s);
// }
// catch (FileNotFoundException e)
// {
//     Console.WriteLine(e.Message);
//     Console.WriteLine("File khong ton tai");
// }
// catch (ArgumentNullException e)
// {
//     Console.WriteLine(e.Message);
//     Console.WriteLine("Duong dan file phai khac null");
// }
// catch (Exception e)
// {
//     Console.WriteLine(e.Message);
// }
// Console.WriteLine("Ket thuc");
//======================================

using MyExceptions;

class Program
{
    static void Register(string? Name, int Age)
    {
        if (string.IsNullOrEmpty(Name))
        {
            // Exception exception = new Exception("Ten khong duoc rong");
            // throw exception;
            throw new NameEmptyException();
        }
        if (Age < 18 || Age > 100)
        {
            // throw new Exception("Tuoi phai >= 18 va <= 100");
            throw new AgeInvalidException(Age);
        }
    }

    static void Main()
    {
        try
        {
            Register("Phuong Nam", 10);
        }
        catch (NameEmptyException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (AgeInvalidException e)
        {
            Console.WriteLine(e.Message);
            e.Detail();
        }
    }
}