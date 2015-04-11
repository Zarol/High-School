using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpriteDemo
{
    class MouseComputations
    {
        public MouseComputations()
        {
        }
        public float getAngleRadian(Vector2 point1, Vector2 point2)
        {
            Vector2 direction = point2 - point1;
            return (float)(Math.Atan2(direction.Y, direction.X)); 
        }
        public float getAngleDegree(Vector2 point1, Vector2 point2)
        {
            Vector2 direction = point1 - point2;
            return ((float)(Math.Atan2(direction.Y, direction.X)) * (180/(float)Math.PI)) + 180;
        }
        /*
         * Angles must be in degrees
         */ 
        public string getFacingEight(float angle){
            float degreeAngle = angle; //* (180 / (float)Math.PI);
            if (degreeAngle > 360)
                degreeAngle -= 360;
            if (degreeAngle <= 22.5 || degreeAngle >=  337.5)
            {
                return "Right";
            }
            else if (degreeAngle >= 22.5 && degreeAngle <= 67.5)
            {
                return "DownRight";
            }
            else if (degreeAngle >= 67.5 && degreeAngle <= 112.5)
            {
                return "Down";
            }
            else if (degreeAngle >= 112.5 && degreeAngle <= 157.5)
            {
                return "DownLeft";
            }
            else if (degreeAngle >= 157.5 && degreeAngle <= 202.5)
            {
                return "Left";
            }
            else if (degreeAngle >= 202.5 && degreeAngle <= 247.5)
            {
                return "UpLeft";
            }
            else if (degreeAngle >= 247.5 && degreeAngle <= 292.5)
            {
                return "Up";
            }
            else if (degreeAngle >= 292.5 && degreeAngle <= 337.5)
            {
                return "UpRight";
            }
            else
            {
                //Error
                return "error";
            }
        }
    }
}
