// See https://aka.ms/new-console-template for more information

using System.Xml;
using System.Xml.Serialization;

internal class Node
{
    public int Value;

    public Node NextNode;
}

internal class Program
{
    private static void Main(string[] args)
    {
        //Списки
        var list = new List<int>() {1,2,3,4,5};
        list.Add(-2);
        list.Remove(1);
        list.Reverse();

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        Console.WriteLine();

        //Связанный список
        var linkedList = new LinkedList<int>();

        //Связанный список через класс
        var node1 = new Node() { Value = 1 };
        var node2 = new Node() { Value = 2 };
        var node3 = new Node() { Value = 3 };

        node1.NextNode = node2;
        node2.NextNode = node3;

        var next = node1;
        while (next != null)
        {
            Console.WriteLine(next.Value);
            next = next.NextNode;
        }
    }

}