using System;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Units
{
    public sealed class Inventory
    {
        private readonly uint _capacity;
        private readonly List<Item> _items = new List<Item>();
        public IReadOnlyList<Item> Items => _items;

        public Inventory(uint capacity) => _capacity = capacity;

        public bool TryAdd(Item item) 
        {
            if (_items.Count == _capacity) 
            {
                return false;
            }
            
            _items.Add(item);
            return true;
        }

        public bool TryRemove(Item item) 
        {
            if ( _items.Count == 0 || !_items.Contains(item)) 
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }

        public void ViewInventory()
        {
            Console.WriteLine("Your inventory: ");
            foreach (var item in _items)
            {
                
                Console.WriteLine($"{_items.IndexOf(item) + 1}. {item.Name} - {item.Amount}");
            }
        }
    }
}
