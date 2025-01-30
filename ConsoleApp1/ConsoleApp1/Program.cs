// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using System.Xml;

class Test
{
    public int Field = 50;
    private float property;

    public float Property { get { return property; } set => property = value; }

    public void SomeMethod1(float number)
    {
        property = number;
    }

    public int SomeMethod2()
    {
        return 1;
    }

    public Test() { }

    public Test(int number) => Field = number;

    public Test(float number) 
    {
        property = number;
    } //конструктор по умолчанию 

}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello word!");   

        var object1 = new Test();
        var object2 = new Test(123);
        var object3 = new Test(123f);
        var object4 = new TestClass();

        Console.WriteLine(" object 1 field value = {0} and object 2 = {1}", object1.Field, object2.Field );
        Console.WriteLine(" object 1 Property value = {0} and object 2 = {1}", object1.Property, object2.Property);
        object1.SomeMethod1(10);
        var valSomeMethod1 = object1.SomeMethod2();
        Console.WriteLine(valSomeMethod1);
    }

}