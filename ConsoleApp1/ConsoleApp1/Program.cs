// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] testArray = new[] { 1, 2, 3, };
        int i = 0;

        while (i < testArray.Length)
        {
            Console.WriteLine(testArray[i]);
            i++;
            //continue;
            //break;
        }

        i = 0;
        do 
        {
            Console.WriteLine(testArray[i]);
            i++;
        } while (i < testArray.Length);

        int[] array = { 1, 2, 3, 4 };
        foreach (int number in array)
        {
            // code
            // Забивается память, лучше for
        }

        int[] array1 = { 1, 2, 3, 4 };
        for (int number = 0; number < array1.Length; number++)
        {
            // code
        }

        for (int number = array1.Length - 1; number >= 0; number--)
        {
            // code
        }
    }
}