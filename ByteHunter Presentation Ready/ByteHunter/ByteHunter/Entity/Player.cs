using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ByteHunter.Input_Manager;

namespace ByteHunter.Entity
{
    public class Player : Unit
    {
        private static float fltDirection = (float)MathHelper.ToRadians(180);

        private Texture2D tex2DBulletTexture;

        private List<PlayerBullet> activeBullets = new List<PlayerBullet>();
        private int test = 0;
        private int bulletsFired = 0;

        public float maxHealth;

        float slowVelocity;
        float normalVelocity;
        Texture2D hitBoxTexture;
        Rectangle hitBoxRectangle;

        public Player(Texture2D Texture, Vector2 Position, float Velocity, float Health, bool isActive, Viewport Viewport, Texture2D bulletTexture, Texture2D hitBoxTexture)
        {
            this.Texture = Texture;
            halfHeight = Texture.Height / 2;
            halfWidth = Texture.Width / 2;
            this.Position = Position;
            this.Velocity = Velocity;
            this.Health = Health;
            maxHealth = Health;
            this.isActive = true;
            this.Viewport = Viewport;
            Center = new Vector2(Texture.Width / 2, Texture.Height / 2);
            normalVelocity = Velocity;
            slowVelocity = .4f;
            tex2DBulletTexture = bulletTexture;

            this.hitBoxTexture = hitBoxTexture;
            hitBoxRectangle = new Rectangle((int)Position.X + (Texture.Width / 3),
                                                            (int)Position.Y + (Texture.Height / 3),
                                                            Texture.Width / 3,
                                                            Texture.Height / 3);
        }

        public void Update(GameTime gameTime, ref List<Enemy> enemies)
        {
            float deltaTime = gameTime.ElapsedGameTime.Milliseconds;
            Move(deltaTime);
            for (int i = activeBullets.Count - 1; i >= 0; i-- )
            {
                test = AlignedAxisBoundingBoxCollision((PlayerBullet)activeBullets[i],(List<Enemy>)enemies);
                if (!(test == -1))
                {
                    enemies.RemoveAt(test);
                    activeBullets.RemoveAt(i);
                }
                else
                {
                    activeBullets[i].Update();
                }
            }
        }

        public override void Move(float deltaTime)
        {
            if (Input.Keyboard.IsKeyDown(Keys.LeftShift))
            {
                Velocity = slowVelocity;
            }
            else
            {
                Velocity = normalVelocity;
            }
            if (Input.KeyboardUpPressed)
            {
                Position.Y -= Velocity * deltaTime;
            }
            if (Input.KeyboardDownPressed)
            {
                Position.Y += Velocity * deltaTime;
            }
            if (Input.KeyboardLeftPressed)
            {
                Position.X -= Velocity * deltaTime;
            }
            if (Input.KeyboardRightPressed)
            {
                Position.X += Velocity * deltaTime;
            }
            if (Position.X + halfWidth > Viewport.Width)
                Position.X = Viewport.Width - halfWidth;
            if (Position.X - halfWidth < 0)
                Position.X = 0 + halfWidth;
            if (Position.Y + halfHeight > Viewport.Height)
                Position.Y = Viewport.Height - halfHeight;
            if (Position.Y - halfHeight < 0)
                Position.Y = 0 + halfHeight;
        }

        public override void Destroy()
        {
            if (Health <= 0)
            {
                isActive = false;
            }
        } // end of destroy method

        public override void Shoot(float deltaTime)
        {
            bulletsFired++;
            activeBullets.Add(new PlayerBullet(Viewport, tex2DBulletTexture,  
                new Vector2(Position.X, Position.Y - halfHeight), fltDirection, normalVelocity * deltaTime * 2, bulletsFired));
        } // end of shoot method

        public override void Draw(SpriteBatch spriteBatch)
        {
            bool outOfBounds = false;
            Vector2 position = Vector2.Zero;
            spriteBatch.Draw(Texture, Position, null, Color.White, 0.0f, Center, 1f, SpriteEffects.None, 0f);
            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                if ((activeBullets[i] is PlayerBullet))
                {
                    position = activeBullets[i].Position;
                    outOfBounds = (position.X < 0 || position.X > Viewport.Width) || (position.Y < 0 || position.Y > Viewport.Height);
                    if (outOfBounds)
                    {
                        activeBullets.RemoveAt(i);
                    } // end of nested if statement
                    else
                    {
                        activeBullets[i].Draw(spriteBatch);
                    } // end of nested-else statment
                } // end of if statement
                else
                {
                    activeBullets.RemoveAt(i);
                } // end of else statement
            }// end of for loop
            
            if (Input.Keyboard.IsKeyDown(Keys.LeftShift))
            {
                hitBoxRectangle = new Rectangle((int)(Position.X - (Texture.Width/2)) + (Texture.Width/3),
                                                            (int)(Position.Y - (Texture.Height / 2)) + (Texture.Height / 3),
                                                            Texture.Width / 3,
                                                            Texture.Height / 3);
                spriteBatch.Draw(hitBoxTexture,hitBoxRectangle, Color.White);

                /*
                 * float playerXMin = player.Position.X + (player.Texture.Width / 3);
                    float playerXMax = player.Position.X + ((2 * player.Texture.Width) / 3);
                    float playerYMin = player.Position.Y + (player.Texture.Height / 3);
                    float playerYMax = player.Position.Y + ((2 * player.Texture.Height) / 3);
                 */
            }
        }// end of draw method
        public int AlignedAxisBoundingBoxCollision(PlayerBullet bullet, List<Enemy> enemies)
        {
            Vector2 bulletOrigin = new Vector2(bullet.Position.X - (bullet.Texture.Width / 2),
                                               bullet.Position.Y - (bullet.Texture.Height / 2));

            float bulletXMin = bulletOrigin.X;
            float bulletXMax = bulletOrigin.X + bullet.Texture.Width;
            float bulletYMin = bulletOrigin.Y;
            float bulletYMax = bulletOrigin.Y + bullet.Texture.Height;

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                Vector2 enemyOrigin = new Vector2(enemies[i].Position.X - (enemies[i].Texture.Width / 2),
                                                  enemies[i].Position.Y - (enemies[i].Texture.Height / 2));

                float enemyXMin = enemyOrigin.X + (enemies[i].Texture.Width / 3);
                float enemyXMax = enemyOrigin.X + ((2 * enemies[i].Texture.Width) / 3);
                float enemyYMin = enemyOrigin.Y + (enemies[i].Texture.Height / 3);
                float enemyYMax = enemyOrigin.Y + ((2 * enemies[i].Texture.Height) / 3);

                bool betweenX = (bulletXMin >= enemyXMin && bulletXMin <= enemyXMax) || (bulletXMax >= enemyXMin && bulletXMax <= enemyXMax);
                bool betweenY = (bulletYMin >= enemyYMin && bulletYMin <= enemyYMax) || (bulletYMax >= enemyYMin && bulletYMax <= enemyYMax);

                if (betweenX && betweenY)
                {
                    return i;
                } // end of if statement
            }// End of for loop
            return -1;
        } // End of "AABBC" method
    } // End of Class
} // End of Namespace
