using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Dummy
    {
        public virtual event OnDamageReceivedDelegate<Weapon> OnDamageReceived;

        public event Action OnDeath;

        public int Health { get => _health; set 
            { 
                _health -= value;
                if (_health <= 0)
                {
                    OnDeath(); 
                }
            } 
        }

        private int _health;

        protected Dummy(int health)
        {
            Health = health;
        }

        public virtual void ReceinveDamage(Weapon weapon) => OnDamageReceived?.Invoke(weapon);
    }

    public class DummyFirst : Dummy
    {
        public override event OnDamageReceivedDelegate<Weapon> OnDamageReceived;

        public DummyFirst(int health) : base(health) { }  

        public override void ReceinveDamage(Weapon weapon)
        {
            if (weapon is Sword) 
            {
                base.ReceinveDamage(weapon);
            }
            else
            {
                Console.WriteLine("Hit wrong");
            }
        }
    }

    public class DummySecond : Dummy
    {
        public override event OnDamageReceivedDelegate<Weapon> OnDamageReceived;

        public DummySecond(int health) : base(health) { }

        public override void ReceinveDamage(Weapon weapon)
        {
            if (weapon is Staff)
            {
                base.ReceinveDamage(weapon);
            }
            else
            {
                Console.WriteLine("Hit wrong");
            }
        }   
    }
}
