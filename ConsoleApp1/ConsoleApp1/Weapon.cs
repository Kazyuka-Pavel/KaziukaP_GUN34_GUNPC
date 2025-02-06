using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Weapon
    {
        public string Name { get; }

        private int MinDamage { get; set; }
        private int MaxDamage { get; set; }

        private float durability = 1;

        public float Durability { get { return durability; } }

        public Weapon(string name) => this.Name = name;

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                // меняем местами
                minDamage = minDamage + maxDamage;
                maxDamage = minDamage - maxDamage;
                minDamage = minDamage - maxDamage;
                Console.WriteLine("minDamage is more than maxDamage");
            }

            if (minDamage < 1)
            {
                minDamage = 1;
                Console.WriteLine("Forced setting of the minimum value of minDamage");
            }

            if (maxDamage <= 1)
            {
                minDamage = 10;
                Console.WriteLine("Forced setting of the minimum value of minDamage");
            }

            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }
    }
}
