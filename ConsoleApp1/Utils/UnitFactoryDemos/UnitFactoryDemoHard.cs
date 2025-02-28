using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems.Armours;
using GamePrototype.Items.EquipItems.Weapons;
using GamePrototype.Units;

namespace GamePrototype.Utils.UnitFactoryDemos
{
    internal class UnitFactoryDemoHard : UnitFactoryDemo
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new MeleeWeapon(5, 15, "Sword 5"), true);
            player.AddItemToInventory(new Сuirass(5, 15, "Armour 5"), true);
            player.AddItemToInventory(new Helmet(2, 15, "Helmet 2"), true);
            player.AddItemToInventory(new HealthPotion("Potion"), true);
            return player;
        }

        public override Unit CreateGoblinEnemy()
        {
            var goblin = new Goblin(GameConstants.Goblin, 30, 30, 7);
            goblin.AddItemToInventory(new RangeWeapon(7, 15, "Bow 7"), true);
            goblin.AddItemToInventory(new Helmet(7, 15, "Helmet 7"), true);
            return goblin;
        }
    }
}
