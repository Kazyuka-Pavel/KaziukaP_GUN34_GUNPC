namespace ConsoleApp1
{
    public delegate string ToStringConvert(Test param);

    public delegate float MathFloat(float param1, float param2);

    public class Test
    {
        public event MathFloat FloatCalculator;

        public Test(string someString) => SomeString = someString;

        private string SomeString { get; }

        public string Method(Test param) => param.ToString();

        public void Calculate(float param1, float param2)
        {
            if (FloatCalculator != null)
            {
                Console.WriteLine(FloatCalculator.Invoke(param1, param2));
            }
        }
        public override string ToString() => $"This is test class with string {SomeString}";
    }

    internal class Program
    {
        public static float Sum(float param1, float param2) => param1 + param2;

        public static float Mult(float param1, float param2) => param1 * param2;

        private class MathTest()
        {
            public static float Mult(float param1, float param2) => param1 * param2;
        }

        public static void MemoryLeakTest(MathTest math)
        {
            var newTest = new Test("df");
            newTest.FloatCalculator += Sum;
        }

        static void Main(string[] args)
        {
            var test = new Test("Netology");
            test.FloatCalculator += Sum;
            test.Calculate(10f,13.3f);

            //var del = new ToStringConvert(test.Method);
            //Console.WriteLine(del(test));
        }
    }
}
