using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace ByteHunter.Screen_Manager.Screens
{

    /// <summary>
    /// A background screen that sits behind all other screens.
    /// It draws a background image regardless of other screens
    /// and transitions on top.
    /// </summary>
    class BackgroundScreen : Screen
    {
        struct Parallax
        {
            public Texture2D texture;
            public Vector2 position;
            public float speed;
        };
        SoundEffect Music;
        SoundEffectInstance MusicInstance;

        ContentManager content;
        SpriteBatch spriteBatch;
        Viewport viewport;

        Parallax[] background;
        Parallax[] background2;
        int bgSlices;
        Rectangle fullscreen;
        Random random;

        /// <summary>
        /// The constructor method for BackgroundScreen.
        /// </summary>
        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
            bgSlices = 69;
            background = new Parallax[bgSlices];
            background2 = new Parallax[bgSlices];
            random = new Random();
        }

        /// <summary>
        /// Loads the graphic content for this screen.
        /// This screen uses a local ContentManager.
        /// </summary>
        public override void LoadContent()
        {
            viewport = ScreenManager.GraphicsDevice.Viewport;
            fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);
            spriteBatch = ScreenManager.SpriteBatch;
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            Music = content.Load<SoundEffect>("Background");
            MusicInstance = Music.CreateInstance();
            MusicInstance.Volume = 0.8f;
            MusicInstance.IsLooped = true;
            MusicInstance.Play();

            int totalSize = 0;
            for (int i = 0; i < bgSlices; i++)
            {
                background[i].texture = content.Load<Texture2D>(string.Format("Main Menu/Background/Background_{0}", i + 1));
                background[i].position = new Vector2(totalSize, 0);
                background[i].speed = 1 + 8 * (float)random.NextDouble();

                background2[i].texture = content.Load<Texture2D>(string.Format("Main Menu/Background/Background_{0}", i + 1));
                background2[i].position = new Vector2(totalSize, -background2[i].texture.Height);
                background2[i].speed = background[i].speed;

                totalSize += background[i].texture.Width;
            }
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
            base.Update(gameTime, isActive, false);
            for (int i = 0; i < bgSlices; i++)
            {
                background[i].position += new Vector2(0, background[i].speed);
                background2[i].position += new Vector2(0, background2[i].speed);

                if (background[i].position.Y > background[i].texture.Height)
                {
                    background[i].position.Y = background2[i].position.Y - background[i].texture.Height;
                }
                if (background2[i].position.Y > background2[i].texture.Height)
                {
                    background2[i].position.Y = background[i].position.Y - background2[i].texture.Height;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Parallax parallax in background)
            {
                spriteBatch.Draw(parallax.texture, parallax.position, new Color(TransitionAlpha, TransitionAlpha, TransitionAlpha));
            }
            foreach (Parallax parallax in background2)
            {
                spriteBatch.Draw(parallax.texture, parallax.position, new Color(TransitionAlpha, TransitionAlpha, TransitionAlpha));
            }
            spriteBatch.End();
        }
    }
}
