namespace NegroniGame.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public sealed class GameScreen : Microsoft.Xna.Framework.Game
    {
        #region Fields Declarations

        private readonly GraphicsDeviceManager graphics;
        // private GraphicsDevice device;

        private MouseState mouseState;

        private KeyboardState keyboardState;
        private Vector2 cursorPos = new Vector2();

        private List<Texture2D> monster1Textures;
        private List<Texture2D> monster2Textures;
        private List<Texture2D> monster3Textures;
        private List<Texture2D> monster4Textures;
        private List<Texture2D> monster5Textures;
        private List<Texture2D> monster6Textures;

        #endregion

        // Singleton !
        private static GameScreen instance;

        private GameScreen()
        {
            // Windows settings
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 700;
            graphics.ApplyChanges(); //Changes the settings that you just applied

            Content.RootDirectory = "Content";
        }

        public static GameScreen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameScreen();
                }
                return instance;
            }
        }

        #region Properties Declarations

        public SpriteBatch SpriteBatch { get; set; }
        public bool IsPaused { get; set; }
        public static int ScreenWidth { get; private set; }
        public static int ScreenHeight { get; private set; }
        public SpriteFont FontMessages { get; private set; }
        public SpriteFont FontInfoBox { get; private set; }
        public KeyboardState KeyboardStatePrevious { get; private set; }
        public List<List<Texture2D>> MonstersTextures { get; private set; }
        public List<Texture2D> AllSceneryTextures { get; private set; }
        public List<Texture2D> PlayerTextures { get; private set; }
        public List<Texture2D> SlotsTextures { get; private set; }
        public List<Texture2D> MajesticSetTextures { get; private set; }
        public List<Texture2D> NegroniHPTextures { get; private set; }
        public List<Texture2D> ShotsTextures { get; private set; }
        public List<Texture2D> DropTextures { get; private set; }
        public Texture2D NewbieStaffTexture { get; private set; }
        public Texture2D MysticStaffTexture { get; private set; }
        public Texture2D CoinsTexture { get; private set; }
        public Texture2D ElixirsTexture { get; private set; }
        public Texture2D CursorTexture { get; private set; }
        public Texture2D InfoBoxTexture { get; private set; }
        public Texture2D InfoBox1Texture { get; private set; }
        public Texture2D FireballsTexture { get; private set; }
        public Texture2D MarketDialog { get; private set; }
        public Texture2D BuyButton { get; private set; }

        #endregion

        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            // device = graphics.GraphicsDevice;

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            SystemFunctions.Sound.PlayIngameMusic();

            IsPaused = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            FontMessages = Content.Load<SpriteFont>("Segoe UI Mono");

            FontInfoBox = Content.Load<SpriteFont>("Segoe UI Mono Smaller");

            CursorTexture = Content.Load<Texture2D>("media/cursor1"); // cursor

            CoinsTexture = Content.Load<Texture2D>("media/drop/coins");

            ElixirsTexture = Content.Load<Texture2D>("media/drop/elixirs");

            NewbieStaffTexture = Content.Load<Texture2D>("media/drop/newbieStaff");

            MysticStaffTexture = Content.Load<Texture2D>("media/drop/mysticStaff");

            InfoBoxTexture = Content.Load<Texture2D>("media/infoBox");
            
            InfoBox1Texture = Content.Load<Texture2D>("media/infoBox1");

            MarketDialog = Content.Load<Texture2D>("media/marketDialog");

            BuyButton = Content.Load<Texture2D>("media/buy");

            // background, toolbar, well, playerPic, equipmentShop
            AllSceneryTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/background"),
                Content.Load<Texture2D>("media/toolbar"),
                Content.Load<Texture2D>("media/well"),
                Content.Load<Texture2D>("media/Elvina"),
                Content.Load<Texture2D>("media/market")
            };

            PlayerTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/Elvina-right"),
                Content.Load<Texture2D>("media/sprites/Elvina-left"),
                Content.Load<Texture2D>("media/sprites/Elvina-up"),
                Content.Load<Texture2D>("media/sprites/Elvina-down"),
            };

            MajesticSetTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/drop/majesticBoots"),
                Content.Load<Texture2D>("media/drop/majesticGloves"),
                Content.Load<Texture2D>("media/drop/majesticHelmet"),
                Content.Load<Texture2D>("media/drop/majesticRobe"),
                Content.Load<Texture2D>("media/drop/majesticShield")
            };

            monster1Textures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/monster1-right"),
                Content.Load<Texture2D>("media/sprites/monster1-left"),
                Content.Load<Texture2D>("media/sprites/monster1-up"),
                Content.Load<Texture2D>("media/sprites/monster1-down"),
            };

            monster2Textures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/monster2-right"),
                Content.Load<Texture2D>("media/sprites/monster2-left"),
                Content.Load<Texture2D>("media/sprites/monster2-up"),
                Content.Load<Texture2D>("media/sprites/monster2-down"),
            };

            monster3Textures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/monster3-right"),
                Content.Load<Texture2D>("media/sprites/monster3-left"),
                Content.Load<Texture2D>("media/sprites/monster3-up"),
                Content.Load<Texture2D>("media/sprites/monster3-down"),
            };

            monster4Textures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/monster4-right"),
                Content.Load<Texture2D>("media/sprites/monster4-left"),
                Content.Load<Texture2D>("media/sprites/monster4-up"),
                Content.Load<Texture2D>("media/sprites/monster4-down"),
            };

            monster5Textures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/monster5-right"),
                Content.Load<Texture2D>("media/sprites/monster5-left"),
                Content.Load<Texture2D>("media/sprites/monster5-up"),
                Content.Load<Texture2D>("media/sprites/monster5-down"),
            };

            monster6Textures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/monster6-right"),
                Content.Load<Texture2D>("media/sprites/monster6-left"),
                Content.Load<Texture2D>("media/sprites/monster6-up"),
                Content.Load<Texture2D>("media/sprites/monster6-down"),
            };

            MonstersTextures = new List<List<Texture2D>>()
            {
                monster1Textures,
                monster2Textures,
                monster3Textures,
                monster4Textures,
                monster5Textures,
                monster6Textures
            };

            SlotsTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/slots/defaultSlot1"),
                Content.Load<Texture2D>("media/slots/defaultSlot2"),
                Content.Load<Texture2D>("media/slots/defaultSlot3"),
                Content.Load<Texture2D>("media/slots/defaultSlot4"),
                Content.Load<Texture2D>("media/slots/defaultSlot5"),
                Content.Load<Texture2D>("media/slots/defaultSlot6"),
                Content.Load<Texture2D>("media/slots/defaultSlot7"),
                Content.Load<Texture2D>("media/slots/defaultSlot8"),
            };

            NegroniHPTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/negroniHPfull"),
                Content.Load<Texture2D>("media/negroniHP2of3"),
                Content.Load<Texture2D>("media/negroniHP1of3"),
                Content.Load<Texture2D>("media/negroniHPempty")
            };
            
            ShotsTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/sprites/fireballs")
            };

            DropTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("media/drop/coins2")
            };

            Player.Instance.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            // // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //this.Exit();

            cursorPos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y); // cursor update
            mouseState = Mouse.GetState();

            keyboardState = Keyboard.GetState();

            // Checks for pause
            if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.P)
                && KeyboardStatePrevious.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.P))
            {
                if (IsPaused == false)
                {
                    IsPaused = true;
                    SystemFunctions.Sound.StopIngameMusic();
                }
                else
                {
                    IsPaused = false;
                    SystemFunctions.Sound.PlayIngameMusic();
                }
            }

            if (IsPaused)
            {
                // Market.Instance.MarketDialog();
            }
            else
            {
                Player.Instance.Update(gameTime, keyboardState);

                Monsters.MonstersHandler.Instance.Update(gameTime);
                Scenery.Instance.Update(gameTime);
                Toolbar.InventorySlots.Instance.Update(gameTime, mouseState);
                ShotsHandler.Instance.UpdateShots(gameTime, keyboardState);
                Toolbar.SystemMsg.Instance.GetLastMessages();
                Toolbar.HP.Instance.Update(gameTime, mouseState);
                InfoBoxes.Instance.Update(gameTime, mouseState);

                // Player.Instance.UpdateInventory(gameTime);

                // updates elixir reuse time
                ElixirsHandler.Instance.Update(gameTime);
            }

            this.KeyboardStatePrevious = keyboardState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            Scenery.Instance.Draw(); // draws scenery

            Monsters.MonstersHandler.Instance.Draw(); // draws monsters

            ShotsHandler.Instance.Draw(); // draws shots

            Player.Instance.Draw(); // draws player

            Market.Instance.Draw(); // draws market + market dialog

            Toolbar.InventorySlots.Instance.Draw(); // draws inventory

            Toolbar.SystemMsg.Instance.DrawText(); // draws system messages

            Toolbar.HP.Instance.Draw(); // draws HP bar

            InfoBoxes.Instance.Draw(); // draws pop-up info boxes

            SpriteBatch.Draw(CursorTexture, cursorPos, Color.White); // draws cursor

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}