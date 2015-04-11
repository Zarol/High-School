/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
 

import java.util.ArrayList;
import java.util.Random;
import java.awt.*;

/**
 *
 * @author student
 */
public class Grid {

    Cell[][] myGrid;
    Point size;
    int intTotalCells;
    int intVisitedCells;
    ArrayList<Point> listNeighborsWithWalls;
    cellStack myCellStack;
    int lineLength;

    public Grid() {
        size = new Point(100, 100);
        lineLength = 9;
        myGrid = new Cell[(int) size.getX()][(int) size.getY()];
        for (int y = (int) size.getY() - 1; y >= 0; y--) {
            for (int x = 0; x <= (int) size.getX() - 1; x++) {
                myGrid[x][y] = new Cell();
                myGrid[x][y].setPosition(new Point((x * lineLength + lineLength), (((int) size.getY() * lineLength) - (lineLength * y))));
                myGrid[x][y].setCellLocation(new Point(x, y));
            }
        }
        intTotalCells = (int) size.getX() * (int) size.getY();
        intVisitedCells = 0;

        listNeighborsWithWalls = new ArrayList<Point>();
        myCellStack = new cellStack();
    }
    /*
    create a CellStack (LIFO) to hold a list of cell locations
    set TotalCells = number of cells in grid
    choose a cell at random and call it CurrentCell
    set VisitedCells = 1
    
    while VisitedCells < TotalCells
    
    find all neighbors of CurrentCell with all walls intact
    if one or more found
    choose one at random
    knock down the wall between it and CurrentCell
    push CurrentCell location on the CellStack
    make the new cell CurrentCell
    add 1 to VisitedCells
    else
    pop the most recent cell entry off the CellStack
    make it CurrentCell endIf
    
    endWhile
     */

    public void generate() {
        Random myRandom = new Random();
        Cell currentCell = new Cell();
        Cell nextCell = new Cell();
        Point locOfRandom = new Point();
        intVisitedCells = 1;
        int RandomValue = 0;
        currentCell = myGrid[myRandom.nextInt((int) size.getX())][myRandom.nextInt((int) size.getY())];
        //currentCell = myGrid[2][2];
        while (intVisitedCells < intTotalCells) {
            listNeighborsWithWalls = neighborsAllWalls(currentCell.getCellLocation());
            if (listNeighborsWithWalls.size() >= 1) 
            {
                if (listNeighborsWithWalls.size() == 1) 
                {
                    locOfRandom = listNeighborsWithWalls.get(0);
                } 
                else 
                {
                    myRandom.setSeed(System.nanoTime());
                    RandomValue = myRandom.nextInt(listNeighborsWithWalls.size());
                    locOfRandom = listNeighborsWithWalls.get(RandomValue);
                }
                nextCell = myGrid[(int) locOfRandom.getX()][(int) locOfRandom.getY()];
                //WEST, SOUTH, EAST, NORTH
                switch (knockDownWalls(currentCell, nextCell)) {
                    case 0:
                        System.out.println("OMG A ERROR, NOT SUPPOSE TO HAPPEN!");
                        break;
                    //West
                    case 1:
                        myGrid[(int) currentCell.getCellLocation().getX()][(int) currentCell.getCellLocation().getY()].setWalls(8);
                        myGrid[(int) nextCell.getCellLocation().getX()][(int) nextCell.getCellLocation().getY()].setWalls(2);
                        break;
                    //South
                    case 2:
                        myGrid[(int) currentCell.getCellLocation().getX()][(int) currentCell.getCellLocation().getY()].setWalls(4);
                        myGrid[(int) nextCell.getCellLocation().getX()][(int) nextCell.getCellLocation().getY()].setWalls(1);
                        break;
                    //East
                    case 3:
                        myGrid[(int) currentCell.getCellLocation().getX()][(int) currentCell.getCellLocation().getY()].setWalls(2);
                        myGrid[(int) nextCell.getCellLocation().getX()][(int) nextCell.getCellLocation().getY()].setWalls(8);
                        break;
                    //North
                    case 4:
                        myGrid[(int) currentCell.getCellLocation().getX()][(int) currentCell.getCellLocation().getY()].setWalls(1);
                        myGrid[(int) nextCell.getCellLocation().getX()][(int) nextCell.getCellLocation().getY()].setWalls(4);
                        break;
                }
                myCellStack.pushCell(currentCell);
                currentCell = nextCell;
                intVisitedCells++;
            } else {
                currentCell = myCellStack.popCell();
            }
        }
    }
    /*
     * West = 1; South = 2; East = 3; North = 4;
     */

