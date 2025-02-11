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
            
            Rooms = new Room[] 
            {   new Room(new Unit("Unit1",9,0), new Weapon("Weapon1")), 
                new Room(new Unit("Unit1",-9,-9), new Weapon("Weapon2",-10,2)),
                new Room(new Unit("Unit1",0,0), new Weapon("Weapon3",1,15)) 
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
