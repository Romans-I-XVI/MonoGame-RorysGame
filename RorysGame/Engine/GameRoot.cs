using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using RorysGame;

using System.Globalization;
using System.Threading;

namespace Engine
{
    public class GameRoot : Game
    {
        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;

        public static Color BackgroundColor = Color.WhiteSmoke;
        public static Vector2 VirtualSize { get { return new Vector2(960, 1600); } }
        public static GraphicsDevice graphicsDevice { get { return graphics.GraphicsDevice; } }
        public static GraphicsDeviceManager Graphics { get { return graphics; } }
        public static BoxingViewportAdapter BoxingViewport;
        public static bool ExitGame = false;

        public GameRoot()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
        }

        protected override void Initialize()
        {
            GameRoot.BoxingViewport = new BoxingViewportAdapter(Window, GraphicsDevice, (int)VirtualSize.X, (int)VirtualSize.Y, 0, 0);
            AccelerometerSensor.Start();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentHolder.Init(this);
            Room r;
            r = new Room_Main();
            r.Initialize();
            RoomManager.ChangeRoom<Room_Main>();
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            EntityManager.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || ExitGame)
                Exit();
        }

        protected override void Draw(GameTime gameTime)
        {
            EntityManager.DrawToRenderTargets(spriteBatch);
            graphics.GraphicsDevice.Clear(BackgroundColor);
            EntityManager.Draw(spriteBatch);
        }

        public static bool ToggleFullscreen()
        {
            graphics.ToggleFullScreen();
            BoxingViewport.Reset();
            return graphics.IsFullScreen;
        }

    }
}

namespace MonoGameTiles
{
    //This is because I don't want to change the engine Content Holder code yet
}
