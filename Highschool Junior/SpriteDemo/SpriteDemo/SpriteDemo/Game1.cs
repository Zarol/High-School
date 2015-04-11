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
using System.Collections;

namespace SpriteDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Spearman spearMan;
		Fireball[] burst;
        List<Fireball> fireballProjectiles;
        //Creates a new SpriteAnimation called "eightDirection"
        SpriteFont spriteFont;
        MouseComputations mouseComputations;

        Caves rawr;

        KeyboardState kbState;
        MouseState mbState;
        Vector2 mouseLocation;

        Vector2 screenResolution;
        Camera camera;
        Point mouseLocationOffset;
        int scrollSpeed;
        float zoomSpeed;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            screenResolution = new Vector2(1280, 1024);
            camera = new Camera(screenResolution);
            mouseLocationOffset = new Point(0, 0);
            scrollSpeed = 16;
            zoomSpeed = .025f;
            graphics.PreferredBackBufferWidth = (int)screenResolution.X;
            graphics.PreferredBackBufferHeight = (int)screenResolution.Y;
            //graphics.IsFullScreen = true;
            camera.drawOffset = new Vector2(-4004, -2404);
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
			burst = new Fireball[12];
            fireballProjectiles = new List<Fireball>();
            mouseComputations = new MouseComputations();
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
            spriteFont = Content.Load<SpriteFont>("Default");
            //Creates a new SpriteAnimation, loads its sprite sheet, animations defined, rows defined
            spearMan = new Spearman(Content.Load<Texture2D>("actor1m"), 4, 8);
            rawr = new Caves(Content.Load<Texture2D>("128x84"));

            spearMan.Position = new Vector2(( screenResolution.X / 2), (screenResolution.Y / 2));
            camera.offset = Vector2.Zero;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            kbState = Keyboard.GetState();
            mbState = Mouse.GetState();

            // Allows the game to exit
            if (kbState.IsKeyDown(Keys.Escape))
                this.Exit();
            //if (mbState.LeftButton == ButtonState.Pressed)
            if (kbState.IsKeyDown(Keys.D1))
            {
                Fireball temp = new Fireball(Content.Load<Texture2D>("fireball_0"), 8, 8, Vector2.Zero);
                temp.Position = new Vector2(spearMan.center.X - (temp.width / 2), spearMan.center.Y - (temp.height / 2));
                temp.direction = mouseComputations.getAngleRadian(spearMan.center, mouseLocation);
                temp.animate(mouseComputations.getFacingEight(
                    mouseComputations.getAngleDegree(spearMan.center, mouseLocation)));
                fireballProjectiles.Add(temp);
            }
            for (int x = 0; x < fireballProjectiles.Count; x++)
            {
                fireballProjectiles[x].Position += new Vector2((float)(Math.Cos(fireballProjectiles[x].direction) * fireballProjectiles[x].velocity.X),
                (float)(Math.Sin(fireballProjectiles[x].direction) * fireballProjectiles[x].velocity.Y));
                fireballProjectiles[x].Update(gameTime);
            }

            spearMan.animate(mouseComputations.getFacingEight(
                mouseComputations.getAngleDegree(spearMan.center, mouseLocation)));
            /*
             * The following code merely changes animations based on key pressed and moves our sprite
             * It's pretty self explanatory, so good luck!
             */
            if (kbState.IsKeyDown(Keys.W) && kbState.IsKeyDown(Keys.A))
            {
                spearMan.move("UpLeft");
            }
            else if (kbState.IsKeyDown(Keys.W) && kbState.IsKeyDown(Keys.D))
            {
                spearMan.move("UpRight");
            }
            else if (kbState.IsKeyDown(Keys.S) && kbState.IsKeyDown(Keys.A))
            {
                spearMan.move("DownLeft");
            }
            else if (kbState.IsKeyDown(Keys.S) && kbState.IsKeyDown(Keys.D))
            {
                spearMan.move("DownRight");
            }
            else if (kbState.IsKeyDown(Keys.A))
            {
                spearMan.move("Left");
            }
            else if (kbState.IsKeyDown(Keys.D))
            {
                spearMan.move("Right");
            }
            else if (kbState.IsKeyDown(Keys.W))
            {
                spearMan.move("Up");
            }
            else if (kbState.IsKeyDown(Keys.S))
            {
                spearMan.move("Down");
            }
            else
            {
                spearMan.stopAnimation();
            }

            //Camera
            camera.zoom = 1 + ((float)mbState.ScrollWheelValue / 120 * zoomSpeed);
            if (kbState.IsKeyDown(Keys.W))
            {
                    camera.offset.Y += scrollSpeed;
                    mouseLocationOffset.Y -= scrollSpeed;
            }
            if (kbState.IsKeyDown(Keys.A))
            {
                    camera.offset.X += scrollSpeed;
                    mouseLocationOffset.X -= scrollSpeed;
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                    camera.offset.Y -= scrollSpeed;
                    mouseLocationOffset.Y += scrollSpeed;
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                    camera.offset.X -= scrollSpeed;
                    mouseLocationOffset.X += scrollSpeed;
            }
            mouseLocation.X = mbState.X + mouseLocationOffset.X;
            mouseLocation.Y = mbState.Y + mouseLocationOffset.Y;
            Vector2 mousePosition = camera.toWorldPosition(new Vector2(mouseLocation.X, mouseLocation.Y));

            //DON'T FORGET TO UPDATE!!!
            spearMan.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.getTransformationMatrix());
            //Remember, SpriteAnimation contains its own draw method, and passes in a spriteBatch, this is how we draw our sprite!
            rawr.Draw(spriteBatch);
            spearMan.Draw(spriteBatch);

            for (int x = 0; x < fireballProjectiles.Count; x++)
            {
                Fireball temp = fireballProjectiles[x];
                temp.Draw(spriteBatch);
            }


            spriteBatch.DrawString(spriteFont,
                ("" + mouseComputations.getAngleDegree(spearMan.center, new Vector2(mbState.X, mbState.Y))), 
                Vector2.Zero, Color.White);
            spriteBatch.DrawString(spriteFont,
                ("" + mouseComputations.getFacingEight(
                mouseComputations.getAngleDegree(spearMan.center, new Vector2(mbState.X, mbState.Y)))),
                new Vector2(0, 50), Color.White);
            spriteBatch.DrawString(spriteFont, ("" + fireballProjectiles.Count), new Vector2(0, 100), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
