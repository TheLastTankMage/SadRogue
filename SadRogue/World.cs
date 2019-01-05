using System;
using Microsoft.Xna.Framework;
using SadRogue.Entities;

namespace SadRogue
{
    // All game state data is stored in World
    // also creates and processes generators
    // for map creation
    public class World
    {
        // map creation and storage data
        private int _mapWidth = 100;
        private int _mapHeight = 100;
        private TileBase[] _mapTiles;
        private int _maxRooms = 100;
        private int _minRoomSize = 4;
        private int _maxRoomSize = 15;
        public Map CurrentMap { get; set; }

        // player data
        public Player Player { get; set; }

        private Point pSpawn;

        // Creates a new game world and stores it in
        // publicly accessible
        public World()
        {
            // Build a map
            CreateMap();

            // create an instance of player
            CreatePlayer(pSpawn);

            // Spawn a set number of monsters
            CreateMonsters();

            // Spawn some loot
            CreateLoot();
        }

        // Create a new map using the Map class
        // and a map generator. Uses several 
        // parameters to determine geometry
        private void CreateMap()
        {
            _mapTiles = new TileBase[_mapWidth * _mapHeight];
            CurrentMap = new Map(_mapWidth, _mapHeight);
            MapGenerator mapGen = new MapGenerator();
            CurrentMap = mapGen.GenerateMap(_mapWidth, _mapHeight, _maxRooms, _minRoomSize, _maxRoomSize);
            pSpawn = mapGen.randSpawn;
        }

        // Create a player using the Player class
        // and set its starting position
        private void CreatePlayer(Point spawn)
        {
            Player = new Player(Color.Yellow, Color.Transparent);
            Player.Position = spawn;

            // add the player to the global EntityManager's collection of Entities
            GameLoop.EntityManager.Entities.Add(Player);
        }

        // Create some random monsters with random attack and defense values
        // and drop them all over the map in random locations.
        private void CreateMonsters()
        {
            // number of monsters to create
            int numMonsters = 10;

            // random position generator
            Random rndNum = new Random();

            // Create several monsters and
            // pick a random position on the map to place them.
            // Check if the placement spot is blocked
            // and if it is, try a new position
            for (int i=0; i < numMonsters; i++)
            {
                int monsterPosition = 0;
                Monster newMonster = new Monster(Color.Blue, Color.Transparent);
                while (CurrentMap.Tiles[monsterPosition].IsBlockingMove)
                {
                    // Pick a random spot on the map
                    monsterPosition = rndNum.Next(0, CurrentMap.Width * CurrentMap.Height);
                }

                // Plug in some magic numbers for attack and defense values
                newMonster.Defense = rndNum.Next(0, 10);
                newMonster.DefenseChance = rndNum.Next(0, 50);
                newMonster.Attack = rndNum.Next(0, 10);
                newMonster.AttackChance = rndNum.Next(0, 50);
                newMonster.Name = "a common punk";

                // Set the monster's new position
                // Note: This fancy math will be replace by a new helper method
                // in the next revision of SadConsole
                newMonster.Position = new Point(monsterPosition % CurrentMap.Width, monsterPosition / CurrentMap.Width);
                GameLoop.EntityManager.Entities.Add(newMonster);
            }
        }

        // Create some sample treasure
        // that can be picked up on the map
        private void CreateLoot()
        {
            // Number of treasure drops to create
            int numLoot = 20;

            Random rndNum = new Random();

            for (int i=0; i < numLoot; i++)
            {
                int lootPosition = 0;
                Item newLoot = new Item(Color.DeepPink, Color.Transparent, "Dapper Cap", 'L', 2);
                while (CurrentMap.Tiles[lootPosition].IsBlockingMove)
                {
                    // pick a random spot on map
                    lootPosition = rndNum.Next(0, CurrentMap.Width * CurrentMap.Height);
                }

                // Set the loot's new position
                newLoot.Position = new Point(lootPosition % CurrentMap.Width, lootPosition / CurrentMap.Width);
                GameLoop.EntityManager.Entities.Add(newLoot);
            }
        }
    }
}
