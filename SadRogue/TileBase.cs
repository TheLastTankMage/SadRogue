using System;
using Microsoft.Xna.Framework;
using SadConsole;

namespace SadRogue
{
    // TileBase is an abstract base class
    // representing the most basic form of all tiles used.
    // In other words, Static Tiles O__O

    public abstract class TileBase : Cell
    {

        // Movement and LOS Flags
        protected bool IsBlockingMove;
        protected bool IsBlockingLOS;

        // Tile's Name
        protected string Name;

        // Every TileBase has a Foreground Colour, Background Colour, and Glyph
        // IsBlockingMove and IsBlockingLOS are optional parameters, set to false by default
        // Base Constructor
        public TileBase(Color foreground, Color background, int glyph, bool blockingMove = false, bool blockingLOS = false, String name = "") : base(foreground, background, glyph)
        {
            IsBlockingMove = blockingMove;
            IsBlockingLOS = blockingLOS;
            Name = name;
        }
    }
}
