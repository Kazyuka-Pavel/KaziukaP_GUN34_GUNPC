// See https://aka.ms/new-console-template for more information

using System.Xml;
using System.Xml.Serialization;

internal class Node
{
    public int Value;

    public Node NextNode;
}

internal class Unit
{
    public string Name { get; set; }

    public Dictionary<int, string> Abilities = new Dictionary<int, string>() 
    { 
        {1,"Fireball" },
        {2,"Thunderbolt" }
    };
}

internal class Order
{
    public int OrderValue;
}

internal class TaskUnit 
{
    public int Value;
    public void Redo() { Console.WriteLine("Redo " + Value); }
}


internal class Program
{
    private static void Main(string[] args)
    {
        // Примитивная игра 

        var army = new List<Unit>() { new Unit() { Name = "Orc"} , new Unit() { Name = "Elf" } };
        var order1 = new Order() { OrderValue = 1 };
        var order2 = new Order() { OrderValue = 2 };

        var task1 = new TaskUnit() { Value = 1 };
        var task2 = new TaskUnit() { Value = 2 };

        Console.WriteLine("My army");
        foreach(var unit in army)
        {
            Console.WriteLine(unit.Name);
            Console.WriteLine("1 - fireball, 2 - thunderbolt");
            var spell = int.Parse(Console.ReadLine());
            if (unit.Abilities.TryGetValue(spell, out var ability))
            {
                Console.WriteLine(ability);
            }
        }

        var orderQueue = new Queue<Order>();
        orderQueue.Enqueue(order1);
        orderQueue.Enqueue(order2);

        var stackTask = new Stack<TaskUnit>();
        stackTask.Push(task1);
        stackTask.Push(task2);

        while (orderQueue.Count > 0)
        {
            Console.WriteLine("Completed task = " + orderQueue.Dequeue().OrderValue);
        }

        Console.WriteLine("1 - cancel, 2 - continue");
        var result = int.Parse(Console.ReadLine());
        if (result == 1)
        { 
            stackTask.Pop().Redo();

        }
    }

}