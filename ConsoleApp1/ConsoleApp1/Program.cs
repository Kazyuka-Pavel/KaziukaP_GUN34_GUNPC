// See https://aka.ms/new-console-template for more information


using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        Weapon Weapon1 = new Weapon("The dagger of immortality",10,100);
        Console.WriteLine(Weapon1.GetDamage());

    }

}