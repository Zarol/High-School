/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
 

import java.awt.Dimension;
import java.awt.Toolkit;
import javax.swing.JFrame;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.JApplet;

/**
 *
 * @author student
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        JFrame f = new JFrame("Maze Generator");
        f.addWindowListener(new WindowAdapter() {

            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        });
        Grid mazeGame = new Grid();
        mazeGame.generate();
        JApplet applet = new Drawing(mazeGame.getGrid(),mazeGame.getSize(),mazeGame.getLineLength());
        f.getContentPane().add("Center", applet);
        applet.init();
        f.pack();
        Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
        f.setSize(screenSize);
        f.setVisible(true);
    }
}
