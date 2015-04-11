using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ByteHunter
{
    public class EnemyBullet : Projectile
    {
        Vector2 playerPosition;
        public float timeActive = 0f;
        public EnemyBullet(Viewport Viewport, Texture2D Texture, Vector2 Position, float newRotation, float velocity)
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
        }

        public EnemyBullet(Viewport Viewport, Texture2D Texture, Vector2 Position, float newRotation, float velocity, patternType pattern)
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

        public EnemyBullet(Viewport Viewport, Texture2D Texture, Vector2 Position, float newRotation, float velocity, patternType pattern, Vector2 playerPosition)
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
            this.playerPosition = playerPosition;
        }

        public void Update()
        {
            timeActive += 1;
            if ((int)myPattern < (int)patternType.cosine && (int)myPattern > (int)patternType.randomDirection)
            {
                base.move();
            } else
                switch ((int)myPattern)
                {
                    case (int)patternType.toPlayer:
                        {
                            base.move(playerPosition);
                            break;
                        }
                    case (int)patternType.randomDirection:
                        {
                            base.move(new Vector2(ran.Next(500, 1000), Viewport.Height + 1));
                            break;
                        }
                    case (int)patternType.cosine:
                        {
                            base.cosMovement();
                            break;
                        }
                    case (int)patternType.sin:
                        {
                            base.sinMovement();
                            break;
                        }
                }
        }
    }
}