using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;

namespace GamePrototype.Units
{
    public abstract class Unit
    {
        private const int INVENTORY_SIZE = 3;
        private uint _health;
        private uint _maxHealth;
        protected uint BaseDamage;
        protected Inventory Inventory;
        
        public string Name { get; private set; }
        public uint Health
        {
            get => _health;
            protected set 
            {
                _health = value > _maxHealth ? _maxHealth : value;
            }
        }

        public uint MaxHealth => _maxHealth;

        protected Unit(string name, uint health, uint maxHealth, uint baseDamage) 
        {
            Name = name;
            _health = health;
            _maxHealth = maxHealth;
            BaseDamage = baseDamage;
            Inventory = new Inventory(INVENTORY_SIZE);
        }

        public void ApplyDamage(uint damage)
        {
            var damageApplied = CalculateAppliedDamage(damage);
            if (_health < damageApplied || (_health - damageApplied) <= 0) 
            {
                _health = 0;
            }
            else 
            {
                _health -= damageApplied;
            }
            
            DamageReceiveHandler();
        }

        protected abstract uint CalculateAppliedDamage(uint damage);
        
        protected virtual void DamageReceiveHandler() { }
        
        public abstract uint GetUnitDamage();

        protected virtual void DamageHandler(Weapon weapon) { }

        public abstract void HandleCombatComplete();

        public virtual void AddItemToInventory(Item item, bool start = false) 
        {
            if (!Inventory.TryAdd(item))
            {
                Console.WriteLine($"Inventory of {Name} is full");
            }
            else
            {
                if (!start)
                {
                    Console.WriteLine($"{Name} add to inventory {item.Name}");
                }                
            }

        }

        public void AddItemsFromUnitToInventory(Unit unit)
        {
            for (int i = 0; i < unit.Inventory.Items.Count; i++) 
            {
                AddItemToInventory(unit.Inventory.Items[i]);                
            }
        }

        public virtual void GoToInventory() { }
    }
}
