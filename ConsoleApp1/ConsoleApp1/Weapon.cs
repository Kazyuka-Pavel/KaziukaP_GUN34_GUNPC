namespace ConsoleApp1
{
    public abstract class Weapon
    {
        public event OnDamageReceivedDelegate<Weapon> OnDamageReceived;

        public event Action OnDeath;

        public int Damage { get;  }

        protected Weapon(int damage)
        {
            Damage = damage;
        }
    }

    public class Sword : Weapon
    {
        public Sword(int damage) : base(damage) { }

    }

    public class Staff : Weapon
    {
        public Staff(int damage) : base(damage) { }

    }
}
