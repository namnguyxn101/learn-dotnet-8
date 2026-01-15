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

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();

        // Đăng ký các dịch vụ ...
        // IClassC, ClassC, ClassC1

        // // Singleton
        // services.AddSingleton<IClassC, ClassC1>();

        // var provider = services.BuildServiceProvider();

        // // var classc = provider.GetService<IClassC>();

        // for (int i = 0; i < 5; i++)
        // {
        //     IClassC? c = provider.GetService<IClassC>();
        //     Console.WriteLine(c?.GetHashCode());
        // }
        // ===================================

        // Transient
        // services.AddTransient<IClassC, ClassC>();

        // var provider = services.BuildServiceProvider();

        // for (int i = 0; i < 5; i++)
        // {
        //     IClassC? c = provider.GetService<IClassC>();
        //     Console.WriteLine(c?.GetHashCode());
        // }
        // ===================================

        // Scoped
        services.AddScoped<IClassC, ClassC>();

        var provider = services.BuildServiceProvider();

        for (int i = 0; i < 5; i++)
        {
            IClassC? c = provider.GetService<IClassC>();
            Console.WriteLine(c?.GetHashCode());
        }

        using (var scope = provider.CreateScope())
        {
            var provider1 = scope.ServiceProvider;

            for (int i = 0; i < 5; i++)
            {
                IClassC? c = provider1.GetService<IClassC>();
                Console.WriteLine(c?.GetHashCode());
            }
        }
    }
}