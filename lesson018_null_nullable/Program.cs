class Abc
{
    public void XinChao() => Console.WriteLine("Xin chao C#");
}
class Program
{
    static void Main(string[] args)
    {
        // // null, nullable
        // // null: được sử dụng cho các biến tham chiếu
        // Abc a = new Abc();
        // // if (a != null)
        // //     a.XinChao();
        // // Cách viết ngắn
        // a?.XinChao();
        //===================================

        // Nullable<int> num = null;
        // Viết gọn
        int? num = null;
        num = 100;
        // if (num.HasValue)
        // {
        //     int _num = num.Value;
        //     Console.WriteLine(_num);
        // }
        // Cách khác
        if (num != null)
        {
            int _num = (int)num;
            Console.WriteLine(_num);
        }
    }
}