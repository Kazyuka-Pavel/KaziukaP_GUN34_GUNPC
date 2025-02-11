using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal struct Interval
    {
        private Random rndm = new Random();
        public int Min { get; set; }
        public int Max { get; set; }
        public int Get { get { return rndm.Next(Min, Max); } }
        public Interval(int minValue, int maxValue)
        {
            // меньший станет первым аргументом
            rearrangeTheNumbers(ref minValue, ref maxValue);

            // если <0, тогда  0
            checkForNegativity(ref minValue, "minValue");
            checkForNegativity(ref maxValue, "maxValue");

            // если равны, то последнему +10
            checkequalnumbers(ref minValue, ref maxValue);

            Min = minValue;
            Max = maxValue;
        }

        private void rearrangeTheNumbers(ref int minValue, ref int maxValue)
        {
            if (minValue > maxValue)
            {                
                minValue = minValue + maxValue;
                maxValue = minValue - maxValue;
                minValue = minValue - maxValue;
                Console.WriteLine("minValue is more than maxValue");
            }
        }

        private void checkForNegativity(ref int Value, string Name)
        {
            if (Value < 0)
            {
                Value = 0;
                Console.WriteLine("{0} < 0",Name);
            }
        }

        private void checkequalnumbers(ref int minValue, ref int maxValue)
        {
            if(minValue >= maxValue)
            {
                maxValue +=10;
                Console.WriteLine("Forced setting of the maxValue +10");
            }
        }
    }
        
    
}
