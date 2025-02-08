// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


internal class Program
{
    private class ListTask
    {
        private List<string> listOfStrings = new List<string>(); // Тип данных любой
                                            
        public void TaskLoop()
        {
            listOfStrings.Add("Строка 1");
            listOfStrings.Add("Строка 2");
            string string1 = string.Empty;
            bool mode = true;
            do
            {
                if (!string1.Equals(string.Empty))
                {
                    if (mode) 
                    {
                        listOfStrings.Add(string1);
                    }
                    else
                    {
                        listOfStrings.Insert(Convert.ToInt32(listOfStrings.Count / 2), string1);                        
                    }
                    mode = !mode;
                    WriteList();
                }

                Console.WriteLine("Enter the string, or –exit:");
                string1 = Console.ReadLine();

            } while (!string1.Equals("-exit"));
            
            Console.WriteLine("You're out");            
            
        }

        private void WriteList()
        {
            Console.WriteLine("List:");
            for (int i = 0; i < listOfStrings.Count; i++)
            {
                Console.WriteLine(listOfStrings[i]);
            }
        }
    }

    private class StudentsList
    {
        private Dictionary<string, int> ListDictionary = new Dictionary<string, int>();

        public void TaskLoop()
        {
            string string1 = string.Empty;
            do
            {
                Console.WriteLine("Enter student name, or –exit:");
                string1 = Console.ReadLine();
                if (!string1.Equals("-exit"))
                {
                    Console.WriteLine("Enter student's score, or –exit:");
                    bool result = int.TryParse(Console.ReadLine(), out var score);
                    if (result == true)
                    {
                        if (score >= 2 && 5 >= score)
                        {
                            if (ListDictionary.TryAdd(string1, score))
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.WriteLine("Fail");
                            }
                        }
                        else { Console.WriteLine("Wrong score"); }
                    }
                    else { Console.WriteLine("Wrong score"); }

                }

                WriteList();

                Console.WriteLine("Enter student name for search, or –exit:");
                string1 = Console.ReadLine();
                if (!string1.Equals("-exit"))
                {
                    if (ListDictionary.TryGetValue(string1, out int value))
                    {
                        Console.WriteLine($"Score = {value}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                }

            } while (!string1.Equals("-exit"));

            Console.WriteLine("You're out");

        }

        private void WriteList()
        {
            Console.WriteLine("List:");
            foreach (var kvp in ListDictionary)
            {
                Console.WriteLine("Student = {0} and score = {1}", kvp.Key, kvp.Value);
            }
        }
    }



    private class DoublyNodeList
    {
        private class DoublyNode
        {
            public string Value;

            public DoublyNode PreviousDoublyNode;
            public DoublyNode NextDoublyNode;

        }

        public void TaskLoop()
        {

            string string1 = string.Empty;
            DoublyNode FirstDoublyNode = null;
            DoublyNode LastDoublyNode = null;

            do
            {
                Console.WriteLine("Enter the string for add, -show for show, -xshow for reverse show, or –exit:");
                string1 = Console.ReadLine();
                if (!string1.Equals("-exit"))
                {
                    if (string1.Equals("-show"))
                    {
                        WriteList(FirstDoublyNode);
                    }
                    else if(string1.Equals("-xshow"))
                    {
                        xWriteList(LastDoublyNode);
                    }
                    else
                    {
                        var NewDoublyNode = new DoublyNode { Value = string1 };
                        if (FirstDoublyNode == null)
                        {
                            FirstDoublyNode = NewDoublyNode;
                        }
                        else
                        {                            
                            NewDoublyNode.PreviousDoublyNode = LastDoublyNode;
                            LastDoublyNode.NextDoublyNode = NewDoublyNode;
                        }                        
                        LastDoublyNode = NewDoublyNode;
                    }
                    
                }
            } while (!string1.Equals("-exit"));

            Console.WriteLine("You're out");

        }

        private void WriteList(DoublyNode doublyNode)
        {
            Console.WriteLine("List:");
            var next = doublyNode;
            while (next != null)
            {
                Console.WriteLine(next.Value);
                next = next.NextDoublyNode;
            }

        }

        private void xWriteList(DoublyNode doublyNode)
        {
            Console.WriteLine("List:");
            var next = doublyNode;
            while (next != null)
            {
                Console.WriteLine(next.Value);
                next = next.PreviousDoublyNode;
            }
        }
    }

        private static void Main(string[] args)
    {
        Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
        bool result = int.TryParse(Console.ReadLine(), out var task);
        if (result == true)
        {
            switch (task)
            {
                case 1:
                    CheckTaskFirst(); // Выполнение задания в отдельном методе
                    break;
                case 2:
                    CheckTaskSecond(); // Выполнение задания в отдельном методе
                    break;
                case 3:
                    CheckTaskThird(); // Выполнение задания в отдельном методе
                    break;
            }
        }
        else { Console.WriteLine("Wrong number"); }        
    }

    private static void CheckTaskFirst()
    {
       var listTask = new ListTask();
       listTask.TaskLoop();
    }

    private static void CheckTaskSecond()
    {
        var StudentsList = new StudentsList();
        StudentsList.TaskLoop();
    }

    private static void CheckTaskThird()
    {
        var doublyNodeList = new DoublyNodeList();
        doublyNodeList.TaskLoop();
    }
    
}

