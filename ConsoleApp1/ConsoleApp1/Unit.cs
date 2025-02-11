using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Unit
    {
        public string Name { get; }

        private float health;
        public float Health { get { return health; } }

        private Interval damage;
        public int Damage { get { return damage.Get; } }
        
        private float armor = 0.6f;
        public float Armor { get { return armor; } }

        public Unit(string name) => this.Name = name;

        public Unit() : this("Unknown Unit")
        {}
        public Unit(string name, int mindamage, int maxdamage) : this(name)
        {            
            damage = new Interval(mindamage, maxdamage);      
        }

        public float GetRealHealth() 
        {
            return Health * (1f + Armor);
        }

        public bool SetDamage(float value) 
        {
            health = Health - (value * Armor);
            return (Health <= 0f);
        }
    }
}
