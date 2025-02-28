using System.Numerics;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Items.EquipItems.Armours;
using GamePrototype.Items.EquipItems.Weapons;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new MeleeWeapon(10, 15, "Sword 10"),true);
            player.AddItemToInventory(new Сuirass(10, 15, "Armour 10"), true);
            player.AddItemToInventory(new Helmet(5, 15, "Helmet 5"), true);            
            player.AddItemToInventory(new HealthPotion("Potion"), true);
            return player;
        }

        public static Unit CreateGoblinEnemy()
        {
            var goblin = new Goblin(GameConstants.Goblin, 18, 18, 2);
            goblin.AddItemToInventory(new RangeWeapon(10, 15, "Bow 10"), true);
            goblin.AddItemToInventory(new Helmet(10, 15, "Helmet 10"), true);
            return goblin;
        }
    }
}
