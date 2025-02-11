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

        private Interval intervalDamage { get; set; }

        private float durability = 1;

        public float Durability { get { return durability; } }

        public Weapon(string name)
        {
            this.Name = name;
            intervalDamage = new Interval(0,0);
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            intervalDamage = new Interval(minDamage, maxDamage);
        }

        public int GetDamage()
        {
            return (intervalDamage.Min + intervalDamage.Max) / 2;
        }
    }
}
