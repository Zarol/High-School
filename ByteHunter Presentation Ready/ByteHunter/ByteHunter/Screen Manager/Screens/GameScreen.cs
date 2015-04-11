using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteHunter.Entity;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ByteHunter.Wave_Manager;
using ByteHunter.Input_Manager;
using Microsoft.Xna.Framework.Audio;

namespace ByteHunter.Screen_Manager.Screens
{
    class GameScreen : Screen
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        Viewport viewport;

        Player Player;
        SoundEffect PlayerShoot;
        SoundEffectInstance PlayerShootInstance;

        WaveController WaveController;
        WaveController WaveController2;

        public List<EnemyBullet> activeBullets;
        public GameScreen()
        {
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

            PlayerShoot = content.Load<SoundEffect>("Entity/PlayerShoot");
            PlayerShootInstance = PlayerShoot.CreateInstance();
            PlayerShootInstance.Volume = .4f;

            Player = new Player(content.Load<Texture2D>("Entity/Player"), new Vector2(viewport.Width - 100, viewport.Height - 100),
                1, 50.0f, true, viewport, content.Load<Texture2D>("Entity/PlayerBullet"), content.Load<Texture2D>("PlayerHitBox"));
            WaveController = new WaveController(Player,
                content.Load<Texture2D>("Entity/Enemy1"), content.Load<Texture2D>("Entity/Enemy2"), content.Load<Texture2D>("Entity/Enemy3"),
                content.Load<Texture2D>("Entity/Enemy4"), content.Load<Texture2D>("Entity/Enemy5"),
                content.Load<Texture2D>("Entity/EnemyBullet"), viewport, 1000);
            WaveController2 = new WaveController(Player,
                content.Load<Texture2D>("Entity/Enemy1"), content.Load<Texture2D>("Entity/Enemy2"), content.Load<Texture2D>("Entity/Enemy3"),
                content.Load<Texture2D>("Entity/Enemy4"), content.Load<Texture2D>("Entity/Enemy5"),
                content.Load<Texture2D>("Entity/EnemyBullet"), viewport, 4002);

            activeBullets = new List<EnemyBullet>();
            ScreenManager.AddScreen(new HUDScreen(Player));
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
            if (Input.KeyboardEscapeJustPressed)
                ScreenManager.Game.Exit();

            if (Input.KeyboardSpacePressed)
            {
                Player.Shoot(gameTime.ElapsedGameTime.Milliseconds);
                PlayerShootInstance.Play();
            }

            WaveController.Update(gameTime);
            List<Enemy> enemies = WaveController.getEnemyList();
            List<Enemy> enemies2 = WaveController2.getEnemyList();
            enemies.AddRange(enemies2);
            
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                activeBullets.AddRange(enemies[i].Update(gameTime, ref Player));
            }
            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                if (AlignedAxisBoundingBoxCollision(activeBullets[i], Player))
                {
                    activeBullets.RemoveAt(i);
                    Player.Health -= 1;
                }
                else
                {
                    activeBullets[i].Update();
                }
            }

            Player.Update(gameTime, ref enemies);
            base.Update(gameTime, isActive, covered);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteFont spFont = content.Load<SpriteFont>("SpriteFont1") ;
            spriteBatch.Begin();
            WaveController.Draw(spriteBatch);
            WaveController2.Draw(spriteBatch);

            bool outOfBounds = false;
            Vector2 position = Vector2.Zero;

            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                position = activeBullets[i].Position;
                outOfBounds = (position.X < 0 || position.X > viewport.Width) || (position.Y < 0 || position.Y > viewport.Height);
                if (outOfBounds || (activeBullets[i].timeActive > 10*60))
                {
                    activeBullets.RemoveAt(i);
                }
                else
                {
                    activeBullets[i].Draw(spriteBatch);
                }
            }
            Player.Draw(spriteBatch);
            spriteBatch.End();
        }

        public bool AlignedAxisBoundingBoxCollision(EnemyBullet bullet, Player player)
        {
            Vector2 bulletOrigin = new Vector2(bullet.Position.X - (bullet.Texture.Width / 2),
                                               bullet.Position.Y - (bullet.Texture.Height / 2));

            Vector2 playerOrigin = new Vector2(player.Position.X - (player.Texture.Width / 2),
                                               player.Position.Y - (player.Texture.Height / 2));

            float bulletXMin = bulletOrigin.X;
            float bulletXMax = bulletOrigin.X + bullet.Texture.Width;
            float bulletYMin = bulletOrigin.Y;
            float bulletYMax = bulletOrigin.Y + bullet.Texture.Height;

            float playerXMin = playerOrigin.X + (player.Texture.Width / 3);
            float playerXMax = playerOrigin.X + ((2 * player.Texture.Width) / 3);
            float playerYMin = playerOrigin.Y + (player.Texture.Height / 3);
            float playerYMax = playerOrigin.Y + ((2 * player.Texture.Height) / 3);

            bool betweenX = (bulletXMin >= playerXMin && bulletXMin <= playerXMax) || (bulletXMax >= playerXMin && bulletXMax <= playerXMax);
            bool betweenY = (bulletYMin >= playerYMin && bulletYMin <= playerYMax) || (bulletYMax >= playerYMin && bulletYMax <= playerYMax);

            return (betweenX && betweenY);
        }
    }
}
