using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpriteDemo
{
    /*
     * This is the Abstract Class that defines Frame Animation and Sprite Animation, it just
     * clearly sets a layout for both types of animation.
     */
    public abstract class SpriteManager
    {
        /*
         * The following variables are all based off SpriteBatch.Draw()
         * SpriteBatch.Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color,
         *                  float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
         */
        protected Texture2D Texture;
        public Vector2 Position = Vector2.Zero;
        public Color Color = Color.White;
        public Vector2 Origin;
        public float Rotation = 0f;
        public float Scale = 1f;
        public SpriteEffects SpriteEffect;

        /* Creates a new Dictonary, dictonaries work like arrays, but rather than containing numerical
         * indexes, the Indexes are strings that return numerical values.
         * 
         * The purpose of the dictionary is to easily sort animations in your sprite sheet.
         */
        protected Dictionary<string, Rectangle[]> Animations = 
            new Dictionary<string,Rectangle[]>();

        //The "spot" your animation is on, for our cases, the X value of your sprite sheet
        protected int FrameIndex = 0;
        //This goes with our dictionary that we created!
        public string Animation;
        //How many frames are in our sprite sheet? ie X value
        protected int Frames;

        public int height;
        public int width;

        //Our consturctor!! Takes in a Texture, the amount of frames (x) and the number of animations (y)
        public SpriteManager(Texture2D Texture, int Frames, int animations)
        {
            this.Texture = Texture;
            this.Frames = Frames;
            width = Texture.Width / Frames;
            height = Texture.Height / animations;
        }

        /*
         * This method simply labels each animation (on a per row basis) which each of its 
         * intended source Rectangles
         * 
         * It accepts a name, and it accepts the row in which the animation is on
         * 
         * Basically it cuts the sprite sheet into easily manageable frames!
         */
        public void AddAnimation(string name, int row)
        {
            Rectangle[] recs = new Rectangle[Frames];
            for (int i = 0; i < Frames; i++)
            {
                recs[i] = new Rectangle(i * width, 
                    (row - 1) * height, width, height);
            }
            Animations.Add(name, recs);
        }

        //Your general draw method that accepts a spriteBatch
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,
                Animations[Animation][FrameIndex],
                Color, Rotation, Origin, Scale, SpriteEffect, 0f);
        }
        public void setAnimation(string animation)
        {
            this.Animation = animation;
        }
    }
}
