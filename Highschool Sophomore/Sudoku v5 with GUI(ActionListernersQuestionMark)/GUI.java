import javax.swing.*;
import java.awt.*;
import java.util.*;


/**
 * Write a description of class GUI here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class GUI extends JFrame
{
    // instance variables - replace the example below with your own
    GridLayout myLayout;
    Dimension screenSize;
    int intVal;
    JPanel zone1;
    JPanel zone2;
    JPanel zone3;
    JPanel zone4;
    JPanel zone5;
    JPanel zone6;
    JPanel zone7;
    JPanel zone8;
    JPanel zone9;

    /**
     * Constructor for objects of class GUI
     */
    public GUI( Grid theGrid )
    {
        super("Sudoku");
        // initialise instance variables
        this.getContentPane().setBackground(Color.BLACK);
        screenSize = Toolkit.getDefaultToolkit().getScreenSize();
        intVal = 0;
        myLayout = new GridLayout(3,3,8,8);
        setLayout(myLayout);
        add((zone1 = new JPanel()));
        add((zone2 = new JPanel()));
        add((zone3 = new JPanel()));
        add((zone4 = new JPanel()));
        add((zone5 = new JPanel()));
        add((zone6 = new JPanel()));
        add((zone7 = new JPanel()));
        add((zone8 = new JPanel()));
        add((zone9 = new JPanel()));

        zone1.setLayout(new GridLayout(3,3));
        zone2.setLayout(new GridLayout(3,3));
        zone3.setLayout(new GridLayout(3,3));
        zone4.setLayout(new GridLayout(3,3));
        zone5.setLayout(new GridLayout(3,3));
        zone6.setLayout(new GridLayout(3,3));
        zone7.setLayout(new GridLayout(3,3));
        zone8.setLayout(new GridLayout(3,3));
        zone9.setLayout(new GridLayout(3,3));

        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(0,0), new Point(cellX,cellY));
                zone1.add(new JButton("" + intVal));
                
            }
        }
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(0,1), new Point(cellX,cellY));
                zone2.add(new JButton("" + intVal));
            }
        }
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(0,2), new Point(cellX,cellY));
                zone3.add(new JButton("" + intVal));
            }
        } 
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(1,0), new Point(cellX,cellY));
                zone4.add(new JButton("" + intVal));
            }
        }
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(1,1), new Point(cellX,cellY));
                zone5.add(new JButton("" + intVal));
            }
        } 
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(1,2), new Point(cellX,cellY));
                zone6.add(new JButton("" + intVal));
            }
        }  
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(2,0), new Point(cellX,cellY));
                zone7.add(new JButton("" + intVal));
            }
        } 
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(2,1), new Point(cellX,cellY));
                zone8.add(new JButton("" + intVal));
            }
        } 
        for ( int cellX = 0; cellX < 3; cellX ++ ){
            for ( int cellY = 0; cellY < 3; cellY ++ ){
                intVal = theGrid.getValue( new Point(2,2), new Point(cellX,cellY));
                zone9.add(new JButton("" + intVal));
            }
        }
        setSize(screenSize.width,screenSize.height);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setVisible(true);
    }
}
