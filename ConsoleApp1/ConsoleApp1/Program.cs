namespace ConsoleApp1
{
    public delegate void OnDamageReceivedDelegate<T>(T param) where T: Weapon;

    internal class Program
    {
        static void Main(string[] args)
        {
            var dummy = new DummyFirst(5);
            var sword = new Sword(10);
            var staff = new Staff(10);

            dummy.OnDamageReceived += (Weapon w) =>
            {
                Console.WriteLine("Was hit!");
                dummy.Health -= w.Damage;
            };

            dummy.OnDeath += () => Console.WriteLine("Dummy is dead");

            dummy.ReceinveDamage(staff);
            dummy.ReceinveDamage(sword);
        }
    }
}
