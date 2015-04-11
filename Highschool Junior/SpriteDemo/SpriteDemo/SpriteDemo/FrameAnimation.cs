using Microsoft.Xna.Framework.Graphics;

namespace SpriteDemo
{
    /*
     * This type of Animation works based off non looping animations, for instance, a sprite sheet
     * of a dice roll. If you roll a 4, you don't go through 1-3 to get to 4. This method simply works
     * by going to the selected frame, for most of your cases this is irrelevant, but its basically self
     * explanitory.
     */
    class FrameAnimation : SpriteManager
    {
        public FrameAnimation(Texture2D Texture, int frames, int animations)
            : base(Texture, frames, animations)
        {
        }

        public void SetFrame(int frame)
        {
            if (frame < Frames)
                FrameIndex = frame;
        }
    }
}
