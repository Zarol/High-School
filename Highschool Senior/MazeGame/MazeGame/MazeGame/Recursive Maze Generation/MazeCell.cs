using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RecursiveMazeGeneration
{
    /**
     * Represents in cell within the grid
     * that contains walls that may be 
     * knocked down to form paths.
     */
    class MazeCell
    {
        private int walls;
        private int border;
        private int solution;
        private int backtrack;
        private Point location;
        private Point position;
        private int playerPosition;

        public MazeCell()
        {
            //West, South, East, North
            this.walls = 15;
            this.border = 0;
            this.solution = 0;
            this.backtrack = 0;
            this.location = new Point(0, 0);
            this.position = new Point(0, 0);
            this.playerPosition = 1;
        }

        public void setPlayer(int value)
        {
            //1 = hasn't been visited
            //2 = visited
            //4 = currently occupied
            this.playerPosition = value;
        }
        public int getPlayer()
        {
            return this.playerPosition;
        }
        public Point getCellLocation()
        {
            return this.location;
        }
        public void setCellLocation(Point location)
        {
            this.location = location;
        }
        public Point getPosition()
        {
            return position;
        }
        public void setPosition(Point position)
        {
            this.position = position;
        }
        public int getWalls()
        {
            return this.walls;
        }
        public void setWalls(int newVal)
        {
            this.walls -= newVal;
        }
        public int getBorder()
        {
            return this.border;
        }
        public void setBorder(int newVal)
        {
            this.border += newVal;
        }
        public int getSolution()
        {
            return this.solution;
        }
        public void setSolution(int newVal)
        {
            this.solution += newVal;
        }
        public int getBacktrack()
        {
            return this.backtrack;
        }
        public void setBacktrack(int newVal)
        {
            this.backtrack += newVal;
        }
        public Boolean allWallsIntact()
        {
            if (walls == 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
