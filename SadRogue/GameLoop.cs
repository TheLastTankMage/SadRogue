using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SadRogue.UI;
using SadRogue.Commands;
using SadRogue.Entities;

namespace SadRogue
{
    class GameLoop
    {

        public const int GameWidth = 40;
        public const int GameHeight = 40;

        public static EntityManager EntityManager;
        public static UIManager UIManager;
        public static CommandManager CommandManager;
        public static World World;

        static void Main(string[] args)
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create("Cheepicus12.font", GameWidth, GameHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {

        }

        private static void Init()
        {
            // Instantiate the EntityManager
            EntityManager = new EntityManager();

            // Instantiate the UIManager
            UIManager = new UIManager();

            // Instantiate the CommandManager
            CommandManager = new CommandManager();

            // Build the World
            World = new World();

            // Now let the UIManager create its consoles
            // so they can use the World data
            UIManager.Init();
        }
    }
}
