using System;
using Microsoft.Xna.Framework;

namespace SadRogue
{
    public abstract class Actor : SadConsole.Entities.Entity
    {
        private int _health; // current Health
        private int _maxHealth; // Max Health

        public int Health { get { return _health; } set { _health = value; }} // public getter for current health
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; }} // public setter for current health

        protected Actor(Color foreground, Color background, int glyph, int width=1, int height=1) : base(width, height)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        // move the Actor BY positionChange tiles in any X/Y direction
        // Returns true is actor was able to move, false if failed to move
        public bool MoveBy(Point positionChange)
        {
            Position += positionChange;
            return true;
        }

        // Moves the Actor TO newPosition location
        // Returns true if actor was able to move, false if failed to move
        public bool MoveTo(Point newPosition)
        {
            Position = newPosition;
            return true;
        }
    }
}
