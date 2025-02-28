using System.Numerics;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Items.EquipItems.Armours;
using GamePrototype.Items.EquipItems.Weapons;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class UnitFactoryDemo
    {
        public abstract Unit CreatePlayer(string name);

        public abstract Unit CreateGoblinEnemy();        
    }
}
