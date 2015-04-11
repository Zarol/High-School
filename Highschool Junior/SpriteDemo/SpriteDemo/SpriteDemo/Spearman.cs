using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpriteDemo
{
    class Spearman : SpriteAnimation
    {
        public Vector2 velocity;
        public Spearman(Texture2D Texture, int frames, int animations)
            : base(Texture, frames, animations)
        {
            AddAnimation("Down", 1);
            AddAnimation("Left", 2);
            AddAnimation("Right", 3);
            AddAnimation("Up", 4);
            AddAnimation("DownLeft", 5);
            AddAnimation("DownRight", 6);
            AddAnimation("UpLeft", 7);
            AddAnimation("UpRight", 8);
            Animation = "Down";
            Position = new Vector2(100, 100);
            IsLooping = true;
            FramesPerSecond = 7;
            velocity = new Vector2(16, 16);
        }
        public void move(string direction)
        {
            switch (direction)
            {
                case "Up": Position.Y -= velocity.Y; break;
                case "UpRight": Position.Y -= velocity.Y; Position.X += velocity.X; break;
                case "Right": Position.X += velocity.X; break;
                case "DownRight": Position.Y += velocity.Y; Position.X += velocity.X; break;
                case "Down": Position.Y += velocity.Y; break;
                case "DownLeft": Position.Y += velocity.Y; Position.X -= velocity.X; break;
                case "Left": Position.X -= velocity.X; break;
                case "UpLeft": Position.Y -= velocity.Y; Position.X -= velocity.X; break;
            }
        }

        public void animate(string facing)
        {
            startAnimation();
            switch (facing)
            {
                case "Up": setAnimation("Up"); break;
                case "UpRight": setAnimation("UpRight"); break;
                case "Right": setAnimation("Right"); break;
                case "DownRight": setAnimation("DownRight"); break;
                case "Down": setAnimation("Down"); break;
                case "DownLeft": setAnimation("DownLeft"); break;
                case "Left": setAnimation("Left"); break;
                case "UpLeft": setAnimation("UpLeft"); break;
                case "Stop": stopAnimation(); break;
            }
        }
    }
}
