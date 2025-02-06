using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dungeon
    {
        private Room[] Rooms;

        public Dungeon()
        {
            var interval = new Interval(1,10);            

            Rooms = new Room[] 
            {   new Room(new Unit("Unit1",1,10), new Weapon("Weapon1", interval.Get(), interval.Get())), 
                new Room(new Unit("Unit1",1,10), new Weapon("Weapon2", interval.Get(), interval.Get())),
                new Room(new Unit("Unit1",1,10), new Weapon("Weapon3", interval.Get(), interval.Get())) 
            };

        }

        public void ShowRooms()
        {
            for (int i = 0; i < Rooms.Length; i++) // поле типа Room[]
            {
                var room = Rooms[i]; // Берёте по индексу
                                     //Выводите на экран вот таким образом! Подробнее об этом в уроке про строки.
                Console.WriteLine("Unit of room" + room.Unit + " Damage: " + room.Unit.Damage);
                Console.WriteLine("Weapon of room" + room.Weapon + " GetDamage: " + room.Weapon.GetDamage());
                Console.WriteLine("—");
            }
        }
    }
}
