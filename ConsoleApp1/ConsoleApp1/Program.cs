// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] testArray = new[] { 13, 72, 35, 45};

        var random = new Random();
        var value = random.Next(5);

        Console.WriteLine("Guess the number trom 1 to 5");

        int result = 0;
        do
        {
            if (!Int32.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Stop cheating!");
            }            
        } while (result != value);
        Console.WriteLine("You won!");
    }

}