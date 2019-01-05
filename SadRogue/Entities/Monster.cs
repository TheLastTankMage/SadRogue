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

            // Number of Loot to spawn for a Monster
            int lootNum = rndNum.Next(1, 4);

            for (int i = 0; i < lootNum; i++)
            {
                // Monsters Loot
                Item newLoot = new Item(Color.HotPink, Color.Transparent, "Rubbish", 'L', 2);
                Inventory.Add(newLoot);
            }

            int goldNum = rndNum.Next(1, 100);
            Gold = goldNum;
        }
    }
}
