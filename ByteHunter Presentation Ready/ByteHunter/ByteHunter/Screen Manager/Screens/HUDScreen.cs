using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ByteHunter.Entity;
using Microsoft.Xna.Framework;

namespace ByteHunter.Screen_Manager.Screens
{
    class HUDScreen : Screen
    {
        struct HealthHUD
        {
            public Texture2D Texture;
            public Vector2 Position;
            public float Rotation;
            public float RotationSpeed;
        }

        Player Player;

        ContentManager content;
        SpriteBatch spriteBatch;
        Viewport viewport;

        Random random;

        Texture2D Border;

        HealthHUD[] healthHUD;
        byte rHealthColor;
        byte gHealthColor;
        byte bHealthColor;
        int healthSlices;

        public HUDScreen(Player Player)
        {
            this.Player = Player;
            healthSlices = 8;
            healthHUD = new HealthHUD[healthSlices];
            random = new Random();
        }

        public override void LoadContent()
        {
            viewport = ScreenManager.GraphicsDevice.Viewport;
            spriteBatch = ScreenManager.SpriteBatch;
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            for (int i = 0; i < healthSlices; i++)
            {
                healthHUD[i].Texture = content.Load<Texture2D>(string.Format("HUD/Health HUD {0}", i + 1));
                healthHUD[i].Position = Vector2.Zero;
                healthHUD[i].Rotation = 0.0f;
                healthHUD[i].RotationSpeed = (float)random.NextDouble() / 8;
            }
            Border = content.Load<Texture2D>("HUD/Borders");
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        public override void Update(GameTime gameTime, bool isActive, bool covered)
        {
            float percentHealth = (Player.Health / Player.maxHealth) * 100;
            healthToColor(percentHealth);
            for (int i = 0; i < healthSlices; i++)
            {
                healthHUD[i].Position = new Vector2(Player.Position.X - Player.Texture.Width / 1.5f,
                    Player.Position.Y - Player.Texture.Height / 1.5f);
                healthHUD[i].Rotation += healthHUD[i].RotationSpeed;
            }
        }

        private void healthToColor(float HealthPercentage)
        {
            if (HealthPercentage > 0)
            {
                float rPercent = 100 - HealthPercentage;
                float gPercent = HealthPercentage;
                rHealthColor = (byte)(255 * (rPercent / 100));
                gHealthColor = (byte)(255 * (gPercent / 100));
            }
            else
            {
                rHealthColor = 255;
                gHealthColor = 0;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (HealthHUD i in healthHUD)
            {
                spriteBatch.Draw(i.Texture, i.Position, i.Texture.Bounds,
                    new Color(rHealthColor, gHealthColor, bHealthColor), i.Rotation,
                    new Vector2(i.Texture.Width / 2, i.Texture.Height / 2), .10f, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(Border, viewport.Bounds, Color.White);
            spriteBatch.End();
        }
    }
}
