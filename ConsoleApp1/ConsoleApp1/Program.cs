namespace ConsoleApp1
{
    public class Test
    {
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
        }
    }
}
