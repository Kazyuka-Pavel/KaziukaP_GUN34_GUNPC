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

        Console.WriteLine();

        // Стэк
        // Послежний элемент выходит первым
        var stack = new Stack<int>();
        stack.Push(1); //Добавление в стэк
        stack.Push(2);
        stack.Push(3);

        while(stack.Count > 0)
        {
            Console.WriteLine(stack.Pop()); //Извлечение из стэка
        }

        Console.WriteLine();

        // Очередь 
        var queue = new Queue<float>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        while (queue.Count > 0 )
        {
            Console.WriteLine(queue.Dequeue());
        }

        Console.WriteLine();

        // Dictionary
        // Нет индексатора
        //var dictionary = new Dictionary<string, object>(); //string - тип ключа object - тип значения
        var dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "One");
        dictionary.Add(2, "Two");
        dictionary.Add(3, "Three");
        
        // Установка значения с првоеркой на уникальность ключа
        if (dictionary.TryAdd(3, "Three"))
        {
            Console.WriteLine("Success");
        }
        else
        {
            Console.WriteLine("Fail");
        }

        //Получаение значение с проверкой на уникальность ключа
        if (dictionary.TryGetValue(2, out string value))
        {
            Console.WriteLine($"{value}");
        }

        //Вывод значения по ключу
        Console.WriteLine(dictionary[1]);

        //Обход элементов словаря 
        foreach (var kvp in dictionary)
        {
            Console.WriteLine("key = {0} and value = {1}",kvp.Key,kvp.Value);
        }

        Console.WriteLine();

        //HashSet
        var hashSet = new HashSet<int>();
        hashSet.Add(0);
        hashSet.Add(1);

        foreach (var hash in hashSet)
        {
            Console.WriteLine(hash);
        }

        hashSet.Add(1); // тут может возникнуть исключение

        var xhashSet = new HashSet<Node>();
        var xnode1 = new Node() { Value = 5 };
        var xnode2 = new Node() { Value = 5 };
        xhashSet.Add(xnode1); //Т.к. это объект, то он добавляется по ХэщКоду
        xhashSet.Add(xnode2); //Т.к. это объект, то он добавляется по ХэщКоду
        foreach (var xhash in xhashSet)
        {
            Console.WriteLine(xhash.Value);
        }
    }

}