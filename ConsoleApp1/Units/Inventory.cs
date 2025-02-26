using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using GamePrototype.Dungeon;
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
            string? line;
            int number;

            Console.WriteLine("(select the number to use or press q)");
            Console.WriteLine("Your inventory: ");            
            foreach (var item in _items)
            {
                
                Console.WriteLine($"{_items.IndexOf(item) + 1}. {item.Name} - {item.Amount}");
            }
            while (true)
            {
                line = Console.ReadLine();
                if (int.TryParse(line, out number) && number - 1 >= _items.Count)
                {
                    // Механика использвоания
                }
                else if (line != null && line.ToLowerInvariant().Equals("q"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong direction!");
                }
            }
        }
    }
}
