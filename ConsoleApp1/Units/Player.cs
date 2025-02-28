using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                DamageHandler(weapon);
                return BaseDamage + weapon.Damage;
            }            
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item, bool start = false)
        {
            if (item is EquipItem equipItem) 
            {
                if (EquipeItem(equipItem, start))
                { 
                    return; 
                };                
            }

            base.AddItemToInventory(item, start);            

            if (item is EconomicItem economicItem) 
            {
                UseEconomicItem(economicItem);
            }            
        }
        private bool EquipeItem(EquipItem equipItem, bool start)
        {
            if (_equipment.TryGetValue(equipItem.Slot,out var equipmentValue))
            {
                if (equipmentValue is Weapon weaponValue && equipItem is Weapon weaponItem)
                {
                    if(weaponValue.Damage > weaponItem.Damage)
                    {
                        _equipment.Remove(equipItem.Slot);
                        Console.WriteLine($"{weaponValue.Name} was thrown away");
                    }
                }
                else if (equipmentValue is Armour armourValue && equipItem is Armour armorItem)
                {
                    if (armourValue.Defence > armorItem.Defence)
                    {
                        _equipment.Remove(equipItem.Slot);
                        Console.WriteLine($"{armourValue.Name} was thrown away");
                    }
                }
                else Console.WriteLine("ERROR!");
            }
                        
            if (!_equipment.TryAdd(equipItem.Slot, equipItem))
            {
                return false;
            }            

            if (!start) 
            {
                Console.WriteLine($"{Name} equip item: {equipItem.Name}");
            }            
            return true;
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                if (Health < MaxHealth)
                {
                    var beforeHealth = Health;
                    Health += healthPotion.HealthRestore;
                    Console.WriteLine($"{Name} use: {healthPotion.Name} Health {beforeHealth} => {Health}");
                }                
            }
            if (economicItem is Grindstone grindstone)
            {
                EquipItem equipForRepair = null;
                foreach (var equip in _equipment)
                {
                    if (equip.Value is EquipItem weapon)
                    {
                        if (equipForRepair == null || equipForRepair.Durability > weapon.Durability)
                        {
                            equipForRepair = weapon;
                        }
                    }
                }
                if (equipForRepair != null)
                {
                    equipForRepair.Repair(grindstone.GrindRestore);
                    Console.WriteLine($"{Name} repair: {equipForRepair.Name}");
                };
            }
        }        

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }

        protected override void DamageReceiveHandler() //переопределил для Player для снижения прочности на -1
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armor)
            {
                item.ReduceDurability(GameConstants.DeltaDurArmor);
                Console.WriteLine($"{armor.Name} durability has been reduced, remains:{armor.Durability}");
            }       
        }

        protected override void DamageHandler(Weapon weapon) //переопределил для Player для снижения прочности на -1
        {
            weapon.ReduceDurability(GameConstants.DeltaDurArmor);
            Console.WriteLine($"{weapon.Name} durability has been reduced, remains:{weapon.Durability}");
        }
    }
}
