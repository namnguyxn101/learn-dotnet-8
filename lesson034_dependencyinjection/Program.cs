// Dependency - Phụ thuộc
// Inverse of Control (IoC) / Dependency Inverse
// Một trong những phương pháp áp dụng nguyên tắc IoC này --> Dependency Injection (DI)

using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

public class MyServiceOptions
{
    public string data1 { get; set; } = string.Empty;
    public int data2 { get; set; }
}

public class MyService
{
    public string data1 { get; set; } = string.Empty;
    public int data2 { get; set; }

    public MyService(IOptions<MyServiceOptions> options)
    {
        var _options = options.Value;
        data1 = _options.data1;
        data2 = _options.data2;
    }
    
    public void PrintData() => Console.WriteLine($"{data1} / {data2}");
}

class Program
{
    static void Main()
    {
        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        configBuilder.SetBasePath(Directory.GetCurrentDirectory());
        configBuilder.AddJsonFile("config.json");

        IConfigurationRoot configRoot = configBuilder.Build();

        var sectionMyServiceOptions = configRoot.GetSection("MyServiceOptions");

        // var data1 = configRoot
        //                 .GetSection("MyServiceOptions")
        //                 .GetSection("data1").Value;

        
        var services = new ServiceCollection();

        services.AddSingleton<MyService>();
        services.Configure<MyServiceOptions>(sectionMyServiceOptions);

        var provider = services.BuildServiceProvider();
        var myservice = provider.GetService<MyService>();

        myservice?.PrintData();
    }
}