using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProjectAlpha
{
    class Hex
    {
        public float radius { get; private set; }
        public float width { get; private set; }
        public float halfWidth { get; private set; }
        public float height { get; private set; }
        public float rowHeight { get; private set; }
        public float getRadius() { return radius; }

        public Hex(float radius)
        {
            this.radius = radius;
            this.height = 2 * radius;
            this.rowHeight = 1.5f * radius;
            this.halfWidth = (float)Math.Sqrt((radius * radius) - ((radius / 2) * (radius / 2)));
            this.width = 2 * this.halfWidth;
        }

        public Vector2 worldOrigin(Point gridLocation)
        {
            if (gridLocation.Y % 2 != 0)
                return new Vector2((float)((gridLocation.X * width) + halfWidth), (float)(gridLocation.Y * rowHeight));
            else
                return new Vector2((float)(gridLocation.X * width), (float)(gridLocation.Y * rowHeight));
        }
        public Vector2 worldCenter(Point gridLocation)
        {
            return worldOrigin(gridLocation) + new Vector2((float)halfWidth, (float)radius);
        }
        public Point gridNeighbor(Point gridLocation, Direction dir)
        {
            if (gridLocation.Y % 2 == 0) //even row
            {
                switch (dir)
                {
                    case Direction.NorthEast: gridLocation.Y += 1; break;
                    case Direction.East: gridLocation.X += 1; break;
                    case Direction.SouthEast: gridLocation.Y -= 1; break;
                    case Direction.SouthWest: gridLocation.Y -= 1; gridLocation.X -= 1; break;
                    case Direction.West: gridLocation.X -= 1; break;
                    case Direction.NorthWest: gridLocation.X -= 1; gridLocation.Y += 1; break;
                    default: throw new InvalidOperationException("Direction: Invalid");
                }
            }
            else //odd row
            {
                switch (dir)
                {
                    case Direction.NorthEast: gridLocation.X += 1; gridLocation.Y += 1; break;
                    case Direction.East: gridLocation.X += 1; break;
                    case Direction.SouthEast: gridLocation.X += 1; gridLocation.Y -= 1; break;
                    case Direction.SouthWest: gridLocation.Y -= 1; ; break;
                    case Direction.West: gridLocation.X -= 1; break;
                    case Direction.NorthWest: gridLocation.Y += 1; break;
                    default: throw new InvalidOperationException("Direction: Invalid");
                }
            }
            return gridLocation;
        }
        public Point tileSelected(Vector2 mouseClick)
        {
            double rise = height - rowHeight;
            double slope = rise / halfWidth;
            int x = (int)Math.Floor(mouseClick.X / width);
            int y = (int)Math.Floor(mouseClick.Y / rowHeight);

            double offsetX = mouseClick.X - x * width;
            double offsetY = mouseClick.Y - y * rowHeight;

            if (y % 2 == 0) //even row
            {
                //Type A
                if (offsetY < (-slope * offsetX + rise)) //Click is below left line, inside SouthWest neighbor
                {
                    x -= 1;
                    y -= 1;
                }
                else if (offsetY < (slope * offsetX - rise)) //Click is below right line, inside southEast neighbor
                {
                    y -= 1;
                }
            }
            else //odd row
            {
                //Type B
                if (offsetX >= halfWidth) //point on the right side?
                {
                    if (offsetY < (-slope * offsetX + rise * 2.0f)) //point below bottom line, inside SouthWest neighbor
                    {
                        y -= 1;
                    }
                }
                else //point is on the left
                {
                    if (offsetY < (slope * offsetX)) //point below bottom line, inside SouthWest neighbor
                    {
                        y -= 1;
                    }
                    else //point is above bottom line, inside West neighbor
                    {
                        x -= 1;
                    }
                }
            }
            return new Point(x, y);
        }
    }
}
