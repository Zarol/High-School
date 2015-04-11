/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

 

import java.awt.Point;

/**
 *
 * @author student
 */
public class Cell {
    int intWalls;
    int intBorder;
    int intSolution;
    int intBacktrack;
    Point location;
    Point position;
    int playerPosition;
    public Cell(){
        //West, South, East, North
        intWalls = 15;
        intBorder = 0;
        intSolution = 0;
        intBacktrack = 0;
        location = new Point(0,0);
        position = new Point(0,0);
        playerPosition = 1;
    }
    public void setPlayer(int value){
        //1 = hasn't been visited
        //2 = visited
        //4 = currently occupied
        playerPosition = value;
    }
    public int getPlayer(){
        return playerPosition;
    }
    public Point getCellLocation(){
        return location;
    }
    public void setCellLocation(Point newLocation){
        location = newLocation;
    }
    public Point getPosition(){
        return position;
    }
    public void setPosition(Point newPos){
        position = newPos;
    }
    public int getWalls(){
        return intWalls;
    }
    public void setWalls(int newVal){
        intWalls -= newVal;
    }
    public int getBorder(){
        return intBorder;
    }
    public void setBorder(int newVal){
        intBorder += newVal;
    }
    public int getSolution(){
        return intSolution;
    }
    public void setSolution(int newVal){
        intSolution += newVal;
    }
    public int getBacktrack(){
        return intBacktrack;
    }
    public void setBacktrack(int newVal){
        intBacktrack += newVal;
    }
    public boolean allWallsIntact(){
        if(intWalls == 15){
            return true;
        } else {
            return false;
        }
    }
}
