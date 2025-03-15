using System.Data.SqlTypes;

namespace ConsoleApp1
{
    public delegate void DelegateAndEvents<T>(T param) where T : struct; //органичение типа


    public class Test
    {
        public event DelegateAndEvents<int> Event;

        //public event DelegateAndEvents<object> Event2;

        public void ActionTest(Action action)
        {
            action?.Invoke(); // ? - спец оператор, который позволяет проверить ссылку на null, если есть ссылка, то выховет, в противном случае - нет
        }

        public void FuncTest(Func<int, int> func, int param) // в делегате первый всегда входной, а второй всегда возвращаемый
        {
            Console.WriteLine(func?.Invoke(param));
        }

        public void Predicatetest(Predicate<int> predicate, int param) 
        {
            if (predicate?.Invoke(param) == true)
            {
                Console.WriteLine("TRUE!");
            }
        }

        public void EventInvoker(int param)
        {
            if (param > 0)
            {
                Event.Invoke(param);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Делегат
            var test = new Test();
            test.ActionTest(delegate { Console.WriteLine("Action anonymous");  });
            test.ActionTest(() => Console.WriteLine("Action lambda"));

            test.FuncTest((int param) => param * 5, 25);

            // Предикат 
            var test1 = new Test();
            test1.Predicatetest((int param) => param > 5, 13);

            //Generics
            var test2 = new Test();
            test2.Event += (int param) => Console.WriteLine(param);
            test2.EventInvoker(-5);
            test2.EventInvoker(5);
        }
    }
}
