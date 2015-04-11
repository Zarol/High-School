import java.awt.*;
/**
 * Write a description of class Driver here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Driver
{
    public static void main( String args[ ] ){   
        Grid myGrid = new Grid(  );
        FillGrid myFill = new FillGrid(  );
        myFill.fillTheRest(  );
        myFill.fillDiagnol(  );
        GUI myGUI = new GUI( myGrid );
        //myGUI.paintBoarder(Graphics.create(  ));
        return; //used to break points
    } 
}
