namespace ConsoleApp1
{
    public delegate string ToStringConvert(Test param);

    public class Test
    {
        public Test(string someString) => SomeString = someString;

        private string SomeString { get; }

        public string Method(Test param) => param.ToString();

        public override string ToString() => $"This is test class with string {SomeString}";
    }

    internal class Program
    {
          

        static void Main(string[] args)
        {
            var test = new Test("Netology");
            var del = new ToStringConvert(test.Method);
            Console.WriteLine(del(test));
        }
    }
}
