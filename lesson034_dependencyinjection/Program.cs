// Dependency - Phụ thuộc
// Inverse of Control (IoC) / Dependency Inverse
// Một trong những phương pháp áp dụng nguyên tắc IoC này --> Dependency Injection (DI)

using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;

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

class ClassB2 : IClassB
{
    IClassC c_dependency;
    string message;
    public ClassB2(IClassC classc, string mgs)
    {
        c_dependency = classc;
        message = mgs;
        Console.WriteLine("ClassB2 is created");
    }
    public void ActionB()
    {
        Console.WriteLine(message);
        c_dependency.ActionC();
    }
}

class Program
{
    public static IClassB CreateB2(IServiceProvider provider)
    {
        var b2 = new ClassB2(
            provider.GetService<IClassC>() ?? new ClassC(),
            "Thực hiện trong ClassB2"
        );

        return b2;
    }

    static void Main()
    {
        var services = new ServiceCollection();

        // ClassA
        // IClassB, ClassB, ClassB1
        // IClassC, ClassC, ClassC1

        services.AddSingleton<ClassA, ClassA>();

        // Sử dụng Delegate
        // services.AddSingleton<IClassB>(
        //     (IServiceProvider provider) =>
        //     {
        //         var b2 = new ClassB2(
        //             provider.GetService<IClassC>() ?? new ClassC(),
        //             "Thực hiện trong ClassB2"
        //         );

        //         return b2;
        //     }
        // );

        // Sử dụng Factory
        // services.AddSingleton<IClassB>(CreateB2);
        // Hoặc có thể viết gọn là:
        services.AddSingleton(CreateB2);

        services.AddSingleton<IClassC, ClassC1>();

        var provider = services.BuildServiceProvider();

        var a = provider.GetService<ClassA>();
        a?.ActionA();
    }
}