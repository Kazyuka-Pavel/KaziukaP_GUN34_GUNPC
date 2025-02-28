using System;
using System.Numerics;
using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;
using GamePrototype.Utils.DungeonBuilders;
using GamePrototype.Utils.UnitFactoryDemos;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        private DungeonBuilder _dungeonBuilder;
        private UnitFactoryDemo _unitFactoryDemo;

        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {            
            Console.WriteLine("Welcome, player!");
            GetDungeonMode();
            _dungeon = _dungeonBuilder.BuildDungeon(_unitFactoryDemo);
            Console.WriteLine("Enter your name");
            _player = _unitFactoryDemo.CreatePlayer(Console.ReadLine());
            Console.WriteLine($"Hello {_player.Name}");
        }

        private void GetDungeonMode()
        {
            while (true)
            {
                Console.WriteLine($"Enter dungeon mode: {(int)GameMode.Easy} - {GameMode.Easy}, {(int)GameMode.Hard} - {GameMode.Hard}");
                if (Enum.TryParse<GameMode>(Console.ReadLine(), out var gameMode))
                {
                    if(gameMode == GameMode.Easy)
                    {
                        _dungeonBuilder = new DungeonBuilderEasy();
                        _unitFactoryDemo = new UnitFactoryDemoEasy();
                        return;
                    }
                    else if (gameMode == GameMode.Hard)
                    {
                        _dungeonBuilder = new DungeonBuilderHard();
                        _unitFactoryDemo = new UnitFactoryDemoHard();
                        return;
                    }
                }                
            }                
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;

            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {                    
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction))
                    {
                        if (currentRoom.Rooms.ContainsKey(direction))
                        {
                            currentRoom = currentRoom.Rooms[direction];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong direction!");
                        }
                    }          
                    else
                    {                    
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                Console.WriteLine($"You have met {currentRoom.Enemy.Name}. The battle begins");
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
                
            }
        }

        
        #endregion
    }
}
