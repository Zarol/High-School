using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ByteHunter
{
    public class PlayerBullet : Projectile
    {
        int myBulletsFired;

        public PlayerBullet(Viewport Viewport, Texture2D Texture, Vector2 Position, float newRotation, float velocity, int bulletsFired)
        {
            base.Viewport = Viewport;
            this.Texture = Texture;
            this.Position = Position;
            Active = true;
            Damage = 10;
            vec2Velocity = new Vector2(velocity, velocity);
            fltRotation = newRotation;
            yMovement = ran.Next(50, 100);
            startingPosition = Position;
            myBulletsFired = bulletsFired;
        }

        public PlayerBullet(Viewport Viewport, Texture2D Texture, Vector2 Position, float newRotation, float velocity, patternType pattern)
        {
            this.Viewport = Viewport;
            this.Texture = Texture;
            this.Position = Position;
            Active = true;
            Damage = 10;
            vec2Velocity = new Vector2(4, 4);
            fltRotation = newRotation;
            yMovement = ran.Next(50, 100);
            startingPosition = Position;
            myPattern = pattern;
            Center = new Vector2(Texture.Width / 2, Texture.Width / 2);
        }

        public void Update()
        {
            base.move();
        }
    }
}
