import java.awt.Point;
/**
 * This Cell class will be used to hold values of each individual cells in a Grid
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Cell
{
    // instance variables - replace the example below with your own
    private int intMyVal;
    private Point myLoc;
    
    /**
     * Constructor for objects of class Cell
     */
    public Cell(int intVal, Point loc){
        // initialise instance variables
        intMyVal = intVal;
        myLoc = new Point((int)loc.getX(), (int)loc.getY());
    }

    /**
     * This method will return the cell's location
     */
    public Point getLocation(  ){
        return myLoc;
    }

    /**
     * This method will get the cell's value
     */
    public int getValue(  ){
        return intMyVal;
    }

    /**
     * This method will set the cell's value
     */
    public void setValue(int intVal){
        intMyVal = intVal;
    }
}
