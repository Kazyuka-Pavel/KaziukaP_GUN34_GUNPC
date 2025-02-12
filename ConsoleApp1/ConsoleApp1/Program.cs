// See https://aka.ms/new-console-template for more information

using System.Linq;
using System.Text;
using Xunit;

internal class Program
{
    private static string ConcatenateStrings(string st1, string st2)
    {
        var sb = new StringBuilder();
        sb.Append(st1);
        sb.Append(st2);
        return sb.ToString();
    }

    private static string GreetUser(string name, int age)
    {
        return $"Hello, {name}! \nYou are {age} years old!";
    }
    private static string GetLengthLowerUpperString(string st)
    {
        return $"Length: {st.Length}\nLower: {st.ToLower()}\nUpper: {st.ToUpper()}";
    }

    private static string GetSubstring(string st)
    {
        return st.Substring(0, Math.Min(st.Length, 5));       
    }

    private static StringBuilder GetStringBuilder(string[] st)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < st.Length; i++)
        {
            sb.Append(st[i]);
            if (i < st.Length - 1)
            {
                sb.Append(' ');
            }            
        }       
        return sb;
    }

    private static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
    {
        return inputString.Replace(wordToReplace, replacementWord);
    }

    private static void Main(string[] args)
    {
        var result = "";
        // 1.
        Console.WriteLine("1. Concatenate strings");
        result = ConcatenateStrings("Hello ", "Word");
        Console.WriteLine(result);
        Console.WriteLine($"Check: {"Hello Word".Equals(result)}");
        Console.WriteLine();

        // 2.
        Console.WriteLine("2. Method GreetUser");
        result = GreetUser("Vera", 5);
        Console.WriteLine(result);
        Console.WriteLine($"Check: {"Hello, Vera! \nYou are 5 years old!".Equals(result)}");
        Console.WriteLine();

        // 3.
        Console.WriteLine("3. Length Lower Upper");
        result = GetLengthLowerUpperString("Hello");
        Console.WriteLine(result);
        Console.WriteLine($"Check: {"Length: 5\nLower: hello\nUpper: HELLO".Equals(result)}");
        Console.WriteLine();

        // 4. 
        Console.WriteLine("4. Substring");
        result = GetSubstring("Hello world");
        Console.WriteLine(result);
        Console.WriteLine($"Check: {"Hello".Equals(result)}");
        result = GetSubstring("");
        Console.WriteLine(result);
        Console.WriteLine($"Check: {"Hello".Equals(result)}");
        Console.WriteLine();

        // 5. 
        Console.WriteLine("5. StringBuilder");
        string[] st3 = { "Starting", "to", "work"};
        result = GetStringBuilder(st3).ToString();
        Console.WriteLine(result);
        Console.WriteLine($"Check: {"Starting to work".Equals(result)}");
        Console.WriteLine();

        // 6.
        Console.WriteLine("6. ReplaceWords");
        result = ReplaceWords("Hello world", "world", "universe");
        Console.WriteLine(result);
        Console.WriteLine($"Check: { "Hello universe".Equals(result)}");
    }
}