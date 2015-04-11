using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpriteDemo
{
    class SpriteAnimation : SpriteManager
    {
        //Determines the amount of time that has gone by, important for when we want to change frames
        private float timeElapsed;
        //Does the animation loop?
        public bool IsLooping = false;
        //Stop the animation
        public bool stop = false;

        // default to 20 frames per second
        private float timeToUpdate = 0.05f;
        
        //Sets the value that the next frame shows, ie after 15 seconds, next frame
        public int FramesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }
        public Vector2 center;

        //Constructor that uses out 
        public SpriteAnimation(Texture2D Texture, int frames, int animations)
            : base(Texture, frames, animations)
        {
        }

        //Updates the frame based on GameTime
        public void Update(GameTime gameTime)
        {
            center = new Vector2(Position.X + (width / 2), Position.Y + (height / 2));
            //If the Animation isn't stopped
            if (!stop)
            {
                //Time elapsed is updated
                timeElapsed += (float)
                    gameTime.ElapsedGameTime.TotalSeconds;

                //If the time elapsed is greater than the time to update
                if (timeElapsed > timeToUpdate)
                {
                    //Reset timeElapsed
                    timeElapsed -= timeToUpdate;

                    //Move to the next frame
                    if (FrameIndex < Frames - 1)
                        FrameIndex++;
                    //If the animation doesn't loop, go to the initial frame
                    else if (IsLooping)
                        FrameIndex = 0;
                }
            }
            //If the Animation is stopped, stay at the initial frame
            else
            {
                FrameIndex = 0;
            }
        }

        //Stop the animation, goes to initial frame
        public void stopAnimation()
        {
            stop = true;
        }
        //Start the animation
        public void startAnimation()
        {
            stop = false;
        }
    }
}
