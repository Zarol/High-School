using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ByteHunter.Input_Manager;

namespace ByteHunter.Screen_Manager.Screens
{
    /// <summary>
    /// The Main Menu screen that will be the first
    /// thing that shows up and will allow acces to
    /// other parts of the game.
    /// </summary>
    class InstructionsScreen : Screen
    {

        ContentManager content;
        SpriteBatch spriteBatch;
        Viewport viewport;

        Texture2D Instructions;

        /// <summary>
        /// The constructor method for MainMenuScreen.
        /// </summary>
        public InstructionsScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(2);
            TransitionOffTime = TimeSpan.FromSeconds(0);
        }

        /// <summary>
        /// Loads the graphic content for this screen.
        /// This screen uses a local ContentManager.
        /// </summary>
        public override void LoadContent()
        {
            viewport = ScreenManager.GraphicsDevice.Viewport;
            spriteBatch = ScreenManager.SpriteBatch;
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            Instructions = content.Load<Texture2D>("Instructions/Full Instructions");
        }

        /// <summary>
        /// Unloads the graphics content for this screen.
        /// </summary>
        public override void UnloadContent()
        {
            content.Unload();   
        }

        public override void Update(GameTime gameTime, bool isActive, bool covered)
        {
            base.Update(gameTime, isActive, covered);
            if (Input.KeyboardEscapeJustPressed)
            {
                ScreenManager.AddScreen(new MainMenuScreen());
                ExitScreen();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw(Instructions, new Rectangle(0, 0, viewport.Width, viewport.Height), Color.White);
            ScreenManager.SpriteBatch.End();
        }
    }
}
