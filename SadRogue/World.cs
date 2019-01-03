﻿using System;
using Microsoft.Xna.Framework;

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
    }
}
