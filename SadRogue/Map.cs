using System;
using Microsoft.Xna.Framework;

namespace SadRogue
{
    // Stores, Manipulates, and quires Tile data
    public class Map
    {
        private static TileBase[] _tiles; // contains all tile objects
        private int _width;
        private int _height;

        public TileBase[] Tiles { get { return _tiles; } set { _tiles = value; } }
        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }

        // Build a new map with a specified width and height
        public Map(int width, int height)
        {
            _width = width;
            _height = height;
            Tiles = new TileBase[width * height];

        }

        // Checks to see if a the player is trying to walk on to a non-walkable tile
        // Returns true is the tile is walkable
        // Returns false if the tile is not-walkable or outside the map
        public bool IsTileWalkable(Point location)
        {
            // Check to see if player is walking outside of the map
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
                return false;

            // Return if the tile is walkable
            return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        }
    }
}