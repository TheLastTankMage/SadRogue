using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SadRogue
{
    class GameLoop
    {

        public const int Width = 30;
        public const int Height = 30;
        private static Player player;

        // Room Building Variables
        private static TileBase[] _tiles; // an array of TileBase that contains all the tiles of the map
        private const int _roomWidth = 10; // demo Room Width
        private const int _roomHeight = 20; // demo Room Height

        static void Main(string[] args)
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create("Cheepicus12.font", Width, Height);

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
            // Called each logic update.
            CheckKeyboard();

        }

        private static void Init()
        {
            // Any custom loading and prep. We will use a sample console for now

            // Change Font and Resize
            //SadConsole.Global.FontDefault = SadConsole.Global.Fonts["Cheepicus12"].GetFont(Font.FontSizes.One);
            //SadConsole.Global.FontDefault.ResizeGraphicsDeviceManager(SadConsole.Global.GraphicsDeviceManager, Width, Height, 0, 0);
            //SadConsole.Global.ResetRendering();

            // Create Base Floor and Wall
            CreateWalls();
            CreateFloors();

            Console startingConsole = new Console(Width, Height, Global.FontDefault, new Rectangle(0, 0, Width, Height), _tiles);
            //startingConsole.FillWithRandomGarbage();
            //startingConsole.Fill(new Rectangle(1, 1, 28, 28), null, Color.Black, 0, SpriteEffects.None);

            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = startingConsole;

            // Create an instance of the player
            CreatePlayer();
            // Add player entity to the console
            startingConsole.Children.Add(player);
        }

        // Create a player using the Player class
        // and set its starting position
        private static void CreatePlayer()
        {
            player = new Player(Color.AliceBlue, Color.Transparent);
            player.Position = new Point(10, 20);
        }

        // Scans the SadConsole Global KeyboardState and triggers behavior
        // based on the button pressed.
        private static void CheckKeyboard()
        {
            // Toggles Fullscreen with F5
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Player Movement
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                player.Position += new Point(0, -1);
            }

            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                player.Position += new Point(0, 1);
            }

            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                player.Position += new Point(-1, 0);
            }

            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                player.Position += new Point(1, 0);
            }
        }

        private static void CreateFloors()
        {
            // Carve out a rectangle of floors in the tile array
            for (int x = 0; x < _roomWidth; x++)
            {
                for (int y = 0; y < _roomHeight; y++)
                {
                    // Calculates the appropreate position (index) in the array
                    // based on the y of tile, width of map, and x of tile
                    _tiles[y * Width + x] = new TileFloor();
                }
            }
        }

        private static void CreateWalls()
        {
            // Create an empty array of tiles that is equal to the map size
            _tiles = new TileBase[Width * Height];

            // Fill the entire tile array with floors
            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new TileWall();
            }
        }
    }
}
