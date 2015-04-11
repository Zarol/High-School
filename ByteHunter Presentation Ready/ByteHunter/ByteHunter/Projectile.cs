using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace ByteHunter
{
    public abstract class Projectile
    {
        public Texture2D Texture;
        public Vector2 Position;
        protected bool Active;
        protected int Damage;
        protected Viewport Viewport;
        protected int Width { get { return Texture.Width; } }
        protected int Height { get { return Texture.Height; } }
        protected Vector2 Center;
        protected Vector2 vec2Velocity;
        protected float fltRotation;
        protected float fltTest = 0;
        protected Random ran = new Random();
        protected Vector2 startingPosition;
        protected float yMovement;
        protected patternType myPattern = 0;
    
        public void move()
        {
            defaultMovement();
        }

        public void move(Vector2 point)
        {
            setRotation(point);
            moveToPoint(point);
        }

        public void defaultMovement()
        {
            Position.Y -= (float)(-vec2Velocity.X * Math.Cos(fltRotation));
            Position.X += (float)(-vec2Velocity.Y * Math.Sin(fltRotation));

        }

        public void sinMovement()
        {
            fltTest += 100f; // .01745 is the value of 1 radian; save trouble of converting 1 degree to 1 radian on each call
            Position.Y -= (float)(-vec2Velocity.X * Math.Cos(fltRotation));
            Position.X = (startingPosition.Y) + (float)((Math.Sin(fltTest) * yMovement));
        }

        public void cosMovement()
        {
            fltTest += 100f; // .01745 is the value of 1 radian; save trouble of converting 1 degree to 1 radian on each call
            Position.Y -= (float)(-vec2Velocity.X * Math.Cos(fltRotation));
            Position.X += (startingPosition.Y) + (float)((Math.Cos(fltTest) * yMovement));
        }

        public void tanMovement()
        {
            fltTest += 100f; // .01745 is the value of 1 radian; save trouble of converting 1 degree to 1 radian on each call
            Position.Y -= (float)(-vec2Velocity.X * Math.Cos(fltRotation));
            Position.X = (startingPosition.Y) + (float)((Math.Tan(fltTest) * yMovement/10));
        }

        public void moveToPoint(Vector2 point)
        {
            if (Position == point)
            {
                Position = new Vector2(Viewport.Width + 100, Viewport.Height + 100);
            }
            else
            {
                if (Position.X < point.X)
                {
                    Position.X -= ((float)(-vec2Velocity.X * Math.Sin(fltRotation)));
                }
                else if (Position.X > point.X)
                {
                    Position.X += ((float)(-vec2Velocity.X * Math.Sin(fltRotation)));
                }

                if (Position.Y < point.Y)
                {
                    Position.Y -= ((float)(-vec2Velocity.X * Math.Cos(fltRotation)));
                }
                else if (Position.Y > point.Y)
                {
                    Position.Y += ((float)(-vec2Velocity.Y * Math.Cos(fltRotation)));
                }
            }

            
        }

        public void setRotation(Vector2 point)
        {
            Vector2 direction = Vector2.Zero;
            direction.X = point.X - (Position.X + Center.X);
            direction.Y = point.Y - (Position.Y + Center.Y);

            fltRotation = (float)Math.Atan2(direction.X, direction.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, fltRotation, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
