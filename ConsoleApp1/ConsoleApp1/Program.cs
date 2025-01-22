// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        // Числа Фибоначчи
        var array1 = Array.CreateInstance(typeof(int), 8);
        array1.SetValue(0, 0);
        array1.SetValue(1, 1);
        Console.Write("1 .Числа Фибоначчи: ");
        for (int i = 0; i < 8; i++)
        {
            if (i > 1) 
            {
                array1.SetValue((Convert.ToInt32(array1.GetValue(i - 1)) + Convert.ToInt32(array1.GetValue(i - 2))), i);
            }
            Console.Write(array1.GetValue(i) + " ");
        };
        Console.WriteLine();
        Console.WriteLine();

        // 12 месяцев
        string[] array2 = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        Console.Write("2. Месяца: ");
        for (int i = 0; i < array2.Length; i++) 
        {
            Console.Write(array2.GetValue(i) + " ");
        }
        Console.WriteLine();

        // Двумерный массив
        Console.WriteLine("3. Двумерный массив: ");
        double[,] array3 = new double[3, 3] {
                {Math.Pow(2,1), Math.Pow(3,1), Math.Pow(4,1)},
                {Math.Pow(2,2), Math.Pow(3,2), Math.Pow(4,2)},
                {Math.Pow(2,3), Math.Pow(3,3), Math.Pow(4,3)}
            };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(array3.GetValue(i, j) + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Ломанный массив:
        Console.WriteLine("4. Ломанный массив: ");
        double[][] array4 = new double[3][];
        array4[0] = new double[5] {1,2,3,4,5};
        array4[1] = new double[2] {Math.PI, Math.E};
        array4[2] = new double[4] {Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000) };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < array4[i].Length ; j++)
            {
                Console.Write(array4[i][j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        int[] array5 = { 1, 2, 3, 4, 5 }; 
        int[] array6 = { 7, 8, 9, 10, 11, 12, 13 };

        // Копирование массива:
        Console.WriteLine("5. Копирование массива: ");

        Array.Copy(array5, array6, 3);

        Console.Write("Array 1: ");
        for (int i = 0; i < array5.Length; i++)
        {
            Console.Write(array5.GetValue(i) + " ");
        }
        Console.WriteLine();

        Console.Write("Array 2: ");
        for (int i = 0; i < array6.Length; i++)
        {
            Console.Write(array6.GetValue(i) + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        // Изменение размера массива:
        Array.Resize(ref array5, array5.Length * 2);

        Console.WriteLine("6. Изменение размера массива: ");
        Console.Write("Array 1: ");
        for (int i = 0; i < array5.Length; i++)
        {
            Console.Write(array5.GetValue(i) + " ");
        }
        Console.WriteLine();

    }
}