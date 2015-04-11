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
//CREATE BOUNDARIES FOR CAMERA
//ZOOM MIN / MAX
//ZOOM IN ON CENTER?
//REMEMBER: RADIUS CHANGES BASED ON ZOOM
//REMEMBER: BOUNDARIES CHANGED BASED ON ZOOM
//MOVE CAMERA METHOD
//WITH CAMERA: CHECK FIRST, IF OVER, ADD FULL AMOUNT - AMOUNT OVER, ELSE ADD FULL AMOUNT
namespace ProjectAlpha
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Vector2 screenResolution;
        Camera camera;
        Point mouseLocationOffset;
        int scrollSpeed;
        float zoomSpeed;
        int Ymax, Xmax;

        private Vector2 drawOffset;

        Texture2D grassHex;

        private SpriteFont debugFont;
        private String debugString;

        Hex hex;
        Point TileGridSize;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            screenResolution = new Vector2(1280, 1024);
            camera = new Camera(screenResolution);
            mouseLocationOffset = new Point(0, 0);
            scrollSpeed = 16;
            zoomSpeed = .025f;

            graphics.PreferredBackBufferWidth = (int)screenResolution.X;
            graphics.PreferredBackBufferHeight = (int)screenResolution.Y;
            graphics.IsFullScreen = true;

            IsMouseVisible = true;
            hex = new Hex(64);
            TileGridSize = new Point(100, 100);

            Ymax = (int)((-1 * TileGridSize.Y * hex.rowHeight) + (hex.rowHeight * 10) + (hex.radius / 2));
            Xmax = (int)((-1 * TileGridSize.X * hex.width) + (hex.width * 11)) + 5;
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
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            Vector2 mouseLocation;
            // TODO: Add your update logic here
            camera.zoom = 1 + ((float)mouseState.ScrollWheelValue / 120 * zoomSpeed);
            if (keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();       
            if (keyboardState.IsKeyDown(Keys.W))
            {
                if (camera.offset.Y < 0)
                {
                    camera.offset.Y += scrollSpeed;
                    mouseLocationOffset.Y -= scrollSpeed;
                }
                else
                {
                    camera.offset.Y = 0;
                }
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                if (camera.offset.X < 0)
                {
                    camera.offset.X += scrollSpeed;
                    mouseLocationOffset.X -= scrollSpeed;
                }
                else
                {
                    camera.offset.X = 0;
                }
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                if (camera.offset.Y > Ymax)
                {
                    camera.offset.Y -= scrollSpeed;
                    mouseLocationOffset.Y += scrollSpeed;
                }
                else
                {
                    camera.offset.Y = Ymax;
                }
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                if (camera.offset.X > Xmax)
                {
                    camera.offset.X -= scrollSpeed;
                    mouseLocationOffset.X += scrollSpeed;
                }
                else
                {
                    camera.offset.X = Xmax;
                }
            }
            mouseLocation.X = mouseState.X + mouseLocationOffset.X;
            mouseLocation.Y = mouseState.Y + mouseLocationOffset.Y;
            Vector2 mousePosition = toWorldPosition(new Vector2(mouseLocation.X, mouseLocation.Y));
            debugString = "";
            debugString += mouseLocation.ToString();
            debugString += hex.tileSelected(new Vector2(mouseLocation.X, mouseLocation.Y)).ToString();
            debugString += camera.zoom.ToString();
            
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
            //spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState, camera.View);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.getTransformationMatrix());
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
            for (int x = 0; x < TileGridSize.X; x++)
            {
                for (int y = 0; y < TileGridSize.Y; y++)
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
