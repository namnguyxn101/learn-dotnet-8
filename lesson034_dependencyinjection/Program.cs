// Dependency - Phụ thuộc
// Inverse of Control (IoC) / Dependency Inverse

interface IClassB
{
    public void ActionB();
}

interface IClassC
{
    public void ActionC();
}

class ClassC : IClassC
{
    public void ActionC() => Console.WriteLine("Action in ClassC");
}

class ClassC1 : IClassC
{
    public ClassC1() => Console.WriteLine("ClassC1 is created");
    public void ActionC()
    {
        Console.WriteLine("Action in C1");
    }
}

class ClassB1 : IClassB
{
    IClassC c_dependency;
    public ClassB1(IClassC classc)
    {
        c_dependency = classc;
        Console.WriteLine("ClassB1 is created");
    }
    public void ActionB()
    {
        Console.WriteLine("Action in B1");
        c_dependency.ActionC();
    }
}

class ClassB : IClassB
{
    // Phụ thuộc của ClassB là ClassC
    IClassC c_dependency;

    public ClassB(IClassC classc) => c_dependency = classc;
    public void ActionB()
    {
        Console.WriteLine("Action in ClassB");
        c_dependency.ActionC();
    }
}

class ClassA
{
    // Phụ thuộc của ClassA là ClassB
    IClassB b_dependency;

    public ClassA(IClassB classb) => b_dependency = classb;
    public void ActionA()
    {
        Console.WriteLine("Action in ClassA");
        b_dependency.ActionB();
    }
}

class Program
{
    static void Main()
    {
        IClassC objectC = new ClassC1();
        IClassB objectB = new ClassB1(objectC);
        ClassA objectA = new ClassA(objectB);

        objectA.ActionA();
    }
}