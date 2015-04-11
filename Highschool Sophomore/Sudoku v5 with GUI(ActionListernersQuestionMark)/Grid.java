import java.awt.Point;
/**
 * This Grid class will hold an array of Zone objects and methods to edit them.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Grid
{
    // instance variables - replace the example below with your own
    private static Zone[][] arrMyGrid;

    /**
     * Constructor for objects of class Grid
     */
    public Grid(  )
    {
        // initialise instance variables
        arrMyGrid = new Zone[3][3];
    }

    /**
     * This method will fill the Grid with a specific Zone
     */
    public static void fillGrid(Zone objZone)
    {
        Point location = objZone.getLocation(  );
        arrMyGrid[(int)location.getX(  )][(int)location.getY(  )] = objZone;
    }

    /**
     * This method will return a cell's value
     */
    public static int getValue(Point zoneLoc, Point cellLoc)
    {
        Zone tempZone = arrMyGrid[(int)zoneLoc.getX(  )][(int)zoneLoc.getY(  )];
        return tempZone.getValue( cellLoc );
    }

}
