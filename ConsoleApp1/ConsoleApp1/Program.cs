// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using System.Runtime.ExceptionServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var random = new Random();
        int[] player1 = new[] { random.Next(100), random.Next(100), random.Next(100), random.Next(100) };
        int[] player2 = new[] { random.Next(100), random.Next(100), random.Next(100), random.Next(100) };

        int player1Score = 0;
        int player2Score = 0;

        for (int i = 0; i < player1.Length; i++)
        {
            Console.WriteLine(player1[i] + " vs " + player2[i]);
            if (player1[i] > player2[i])
            {
                player1Score++;
            }
            else if (player1[i] < player2[i])
            {
                player2Score++;
            }
        }

        if (player1Score > player2Score)
        {
            Console.WriteLine("Player 1 won!");
        }
        else if (player1Score < player2Score)
        {
            Console.WriteLine("Player 2 won!");
        }
        else
        {
            Console.WriteLine("No winners!");
        }

    }

}