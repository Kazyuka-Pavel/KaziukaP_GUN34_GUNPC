// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using System.Runtime.ExceptionServices;

internal class Program
{
    private static void Main(string[] args)
    {
        // Числа Фибоначчи
        var array1 = new int[10];
        array1[0] = 0;
        array1[1] = 1;
        int i = 2;
        Console.Write("1 .Числа Фибоначчи: ");
        while (i < array1.Length)
        {
            array1[i] = array1[i - 1] + array1[i - 2];
            Console.Write(array1[i] + " ");
            i++;
            //continue;
            //break;
        }

        Console.WriteLine();
        Console.WriteLine();

        //Все четные 
        Console.Write("2 .Все четные: ");
        i = 0;
        for (i = 0; i <= 20; i = i+2)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();
        Console.WriteLine();

        //Таблица умножения
        Console.Write("3 .Таблица умножения: ");
        Console.WriteLine();
        for (i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++) 
            {
                Console.Write(i * j + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        //Чтение пароля
        Console.Write("4 .Ввод пароля: ");
        Console.WriteLine();
        string password1 = "qwerty";
        string password2 = "";
        do
        {
            if (password2 != "")
            {
                Console.WriteLine("Неверный пароль! Попробуйте еще раз!");
            }
            Console.Write("Введите пароль: ");
            password2 = Console.ReadLine();

        } while (password1 != password2);
        Console.WriteLine("Верный пароль!");
    }

}