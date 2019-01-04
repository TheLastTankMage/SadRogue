using System;
using Microsoft.Xna.Framework;

namespace SadRogue.Entities
{
    public abstract class Actor : SadConsole.Entities.Entity
    {

        public int Health { get; set; } // Current Health
        public int MaxHealth { get; set; } // Maximum Health
        public int Attack { get; set; } // Attack Strength
        public int AttackChance { get; set; } // Hit Percentage
        public int Defense { get; set; } // Defensive Stength
        public int DefenseChance { get; set; } // Block Percentage
        public int Gold { get; set; } // Amount of gold carried

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
            // Check the map if this location is valid
            if (GameLoop.World.CurrentMap.IsTileWalkable(Position + positionChange))
            {
                // if there is a monster here
                // do a bump attack
                Monster monster = GameLoop.EntityManager.GetEntityAt<Monster>(Position + positionChange);
                if (monster != null)
                {
                    GameLoop.CommandManager.Attack(this, monster);
                    return true;
                }

                Position += positionChange;
                return true;
            }
            else
                return false;
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
