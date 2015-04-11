import java.util.*;
import java.awt.Point;
/**
 * The FillGrid class will fill Grid with a random Sudoku board
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class FillGrid
{
    // instance variables - replace the example below with your own
    private int intCellVal; //0-2
    private Point cellLoc;
    private Point zoneNum; //0-2
    private static int CELLMAX = 9;
    private static int ZONEMAX = 9;
    private boolean numTaken[];
    private Random myRandom;
    private HashMap<Integer,Zone> myMap;
    private Zone specifierZone;

    private Zone myZone00;
    private Zone myZone01;
    private Zone myZone02;
    private Zone myZone10;
    private Zone myZone11;
    private Zone myZone12;
    private Zone myZone20;
    private Zone myZone21;
    private Zone myZone22;

    /**
     * Constructor for objects of class FillGrid
     */
    public FillGrid(){
        // initialise instance variables
        intCellVal = 0;
        cellLoc = new Point(0,0);
        zoneNum = new Point(0,0);
        numTaken = new boolean[9];
        myRandom = new Random(  );
        myMap = new HashMap<Integer,Zone>( );

        myZone00 = new Zone ( new Point(0,0));
        myZone01 = new Zone ( new Point(0,1));
        myZone02 = new Zone ( new Point(0,2));        
        myZone10 = new Zone ( new Point(1,0));
        myZone11 = new Zone ( new Point(1,1));
        myZone12 = new Zone ( new Point(1,2));
        myZone20 = new Zone ( new Point(2,0));
        myZone21 = new Zone ( new Point(2,1));
        myZone22 = new Zone ( new Point(2,2));

        myMap.put(0,myZone00);
        myMap.put(1,myZone01);
        myMap.put(2,myZone02);
        myMap.put(3,myZone10);
        myMap.put(4,myZone11);
        myMap.put(5,myZone12);
        myMap.put(6,myZone20);
        myMap.put(7,myZone21);
        myMap.put(8,myZone22);

    }

    /**
     * An example of a method - replace this comment with your own
     *
     * @param  y   a sample parameter for a method
     * @return     the sum of x and y
     */
    public void fillTheRest(  )
    {
        for ( int intX = 0; intX < 9; intX += 1 ){
            if ( intX == 0 || intX == 4 || intX == 8 ){
                
            } else {
                specifierZone = myMap.get(intX);
                for ( int intY = 0; intY < 3; intY++ ){
                    for ( int intZ = 0; intZ < 3; intZ++ ){
                        cellLoc = new Point(intY,intZ);
                        intCellVal = -1;
                        specifierZone.fillZone( new Cell(intCellVal,cellLoc));
                    }
                }
                specifierZone.checkFull(  );
            }
        }
    }

    /**
     * This method will fill the diagnol Zones (0,0)(1,1)(2,2)
     * 
     * @param  y   a sample parameter for a method
     * @return     the sum of x and y 
     */
    public void fillDiagnol(  ){
        for ( int intX = 0; intX < 9; intX += 4 ){
            specifierZone = myMap.get(intX);
            for ( int intY = 0; intY < 3; intY++ ){
                for ( int intZ = 0; intZ < 3; intZ++ ){
                    cellLoc = new Point(intY,intZ);
                    do{
                        intCellVal = myRandom.nextInt( 9 );
                    } while( numTaken[intCellVal] == true );
                    numTaken[intCellVal] = true;
                    specifierZone.fillZone( new Cell(intCellVal + 1,cellLoc));
                }
            }
            for ( int intY = 0; intY < 9; intY++ ){
                numTaken[intY] = false;
            }
            specifierZone.checkFull(  );
        }
    }
}
