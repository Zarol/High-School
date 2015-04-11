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
    class MainMenuScreen : Screen
    {
        public struct Item
        {
            public Texture2D Static;
            public Texture2D Active;
            public Texture2D Drawn;
            public Rectangle Area;
            public Item(Texture2D Static, Texture2D Active)
            {
                this.Static = Static;
                this.Active = Active;
                this.Drawn = this.Static;
                Area = new Rectangle(0, 0, Drawn.Width, Drawn.Height);
            }
        }

        ContentManager content;
        SpriteBatch spriteBatch;
        Viewport viewport;

        Texture2D title;
        Item[] items;

        /// <summary>
        /// The constructor method for MainMenuScreen.
        /// </summary>
        public MainMenuScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(2);
            TransitionOffTime = TimeSpan.FromSeconds(0);

            items = new Item[4];
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
            title = content.Load<Texture2D>("Main Menu/Items/Byte Hunter");
            items[0] = (new Item(content.Load<Texture2D>("Main Menu/Items/Start Game"),
                content.Load<Texture2D>("Main Menu/Items/Start Game Active")));
            items[1] = (new Item(content.Load<Texture2D>("Main Menu/Items/Instructions"),
                content.Load<Texture2D>("Main Menu/Items/Instructions Active")));
            items[2] = (new Item(content.Load<Texture2D>("Main Menu/Items/Credits"),
                content.Load<Texture2D>("Main Menu/Items/Credits Active")));
            items[3] = (new Item(content.Load<Texture2D>("Main Menu/Items/Exit"),
                content.Load<Texture2D>("Main Menu/Items/Exit Active")));

            items[0].Area.X = (viewport.Width / 2) - (items[0].Area.Width / 2);
            items[0].Area.Y = 740;
            items[1].Area.X = (viewport.Width / 2) - (items[1].Area.Width / 2);
            items[1].Area.Y = 810;
            items[2].Area.X = (viewport.Width / 2) - (items[2].Area.Width / 2);
            items[2].Area.Y = 880;
            items[3].Area.X = (viewport.Width / 2) - (items[3].Area.Width / 2);
            items[3].Area.Y = 950;
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
            for (int i = 0; i < 4; i++)
            {
                if (items[i].Area.Intersects(new Rectangle(Input.MousePos.X, Input.MousePos.Y, 1, 1)))
                {
                    items[i].Drawn = items[i].Active;
                    if (Input.MouseLeftButtonJustPressed && i == 0)
                    {
                        ScreenManager.AddScreen(new GameScreen());
                        ExitScreen();
                    }
                    if (Input.MouseLeftButtonJustPressed && i == 1)
                    {
                        ScreenManager.AddScreen(new InstructionsScreen());
                        ExitScreen();
                    }
                    if (Input.MouseLeftButtonJustPressed && i == 3)
                    {
                        ScreenManager.Game.Exit();
                    }
                }
                else
                {
                    items[i].Drawn = items[i].Static;
                }
            }

        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw(title, new Vector2((viewport.Width / 2) - (title.Width / 2), 125), Color.White);

            ScreenManager.SpriteBatch.Draw(items[0].Drawn, items[0].Area, Color.White);
            ScreenManager.SpriteBatch.Draw(items[1].Drawn, items[1].Area, Color.White);
            ScreenManager.SpriteBatch.Draw(items[2].Drawn, items[2].Area, Color.White);
            ScreenManager.SpriteBatch.Draw(items[3].Drawn, items[3].Area, Color.White);
            ScreenManager.SpriteBatch.End();
        }
    }
}
