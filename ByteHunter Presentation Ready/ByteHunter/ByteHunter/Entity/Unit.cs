using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ByteHunter.Entity
{
    public abstract class Unit
    {
        public Texture2D Texture;
        public float halfWidth;
        public float halfHeight;

        public Vector2 Position;
        public Vector2 Center;
        public float Velocity;


        public float Health;
        public Rectangle Hitbox;
        public bool isActive;

        public Viewport Viewport;

        //public abstract void Update(GameTime gameTime);

        public abstract void Move(float deltaTime);

        public abstract void Destroy();

        public abstract void Shoot(float deltaTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
