using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
<<<<<<< HEAD
        public List<Item> Inventory = new List<Item>(); // The Player's collection of items
=======
        public List<Item> Inventory = new List<Item>(); // The player's collection of items
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14

        protected Actor(Color foreground, Color background, int glyph, int width=1, int height=1) : base(width, height)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        // Moves the Actor BY positionChange tiles in any X/Y direction
        // returns true if actor was able to move, false if failed to move
        public bool MoveBy(Point positionChange)
        {
            // Check the current map if we can move to this new position
            if (GameLoop.World.CurrentMap.IsTileWalkable(Position + positionChange))
            {
                Monster monster = GameLoop.EntityManager.GetEntityAt<Monster>(Position + positionChange);
                Item item = GameLoop.EntityManager.GetEntityAt<Item>(Position + positionChange);
<<<<<<< HEAD
=======

                // if there's a monster here,
                // do a bump attack
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
                if (monster != null)
                {
                    GameLoop.CommandManager.Attack(this, monster);
                    return true;
                }
<<<<<<< HEAD
                // if there is an item here,
=======
                // if there's an item here,
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
                // try to pick it up
                else if (item != null)
                {
                    GameLoop.CommandManager.Pickup(this, item);
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
