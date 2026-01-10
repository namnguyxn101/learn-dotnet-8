using lesson014_inheritance;

class A { }
class B : A { }
class C : B { }

class Program
{
    static void Main()
    {
        Cat cat = new Cat("Mouse", 4);
        cat.ShowInfo();
        Animal cat2 = new Cat();
        cat2.ShowLegs();

        // A a = new A();
        // B b = new B();
        // C c = new C();
        // a = b;
        // a = c;
        // b = c;
    }
}