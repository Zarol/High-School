using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RecursiveMazeGeneration
{
    //Full documentation upon request
    class MazeGrid
    {
        private MazeCell[,] grid; //Holds properties of a cell, such as walls
        private Point size;
        private int totalCells;
        private int visitedCells;
        private List<Point> listNeighborsWithWalls;
        private MazeCellStack cellStack; //Basic Stack
        private int cellLength;
        public MazeGrid()
        {
            this.size = new Point(400, 400);
            this.cellLength = 64;
            this.grid = new MazeCell[size.X, size.Y];
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    this.grid[x, y] = new MazeCell();
                    this.grid[x, y].setPosition(new Point(x * this.cellLength, (this.size.Y * this.cellLength) - (y * this.cellLength) - cellLength));
                    this.grid[x, y].setCellLocation(new Point(x, y));
                }
            }
            this.totalCells = this.size.X * this.size.Y;
            this.visitedCells = 0;
            this.listNeighborsWithWalls = new List<Point>();
            this.cellStack = new MazeCellStack();
        }
        public MazeGrid(Point size)
        {
            this.size = size;
            this.cellLength = 64;
            this.grid = new MazeCell[size.X, size.Y];
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    this.grid[x, y] = new MazeCell();
                    this.grid[x, y].setPosition(new Point(x * this.cellLength, (this.size.Y * this.cellLength) - (y * this.cellLength) - cellLength));
                    this.grid[x, y].setCellLocation(new Point(x, y));
                }
            }
            this.totalCells = this.size.X * this.size.Y;
            this.visitedCells = 0;
            this.listNeighborsWithWalls = new List<Point>();
            this.cellStack = new MazeCellStack();
        }
        public MazeGrid(int cellLength)
        {
            this.size = new Point(10, 10);
            this.cellLength = cellLength;
            this.grid = new MazeCell[size.X, size.Y];
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    this.grid[x, y] = new MazeCell();
                    this.grid[x, y].setPosition(new Point(x * this.cellLength, (this.size.Y * this.cellLength) - (y * this.cellLength) - cellLength));
                    this.grid[x, y].setCellLocation(new Point(x, y));
                }
            }
            this.totalCells = this.size.X * this.size.Y;
            this.visitedCells = 0;
            this.listNeighborsWithWalls = new List<Point>();
            this.cellStack = new MazeCellStack();
        }
        public MazeGrid(Point size, int cellLength)
        {
            this.size = size;
            this.cellLength = cellLength;
            this.grid = new MazeCell[size.X, size.Y];
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    this.grid[x, y] = new MazeCell();
                    this.grid[x, y].setPosition(new Point(x * this.cellLength, (this.size.Y * this.cellLength) - (y * this.cellLength) - cellLength));
                    this.grid[x, y].setCellLocation(new Point(x, y));
                }
            }
            this.totalCells = this.size.X * this.size.Y;
            this.visitedCells = 0;
            this.listNeighborsWithWalls = new List<Point>();
            this.cellStack = new MazeCellStack();
        }
        /*
         * create a CellStack (LIFO) to hold a list of cell locations
         * set TotalCells = number of cells in grid
         * choose a cell at random and call it CurrentCell
         * set VisitedCells = 1 
         * 
         * while VisitedCells < TotalCells
         *   find all neighbors of CurrentCell with all walls intact
         *   if one or more found
         *   choose one at random
         *   knock down the wall between it and CurrentCell
         *   push CurrentCell location on the CellStack
         *   make the new cell CurrentCell
         *   add 1 to VisitedCells
         * else
         *   pop the most recent cell entry off the CellStack
         *   make it CurrentCell endIf
         * endWhile
         */
        public void generate()
        {
            Random random = new Random();
            MazeCell currentCell = new MazeCell();
            MazeCell nextCell = new MazeCell();
            Point randomNextLocation = new Point();
            this.visitedCells = 1;
            int randomValue = 0;
            currentCell = this.grid[random.Next(size.X), random.Next(size.Y)];

            while (this.visitedCells < this.totalCells)
            {
                this.listNeighborsWithWalls = neighborsWithAllWalls(currentCell.getCellLocation());
                if (this.listNeighborsWithWalls.Count >= 1)
                {
                    if (this.listNeighborsWithWalls.Count == 1)
                    {
                        randomNextLocation = this.listNeighborsWithWalls[0];
                    }
                    else
                    {
                        randomValue = random.Next(this.listNeighborsWithWalls.Count);
                        randomNextLocation = this.listNeighborsWithWalls[randomValue];
                    }
                    nextCell = this.grid[randomNextLocation.X, randomNextLocation.Y];

                    switch (knockDownWalls(currentCell, nextCell))
                    {
                        case -1:
                            throw new Exception("Error in Knock Down Walls");
                        case 1: //WEST
                            this.grid[currentCell.getCellLocation().X, currentCell.getCellLocation().Y].setWalls(8);
                            this.grid[nextCell.getCellLocation().X, nextCell.getCellLocation().Y].setWalls(2);
                            break;
                        case 2: //SOUTH
                            this.grid[currentCell.getCellLocation().X, currentCell.getCellLocation().Y].setWalls(4);
                            this.grid[nextCell.getCellLocation().X, nextCell.getCellLocation().Y].setWalls(1);
                            break;
                        case 3: //EAST
                            this.grid[currentCell.getCellLocation().X, currentCell.getCellLocation().Y].setWalls(2);
                            this.grid[nextCell.getCellLocation().X, nextCell.getCellLocation().Y].setWalls(8);
                            break;
                        case 4: //NORTH
                            this.grid[currentCell.getCellLocation().X, currentCell.getCellLocation().Y].setWalls(1);
                            this.grid[nextCell.getCellLocation().X, nextCell.getCellLocation().Y].setWalls(4);
                            break;
                    }

                    cellStack.pushCell(currentCell);
                    currentCell = nextCell;
                    visitedCells++;
                }
                else
                {
                    currentCell = cellStack.popCell();
                }
            }

        }

        /*
         * West = 1, South = 2, East = 3, North = 4
         */
        private int knockDownWalls(MazeCell startingCell, MazeCell endingCell)
        {
            MazeCell startCell = startingCell;
            MazeCell endCell = endingCell;
            int differenceX = startingCell.getCellLocation().X - endingCell.getCellLocation().X;
            int differenceY = startingCell.getCellLocation().Y - endingCell.getCellLocation().Y;

            if (differenceX == 1 && differenceY == 0)
            {
                return 1; //return WEST (Relative to Starting)
            }
            else if (differenceX == 0 && differenceY == 1)
            {
                return 2; //return SOUTH (Relative to Starting)
            }
            else if (differenceX == -1 && differenceY == 0)
            {
                return 3; //Return EAST (Relative to Starting)
            }
            else if (differenceX == 0 && differenceY == -1)
            {
                return 4; //Return SOUTH (Relative to Starting)
            }
            else
            {
                throw new Exception("Cells aren't adjacent.");
            }
        }

        /*
         * West, South, East, North
         */
        private List<Point> neighborsWithAllWalls(Point currentLocation)
        {
            List<Point> listValidNeighbors = new List<Point>();
            try
            {
                //CHECK WEST
                if (this.grid[currentLocation.X - 1, currentLocation.Y].allWallsIntact() == true)
                {
                    listValidNeighbors.Add(this.grid[currentLocation.X - 1, currentLocation.Y].getCellLocation());
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                //Checked out of bounds
            }
            try
            {
                //CHECK SOUTH
                if (this.grid[currentLocation.X, currentLocation.Y - 1].allWallsIntact() == true)
                {
                    listValidNeighbors.Add(this.grid[currentLocation.X, currentLocation.Y - 1].getCellLocation());
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                //Checked out of bounds
            }
            try
            {
                //CHECK EAST
                if (this.grid[currentLocation.X + 1, currentLocation.Y].allWallsIntact() == true)
                {
                    listValidNeighbors.Add(this.grid[currentLocation.X + 1, currentLocation.Y].getCellLocation());
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                //Checked out of bounds
            }
            try
            {
                //CHECK NORTH
                if (this.grid[currentLocation.X, currentLocation.Y + 1].allWallsIntact() == true)
                {
                    listValidNeighbors.Add(this.grid[currentLocation.X, currentLocation.Y + 1].getCellLocation());
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                //Checked out of bounds
            }
            return listValidNeighbors;
        }
        public MazeCell[,] getGrid()
        {
            return this.grid;
        }
        public Point getGridSize()
        {
            return this.size;
        }
        public void setCellLength(int cellLength)
        {
            this.cellLength = cellLength;
        }
        public int getCellLength()
        {
            return this.cellLength;
        }
        public Point getDisplaySize()
        {
            return new Point(cellLength * size.X, cellLength * size.Y);
        }
    }
}