    public int knockDownWalls(Cell cell1, Cell cell2) {
        Cell start = cell1;
        Cell end = cell2;
        int intDifX = 0;
        int intDifY = 0;
        intDifX = (int) (start.getCellLocation().getX() - end.getCellLocation().getX());
        intDifY = (int) (start.getCellLocation().getY() - end.getCellLocation().getY());
        if (intDifX == 1 && intDifY == 0) {
            return 1; //return WEST (Relative to Current)
        } else if (intDifX == 0 && intDifY == 1) {
            return 2; //return SOUTH (Relative to Current)
        } else if (intDifX == -1 && intDifY == 0) {
            return 3; //return EAST (Relative to Current)
        } else if (intDifX == 0 && intDifY == -1) {
            return 4; //return NORTH (Relative to Current)
        } else {
            return 0; //return ?!?!?!? ERROR?!
        }

    }
    //WEST SOUTH EAST NORTH

    public ArrayList<Point> neighborsAllWalls(Point currentLocation) {
        ArrayList<Point> listValidNeighbors = new ArrayList<Point>();
        try {
            //CHECK WEST
            if (myGrid[(int) currentLocation.getX() - 1][(int) currentLocation.getY()].allWallsIntact() == true) {
                listValidNeighbors.add(myGrid[(int) currentLocation.getX() - 1][(int) currentLocation.getY()].getCellLocation());
            }
        } catch (IndexOutOfBoundsException ie) {
        }
        try {
            //CHECK SOUTH
            if (myGrid[(int) currentLocation.getX()][(int) currentLocation.getY() - 1].allWallsIntact() == true) {
                listValidNeighbors.add(myGrid[(int) currentLocation.getX()][(int) currentLocation.getY() - 1].getCellLocation());
            }
        } catch (IndexOutOfBoundsException ie) {
        }
        try {
            //CHECK EAST
            if (myGrid[(int) currentLocation.getX() + 1][(int) currentLocation.getY()].allWallsIntact() == true) {
                listValidNeighbors.add(myGrid[(int) currentLocation.getX() + 1][(int) currentLocation.getY()].getCellLocation());
            }
        } catch (IndexOutOfBoundsException ie) {
        }
        try {
            //CHECK NORTH
            if (myGrid[(int) currentLocation.getX()][(int) currentLocation.getY() + 1].allWallsIntact() == true) {
                listValidNeighbors.add(myGrid[(int) currentLocation.getX()][(int) currentLocation.getY() + 1].getCellLocation());
            }
        } catch (IndexOutOfBoundsException ie) {
        }
        return listValidNeighbors;
    }

    public Cell[][] getGrid() {
        return myGrid;
    }

    public Point getSize() {
        return size;
    }

    public int getLineLength() {
        return lineLength;
    }

    public Point getScreenSize() {
        Point lastCell = myGrid[(int)size.getX()-1][(int)size.getY()-1].getPosition();
        //x:20-- 20,20,20,20,20 = 100
        //x:20-- 20,00,00,00,20 = 100
        //x:20-- 20,00,00,00,20 = 100
        //x:20-- 20,00,00,00,20 = 100
        //x:20-- 20,20,20,20,20 = 100
        //y:20-- = 100 = 100 = 100
        int sizeX = (int) (lineLength * (size.getX() + 1));
        int sizeY = (int) (lineLength * (size.getY() + 4));
        Point screenSize = new Point(sizeX,sizeY);
        return screenSize;
    }
}
