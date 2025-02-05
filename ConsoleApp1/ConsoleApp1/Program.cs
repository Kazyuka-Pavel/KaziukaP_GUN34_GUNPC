// See https://aka.ms/new-console-template for more information

using System.Xml;
using System.Xml.Serialization;

internal class Test
{
    public float Fld1; 

    public Test(float fld1) => Fld1 = fld1;

    public void RefTest(int nonRef, ref int refParam)
    {
        nonRef++;
        refParam++;
    }

    public void OutTest(out int test)
    {
        test = default;
        test = 50;
    }
}

internal struct TestSt 
{
    public int Fld2;

    public TestSt() {  Fld2 = 999; }

    public TestSt(int fld2) { Fld2 = fld2; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        
        // Демонстрация ссылки класса

        var test1 = new Test(1f);
        var test2 = new Test(2f);

        Console.WriteLine(test1.Fld1);
        Console.WriteLine(test2.Fld1);

        var test3 = test1;
        test3.Fld1 = 3f; // изменится так же в тест1, т.к. в тест3 ссылка на тест1 (ref)

        Console.WriteLine(test1.Fld1);
        Console.WriteLine(test3.Fld1);
        Console.WriteLine();

        // Струкутры

        var TestSt1 = new TestSt();
        Console.WriteLine(TestSt1.Fld2);

        var TestSt2 = new TestSt(111);
        Console.WriteLine(TestSt2.Fld2);

        var TestSt3 = TestSt1; // здесь не передает ссылка, а копируется структура
        TestSt3.Fld2 = 222;
        Console.WriteLine(TestSt1.Fld2);
        Console.WriteLine(TestSt3.Fld2);

        // Массив

        var arrayOfClasses = new Test[10]; // массив ссылок
        var arrayOfStruct = new TestSt[10]; // упорядоченный массив, значения

        var array2OfClasses = new Test[] {new Test(10), new Test(15) }; // массив ссылок
        var array2OfStruct = new TestSt[] { new TestSt(10), new TestSt(15) }; // упорядоченный массив, значения

        //Тест рефа

        var test4 = new Test(3f);
        int var1 = 10;
        int var2 = 5;
        test4.RefTest(var1,ref var2);
        Console.WriteLine(var1);
        Console.WriteLine(var2); // параметр увеличился на 1, т.к. передался по ссылке и вернулся уже 6
        
        test4.OutTest(out int ret); // создание переменной на лету
        Console.WriteLine(ret);
    }

}