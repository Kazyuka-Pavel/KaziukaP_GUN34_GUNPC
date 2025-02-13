// See https://aka.ms/new-console-template for more information

using System.Data.Common;



internal class Program
{
    public abstract class Animal
    {
        protected abstract string Name { get; init; }

        public Animal(string name) 
        {
            Name = name;
        }
        public abstract void Move();

        public abstract void MakeSound();        

    }

    public sealed class Cat : Animal
    {
        private readonly Random _random = new Random();

        protected override string Name { get; init; }

        public Cat(string name) : base(name) { }        

         public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} Myawww!");
        }

        public void Jump()
        {
            Console.WriteLine($"{Name} Jump!!!");
        }
    }

    public sealed class Dog : Animal
    {
        protected override string Name { get; init; }

        public Dog(string name) : base(name) { }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} Wooof!");
        }

    }

    private static void Main(string[] args)
    {

        var cat = new Cat("Barsil");
        WorkWithAnimal(cat);
        var dog = new Dog("Sharik");
        WorkWithAnimal(dog);
    }

    static void WorkWithAnimal(Animal animal)
    {
        animal.MakeSound();
        var dog = animal as Dog; // Попытка приведения animal к dog
        //var dog = (Dog)animal; - вызовет ошибку, хотя можно сделать такое преобразование
        if (dog == null)
        {
            if (animal is Cat cat) //Является ли абстаркция экземпляром класса Сat
            {
                cat.Jump();
            }
        }        
    }
}