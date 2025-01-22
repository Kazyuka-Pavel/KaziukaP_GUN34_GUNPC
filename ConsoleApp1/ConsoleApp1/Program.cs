// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;

internal class Program
{
    private static void Main(string[] args)
    {
        //int[] testArray = new[] { 1, 2, 3, };
        //Array.Sort(testArray, 0 , 3); // сортировка
        //Array.Reverse(testArray); //  наоборот        
        //var a = Array.Empty<int>(); // создание пустого массива
        //testArray.Length // длина
        int[] array1 = { 5546, 342, 4545 };
        float[] array2 = { 12.22, 34.56, 45.65 };

        var result = Array.CreateInstance(typeof(float), 4);
        result.SetValue(array1[0] * array2[0], 0);
        result.SetValue(array1[0] / array2[0], 1);

        Console.WriteLine(result.GetValue(0));
        Console.WriteLine(result.GetValue(1));

        Array.Sort(array2);

        Console.WriteLine(array2.Max());
        Console.WriteLine(array2.Min());
    }
}