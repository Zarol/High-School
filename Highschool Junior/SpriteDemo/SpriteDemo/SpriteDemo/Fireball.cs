using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpriteDemo
{
    class Fireball : SpriteAnimation
    {
        public float direction;
        public Vector2 velocity;
        public Fireball(Texture2D Texture, int frames, int animations, Vector2 createPosition)
            : base(Texture, frames, animations)
        {
            Scale = 1.5f;
            AddAnimation("Left", 1);
            AddAnimation("UpLeft", 2);
            AddAnimation("Up", 3);
            AddAnimation("UpRight", 4);
            AddAnimation("Right", 5);
            AddAnimation("DownRight", 6);
            AddAnimation("Down", 7);
            AddAnimation("DownLeft", 8);

            Animation = "Right";
            Position = createPosition;
            IsLooping = true;
            FramesPerSecond = 10;

            direction = 0;
            velocity = new Vector2(2.2f,2.2f);
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
