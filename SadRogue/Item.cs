using System;
using Microsoft.Xna.Framework;

namespace SadRogue
{
    // Item: Describes this that can be picked up or used
    // by actors, or destroyed on the map.

    public class Item : SadConsole.Entities.Entity
    {
        private int _condition;

        public int Weight { get; set; } // mass of the item

        // Physical condition of item, in percent
        // 100 = Item undamaged
        // 0 = Item is destroyed
        public int Condition
        {
            get { return _condition; }
            set
            {
                _condition += value;
                if (_condition <= 0)
                    Destroy();
            }
        }

        // By Default, a new item is sized 1x1, with a weight of 1, and a 100% condition
        public Item(Color foreground, Color background, string name, char glyph, int weight = 1, int condition = 100, int width = 1, int height = 1) : base(width, height)
        {
            // Assign the object's fields to the parameters set in the constructor
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
            Weight = weight;
            Condition = condition;
            Name = name;
        }

        // Destroy this object by removing it from
        // the EntityManager's list of entities
        // and let the garbage collector take it
        // out of memory automatically.
        public void Destroy()
        {
            GameLoop.EntityManager.Entities.Remove(this);
        }
    }
}
