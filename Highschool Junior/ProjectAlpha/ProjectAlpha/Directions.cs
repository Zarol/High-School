using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace ProjectAlpha
{
    public enum Direction
    {
        NorthEast,
        East,
        SouthEast,
        SouthWest,
        West,
        NorthWest,
        NumberOfDirections,
    }
    class Directions
    {
        public static Direction Rotate(Direction dir, int amt)
        {
            if (dir < Direction.NorthEast || dir > Direction.NorthWest || System.Math.Abs(amt) > (int)Direction.NumberOfDirections)
                throw new InvalidOperationException("Out of Range: Directions");
            dir += amt;
            int new_dir = (int)dir % (int)Direction.NumberOfDirections;
            if (new_dir < 0)
                new_dir = (int)Direction.NumberOfDirections + new_dir;
            dir = (Direction)new_dir;
            return dir;
        }
    }
}
