import java.awt.Point;
/**
 * This Zone class will act as a "Zone" of 9x9 cells
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Zone
{
    // instance variables - replace the example below with your own
    private Point myZoneLoc;
    private Cell[][] arrMyZone;

    /**
     * Constructor for objects of class Zone
     */
    public Zone(Point zoneLoc){
        // initialise instance variables
        myZoneLoc = zoneLoc;
        arrMyZone = new Cell[3][3];
    }

    /**
     * This method will check if Zone is full. If full it will place itself into Grid.
     */
    public void checkFull(  )
    {
        for ( int intX = 0; intX < 3; intX++){
            for ( int intY = 0; intY < 3; intY++){
                if ( arrMyZone[intX][intY].getValue(  ) == 0 ){
                    break;
                }
                if ( intX == 2 & intY == 2 ){
                    Grid.fillGrid(this);
                }
            }
        }
    }

    /**
     * This method will fill the Zone with a specific Cell
     */
    public void fillZone(Cell objCell){
        Point location = objCell.getLocation(  );
        arrMyZone[(int)location.getX( )][(int)location.getY( )] = objCell;
    }

    /**
     * This method will return the Zone's location
     */
    public Point getLocation(  ){
        return myZoneLoc;
    }
    
    /**
     * Returns the Zone's array
     */
    public int getValue(Point cellLoc)
    {
        Cell tempCell = arrMyZone[(int)cellLoc.getX(  )][(int)cellLoc.getY(  )];
        return tempCell.getValue(  );
    }

}
