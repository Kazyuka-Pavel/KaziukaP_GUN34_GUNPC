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
        public int Min;
        public int Max;
        private Random rndm;

        public Interval(int min, int max)
        {
            Min = min; Max = max;
            rndm = new Random();
        }

        public int Get()
        {              
            return rndm.Next(Min, Max);
        }
    }
}
