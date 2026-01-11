class CountNumber
{
    private static int number = 0;
    public static void Info()
    {
        Console.WriteLine("So lan truy cap: " + number);
    }

    public void Count()
    {
        // CountNumber.number++;
        number++;
    }
}

class Student
{
    // Chỉ đọc
    public readonly string Name;
    public Student()
    {
        Name = "Nguyen Van A";
    }
    public Student(string _Name)
    {
        Name = _Name;
    }
}

class Vector
{
    double x;
    double y;
    public Vector(double _x, double _y)
    {
        x = _x;
        y = _y;
    }
    public void Info()
    {
        Console.WriteLine($"x = {x}, y = {y}");
    }
    // Overload operator
    public static Vector operator +(Vector v1, Vector v2)
    {
        double x = v1.x + v2.x;
        double y = v1.y + v2.y;
        return new Vector(x, y);
    }
    public static Vector operator +(Vector v1, double value)
    {
        double x = v1.x + value;
        double y = v1.y + value;
        return new Vector(x, y);
    }
    // Indexer
    public double this[int i]
    {
        set
        {
            switch (i)
            {
                case 0:
                    x = value;
                    break;
                case 1:
                    y = value;
                    break;
                default:
                    throw new Exception("Chi so sai");
            }
        }
        get
        {
            switch (i)
            {
                case 0:
                    return x;
                case 1:
                    return y;
                default:
                    throw new Exception("Chi so sai");
            }
        }
    }
    public double this[string s]
    {
        set
        {
            switch (s)
            {
                case "toadox":
                    x = value;
                    break;
                case "toadoy":
                    y = value;
                    break;
                default:
                    throw new Exception("Chi so sai");
            }
        }
        get
        {
            switch (s)
            {
                case "toadox":
                    return x;
                case "toadoy":
                    return y;
                default:
                    throw new Exception("Chi so sai");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // CountNumber c1 = new CountNumber();
        // CountNumber c2 = new CountNumber();

        // c1.Count();
        // c2.Count();

        // CountNumber.Info();
        //===============================

        // Student s = new Student("Nguyen Phuong Nam");
        // Console.WriteLine(s.Name);
        //===============================

        // Vector v1 = new Vector(2, 3);
        // Vector v2 = new Vector(1, 1);
        // // var v3 = v1 + v2;
        // var v3 = v1 + 10;
        // v1.Info();
        // v2.Info();
        // v3.Info();
        //===============================

        Vector v = new Vector(2, 3);
        // v[0] = 5;
        // v[1] = 9;
        v["toadox"] = 5;
        v["toadoy"] = 9;
        Console.WriteLine(v["toadox"]);
    }
}