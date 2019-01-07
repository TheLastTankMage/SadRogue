using System;
using Microsoft.Xna.Framework;

namespace SadRogue.Entities
{
    // A generic monster capable of
    // combat and interaction
    // yields treasure upon death
    public class Monster : Actor
    {
        public Monster(Color foreground, Color background) : base(foreground, background, 'M')
        {
            Random rndNum = new Random();

<<<<<<< HEAD
            // Number of Loot to spawn for a Monster
=======
            //number of loot to spawn for monster
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
            int lootNum = rndNum.Next(1, 4);

            for (int i = 0; i < lootNum; i++)
            {
<<<<<<< HEAD
                // Monsters Loot
                Item newLoot = new Item(Color.HotPink, Color.Transparent, "Rubbish", 'L', 2);
                Inventory.Add(newLoot);
            }

            int goldNum = rndNum.Next(1, 100);
            Gold = goldNum;
=======
                // monsters are made out of spork, obvs.
                Item newLoot = new Item(Color.HotPink, Color.Transparent, "spork", 'L', 2);
                Inventory.Add(newLoot);
            }
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
        }
    }
}
