// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

internal class Program
{
    static string[] _categories = {"Numbers", "Animals"};
    const string Value = "Const";

    public static string XorEncrypt(string input, string key)
    {
        char[] data = input.ToCharArray();
        char[] keyData = key.ToCharArray();
        char[] result = new char[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            result[i] = (char)(data[i] ^ keyData[i % keyData.Length]);
        }

        return new String(result);
    }

    public static string XorDecrypt(string input, string key)
    {
        // Дешифрование очень похоже на шифрование, поскольку XOR - это обратимая операция.
        return XorEncrypt(input, key);
    }

    private static void Main(string[] args)
    {
        // String 
        var myStr = "My String\n";
        var c = myStr.Insert(3,"First "); // вставить
        string[] a = myStr.Split(' '); // разбить 
        var b = myStr.Substring(6, 2); // вырезать
        Console.WriteLine(myStr);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(c + b);

        Console.WriteLine();

        // Char
        var d = 'f';
        
        Console.WriteLine(char.IsLetter(d));
        Console.WriteLine(char.GetNumericValue(d));

        Console.WriteLine();

        // Регулярные выражения
        var reg = "[a-z]";
        var rx = new Regex(reg);
        Console.WriteLine(rx.IsMatch("asd"));
        Console.WriteLine(rx.IsMatch("123"));

        Console.WriteLine();

        // StringBuilder
        var str1 = "Hello";
        var str2 = "World";
        var str3 = String.Empty;
        var builder = new StringBuilder();
        builder.Append(str1);
        builder.Append(' ');
        builder.Append(str2); 
        builder.Append(str3);
        Console.WriteLine(builder.ToString());

        Console.WriteLine();

        // 
        string originalText = "Привет, мир!";
        string key = "757f87f87343dffdf3g";
        string encryptedText = XorEncrypt(originalText, key);
        Console.WriteLine($"Зашифрованный текст: {encryptedText}");

        string decryptedText = XorDecrypt(encryptedText, key);
        Console.WriteLine($"Расшифрованный текст: {decryptedText}");

        // Викторина 
        var categories = new Dictionary<int, string>
        {
            {1, _categories[0]},
            {2, _categories[1]}
        };

        var categoryQuestions = new Dictionary<int, Dictionary<string, string>>();
        var questions = new Dictionary<string, string>() { { "PI?", "3.14" } };

        categoryQuestions.Add(1,questions);
        Console.WriteLine("Select categoty 1 or 2");
        var selected = int.Parse(Console.ReadLine());
        Console.WriteLine($"Your category {categories[selected]}");
        var result = categoryQuestions[selected];
        foreach (var category in result)
        {           
            Console.WriteLine(category.Key);
            int attempst = 0;
            while (true)
            {
                var answer = Console.ReadLine();
                attempst++;
                if (attempst >= 3 || answer  == category.Value )
                {
                    break;
                }
            }
            if( attempst <= 3)
            {
                Console.WriteLine("you won");
            }            
            break;
        }
        
    }
}