namespace MyNameSpace
{
    // class, struct, enum, interface, ... namespace
    public class Class1
    {
        public static void XinChao()
        {
            Console.WriteLine("Xin chao tu Class1 (MyNameSpace)");
        }
    }

    namespace Abc
    {
        public class Class1
        {
            public static void XinChao()
            {
                Console.WriteLine("Xin chao tu Class1 (MyNameSpace / Abc)");
            }
        }
    }
}