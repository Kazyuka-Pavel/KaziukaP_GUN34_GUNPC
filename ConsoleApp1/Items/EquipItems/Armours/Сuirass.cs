using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems.Armours
{
    public sealed class Сuirass : Armour
    {
        public Сuirass(uint defence, uint durability, string name) : base(defence, durability, name) { }

        public override EquipSlot Slot => EquipSlot.Armour;
    }
}
