class Product<A>
{
    A? ID;
    public void SetID(A _ID)
    {
        ID = _ID;
    }

    string? Name;
    public void SetName(string Name)
    {
        this.Name = Name;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"ID = {ID}");
        Console.WriteLine($"Name = {Name}");
    }
}

class Program
{
    static void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }
    static void Main()
    {
        // int i1 = 4;
        // int i2 = 9;
        // Console.WriteLine($"i1 = {i1}, i2 = {i2}");
        // Swap(ref i1, ref i2);
        // Console.WriteLine($"i1 = {i1}, i2 = {i2}");

        // double d1 = 3.5;
        // double d2 = 11.2;
        // Console.WriteLine($"d1 = {d1}, d2 = {d2}");
        // Swap(ref d1, ref d2);
        // Console.WriteLine($"d1 = {d1}, d2 = {d2}");

        // string s1 = "Abc";
        // string s2 = "Xyz";
        // Console.WriteLine($"s1 = {s1}, s2 = {s2}");
        // Swap(ref s1, ref s2);
        // Console.WriteLine($"s1 = {s1}, s2 = {s2}");
        //=====================================

        // Product<int> product1 = new Product<int>();
        // product1.SetID(123);
        // product1.SetName("Dien thoai");
        // product1.PrintInfo();

        // Product<string> product2 = new Product<string>();
        // product2.SetID("P001");
        // product2.SetName("Laptop");
        // product2.PrintInfo();
        //=====================================

        List<int> list1 = new List<int>();
        List<string> list2 = new List<string>();

        // Stack<int> stack;
        // Queue<double> queue;
    }
}