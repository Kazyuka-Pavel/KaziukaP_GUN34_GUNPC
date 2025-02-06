using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }
}
