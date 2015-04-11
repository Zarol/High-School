using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteDemo
{
    enum Tiles { Floor, Wall };
    class Caves
    {
        int sizeX, sizeY;
        int[,] grid;
        int wallProbablity;
        int neighbors;
        int generations;
        Random random;

        //Draw Variables
        protected Texture2D Texture;
        public Vector2 Position = Vector2.Zero;
        public Color Color = Color.White;
        public Vector2 Origin;
        public float Rotation = 0f;
        public float Scale = 1f;
        public SpriteEffects SpriteEffect;

        public Caves(Texture2D texture)
        {
            this.Texture = texture;
            random = new Random();
            sizeX = 200;
            sizeY = 200;
            wallProbablity = 45;
            grid = new int[sizeX, sizeY];
            //100000: Outliers start to appear; 200000: More Closed; 500000: More Open
            generations = 500000;
            neighbors = 4;
            generate();
            createBorders();
            //displayGrid();
        }
        public Caves(int sizeX,int sizeY,int wallProbablity,int neighbors, int generations)
        {
            random = new Random();
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.wallProbablity = wallProbablity;
            grid = new int[sizeX, sizeY];
            this.neighbors = neighbors;
            this.generations = generations;
            generate();
            createBorders();
            //displayGrid();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int xi = 0; xi < sizeX; xi++)
            {
                for (int yi = 0; yi < sizeY; yi++)
                {
                    if (grid[xi, yi] == (int)Tiles.Wall)
                    {
                        spriteBatch.Draw(Texture, new Vector2(xi * 128, yi * 84), Color.White);
                    }
                }
            }
        }
        public void createBorders()
        {
            for (int xi = 0; xi < sizeX; xi++)
            {
                grid[xi, 0] = (int)Tiles.Wall;
                grid[xi, sizeY - 1] = (int)Tiles.Wall;
            }
            for (int yi = 0; yi < sizeY; yi++)
            {
                grid[0, yi] = (int)Tiles.Wall;
                grid[sizeX - 1, yi] = (int)Tiles.Wall;
            }
        }
        public int examineNeighbors(int x, int y)
        {
            int count = 0;

            for (int xi = -1; xi < 2; xi++)
            {
                for (int yi = -1; yi < 2; yi++)
                {
                    if (checkCell(x + xi, y + yi) == true)
                        count += 1;
                }
            }

            return count;
        }
        public Boolean checkCell(int x, int y)
        {
            if (x >= 0 & x < sizeX & y >= 0 & y < sizeY)
            {
                if (grid[x, y] > (int)Tiles.Floor)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkCellOpen(int x, int y)
        {
            if (x >= 0 & x < sizeX & y >= 0 & y < sizeY)
            {
                if (grid[x, y] == (int)Tiles.Floor)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public void generate()
        {
            for (int xi = 0; xi < sizeX; xi++)
            {
                for (int yi = 0; yi < sizeY; yi++)
                {
                    if (random.Next(0, 100) < wallProbablity)
                    {
                        grid[xi, yi] = (int)Tiles.Wall;
                    }
                }
            }

            for (int ii = 0; ii <= generations; ii++)
            {
                int randX = random.Next(0, sizeX);
                int randY = random.Next(0, sizeY);
                if (examineNeighbors(randX, randY) > neighbors)
                {
                    grid[randX, randY] = (int)Tiles.Wall;
                }
                else
                {
                    grid[randX, randY] = (int)Tiles.Floor;
                }
            }
        }

        private void displayGrid()
        {
            for (int xi = 0; xi < sizeX; xi++)
            {
                System.Diagnostics.Debug.Write("|");
                for (int yi = 0; yi < sizeY; yi++)
                {
                    if (grid[xi, yi] == (int)Tiles.Wall)
                        System.Diagnostics.Debug.Write("#");
                    else
                        System.Diagnostics.Debug.Write(".");
                }
                System.Diagnostics.Debug.WriteLine("|");
            }
            System.Diagnostics.Debug.WriteLine(" ");
        }
    }
}
