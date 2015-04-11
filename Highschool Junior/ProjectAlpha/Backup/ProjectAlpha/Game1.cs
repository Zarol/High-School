using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace ProjectAlpha
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera camera = new Camera(new Vector2(800, 480));

        private Vector2 drawOffset;

        Texture2D grassHex;

        private SpriteFont debugFont;
        private String debugString;

        KeyboardState keyboardState = new KeyboardState();
        MouseState mouseState = Mouse.GetState();
        Vector2 mouseLocation;
        Hex hex = new Hex(64);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            camera.offset = Vector2.Zero;

            drawOffset.X = -400;
            drawOffset.Y = -240;

            grassHex = Content.Load<Texture2D>("tex_GrassHex");

            debugFont = Content.Load<SpriteFont>("debugFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            mouseLocation.X = mouseState.X;
            mouseLocation.Y = mouseState.Y;
            Vector2 mousePosition = toWorldPosition(new Vector2(mouseState.X, mouseState.Y));
            //Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
            debugString = "";
            debugString += mousePosition.ToString();

            keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.W))
            {
                camera.offset.Y += 8;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                camera.offset.X += 8;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                camera.offset.Y -= 8;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                camera.offset.X -= 8;
            }

            debugString += hex.tileSelected(new Vector2(mouseLocation.X, mouseLocation.Y)).ToString();
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState, camera.View);
            drawHex();
            spriteBatch.End();
            spriteBatch.Begin();
                spriteBatch.DrawString(debugFont, debugString, Vector2.Zero, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void drawHex()
        {
            Vector2 worldLoc;
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    worldLoc = hex.worldOrigin(new Point(x,y));
                    spriteBatch.Draw(grassHex, new Rectangle((int)worldLoc.X, (int)worldLoc.Y, 128, 128), Color.White);
                }
            }
        }

        public Vector2 toWorldPosition(Vector2 vec)
        {
            vec.Y *= -1;
            vec += new Vector2(-400, 240);
            vec -= drawOffset;
            return vec;
        }
    }
}
