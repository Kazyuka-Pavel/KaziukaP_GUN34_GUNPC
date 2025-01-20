// See https://aka.ms/new-console-template for more information

internal class Program
{
    private static void Main(string[] args)
    {
        if (int.TryParse(Console.ReadLine(), out int a))
        {
            // обработка
        }
        else
        {
            Console.WriteLine("Not a number!!!");
            return;
        }

        if (int.TryParse(Console.ReadLine(), out int b))
        {
            // обработка
        }
        else
        {
            Console.WriteLine("Not a number!!!");
            return;
        }

        uint c = (uint)a;

        Console.WriteLine("Enter &, | or ^:");

        var s = Console.ReadLine();
        if (s.Length == 0 || s.Length > 1)
        {
            Console.WriteLine("Wrong sign");
            return;
        }

        switch (s[0])
        {
            case '&':
                Console.WriteLine("Result of  {0} & {1} = {2}", a, b, a & b);
                Console.WriteLine("0b result of  {0} & {1} = {2}", Convert.ToString(a, 2), Convert.ToString(b, 2), Convert.ToString(a & b, 2));
                Console.WriteLine("0x Result of  {0} & {1} = {2}", Convert.ToString(a, 16), Convert.ToString(b, 16), Convert.ToString(a & b, 16));
                break;
            case '|':
                Console.WriteLine("Result of  {0} | {1} = {2}", a, b, a | b);
                Console.WriteLine("0b result of  {0} | {1} = {2}", Convert.ToString(a, 2), Convert.ToString(b, 2), Convert.ToString(a | b, 2));
                Console.WriteLine("0x Result of  {0} | {1} = {2}", Convert.ToString(a, 16), Convert.ToString(b, 16), Convert.ToString(a | b, 16));
                break;
            case '^':
                Console.WriteLine("Result of  {0} ^ {1} = {2}", a, b, a ^ b);
                Console.WriteLine("0b result of  {0} ^ {1} = {2}", Convert.ToString(a, 2), Convert.ToString(b, 2), Convert.ToString(a ^ b, 2));
                Console.WriteLine("0x Result of  {0} ^ {1} = {2}", Convert.ToString(a, 16), Convert.ToString(b, 16), Convert.ToString(a ^ b, 16));
                break;
            default:
                Console.WriteLine("Wrong sign");
                return;

        }
    }
}