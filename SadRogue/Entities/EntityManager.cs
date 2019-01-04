using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace SadRogue.Entities
{
    // Manages a collection of Entities
    // using SadConsole's EntityManager
    // as well as provides extra functions
    // like searching for entities by type
    // and/or location
    public class EntityManager : SadConsole.Entities.EntityManager
    {
        // Empty Constructor
        public EntityManager()
        {

        }

        // Checking whether a certain type of entity
        // is at a specific location in the manager's list of entities
        // and if it exists, return that Entity
        public T GetEntityAt<T>(Point location) where T : SadConsole.Entities.Entity
        {
            return (T)Entities.FirstOrDefault(EntityManager => EntityManager is T && EntityManager.Position == location);
        }
    }
}
