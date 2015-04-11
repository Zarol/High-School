using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProjectAlpha
{
    class Grid<T> where T : class, new()
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public int originX { get; private set; }
        public int originY { get; private set; }
        private T[,] Data;

        public T this[Point coord] { get { return this.getAt(coord); } }
        public T this[int x, int y] { get { return this.getAt(new Point(x, y)); } }

        public Grid(int width, int height, int originX, int originY)
        {
            this.width = width;
            this.height = height;
            Data = new T[width, height];
            this.originX = originX;
            this.originY = originY;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    Data[x,y] = new T();
        }

        public T getAt(Point coord)
        {
            coord.X -= originX;
            coord.Y -= originY;
            if (coord.X < 0 || coord.X >= width) 
                return null;
            if (coord.Y < 0 || coord.Y >= height) 
                return null;
            return Data[coord.X, coord.Y];
        }

        public bool inBound(Point coord)
        {
            coord.X -= originX;
            coord.Y -= originY;
            if (coord.X < 0 || coord.X >= width) 
                return false;
            if (coord.Y < 0 || coord.Y >= height) 
                return false;

            return true;
        }
    }
}
