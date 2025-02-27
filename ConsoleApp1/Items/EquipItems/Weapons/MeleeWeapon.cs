using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems.Weapons
{
    public sealed class MeleeWeapon : Weapon
    {
        public MeleeWeapon(uint damage, uint durability, string name) : base(damage, durability, name) { }
        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
