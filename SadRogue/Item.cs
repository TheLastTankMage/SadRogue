using System;
using Microsoft.Xna.Framework;

<<<<<<< HEAD
namespace SadRogue
{
    // Item: Describes this that can be picked up or used
    // by actors, or destroyed on the map.

=======
namespace SadRogue.Entities
{
    // Item: Describes things that can be picked up or used
    // by actors, or destroyed on the map.
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
    public class Item : SadConsole.Entities.Entity
    {
        private int _condition;

        public int Weight { get; set; } // mass of the item
<<<<<<< HEAD

        // Physical condition of item, in percent
        // 100 = Item undamaged
        // 0 = Item is destroyed
=======
        // physical condition of item, in percent
        // 100 = item undamaged
        // 0 = item is destroyed
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
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

<<<<<<< HEAD
        // By Default, a new item is sized 1x1, with a weight of 1, and a 100% condition
        public Item(Color foreground, Color background, string name, char glyph, int weight = 1, int condition = 100, int width = 1, int height = 1) : base(width, height)
        {
            // Assign the object's fields to the parameters set in the constructor
=======
        // By default, a new Item is sized 1x1, with a weight of 1, and at 100% condition
        public Item(Color foreground, Color background, string name, char glyph, int weight = 1, int condition = 100, int width = 1, int height = 1) : base(width, height)
        {
            // assign the object's fields to the parameters set in the constructor
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
            Weight = weight;
            Condition = condition;
            Name = name;
        }

        // Destroy this object by removing it from
        // the EntityManager's list of entities
<<<<<<< HEAD
        // and let the garbage collector take it
=======
        // and lets the garbage collector take it
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
        // out of memory automatically.
        public void Destroy()
        {
            GameLoop.EntityManager.Entities.Remove(this);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
