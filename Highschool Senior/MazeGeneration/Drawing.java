/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
 

import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Random;
import javax.swing.JApplet;
import javax.swing.JOptionPane;

/**
 *
 * @author Admin
 */
public class Drawing extends JApplet implements KeyListener {

    Cell[][] drawGrid;
    Point mySize;
    int myLineLength;
    Cell currentCell;
    Cell endCell;
    Random myRandom;
    int wentThrough;

    public Drawing(Cell[][] passedGrid, Point size, int lineLength) {
        drawGrid = passedGrid;
        mySize = size;
        myLineLength = lineLength;
        //1 hasn't visited, 2 visited, 4 occupied
        currentCell = drawGrid[0][0];
        endCell = new Cell();
        drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y].setPlayer(4);
        myRandom = new Random(System.nanoTime());
        wentThrough = 0;
    }

    public void init() {
        setBackground(Color.white);
        setForeground(Color.white);
        this.addKeyListener(this);
                JOptionPane.showMessageDialog(this, "Welcome! This maze game will generate a new maze every time you run the program!");
                JOptionPane.showMessageDialog(this, "Click the screen first, then you may move the green box with 'WASD'. Your goal is to reach the red box!");
    }

    public void drawNorth(int x, int y, Graphics2D g3) {
        g3.drawLine((int) drawGrid[x][y].getPosition().getX(),
                (int) drawGrid[x][y].getPosition().getY(),
                (int) drawGrid[x][y].getPosition().getX() + myLineLength,
                (int) drawGrid[x][y].getPosition().getY());
    }

    public void drawSouth(int x, int y, Graphics2D g3) {
        g3.drawLine((int) drawGrid[x][y].getPosition().getX(),
                (int) drawGrid[x][y].getPosition().getY() + myLineLength,
                (int) drawGrid[x][y].getPosition().getX() + myLineLength,
                (int) drawGrid[x][y].getPosition().getY() + myLineLength);
    }

    public void drawWest(int x, int y, Graphics2D g3) {
        g3.drawLine((int) drawGrid[x][y].getPosition().getX(),
                (int) drawGrid[x][y].getPosition().getY(),
                (int) drawGrid[x][y].getPosition().getX(),
                (int) drawGrid[x][y].getPosition().getY() + myLineLength);
    }

    public void drawEast(int x, int y, Graphics2D g3) {
        g3.drawLine((int) drawGrid[x][y].getPosition().getX() + myLineLength,
                (int) drawGrid[x][y].getPosition().getY(),
                (int) drawGrid[x][y].getPosition().getX() + myLineLength,
                (int) drawGrid[x][y].getPosition().getY() + myLineLength);
    }

    public void drawVisited(int x, int y, Graphics2D g3) {
        Point position = drawGrid[x][y].getPosition();
        g3.setColor(Color.YELLOW);
        g3.fillRect((int) position.getX(), (int) position.getY(), myLineLength, myLineLength);
        g3.setColor(Color.BLACK);
    }

    public void drawOccupied(int x, int y, Graphics2D g3) {
        Point position = drawGrid[x][y].getPosition();
        g3.setColor(Color.GREEN);
        g3.fillRect((int) position.getX(), (int) position.getY(), myLineLength, myLineLength);
        g3.setColor(Color.BLACK);
    }

    @Override
    public void paint(Graphics g) {
        Graphics2D g2 = (Graphics2D)g;
        int walls();
        int player;
        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING,
            RenderingHints.VALUE_ANTIALIAS_ON);
        g2.setColor(Color.BLACK);
        g2.setStroke(new BasicStroke(2.0f));
        if (wentThrough == 0) {
            switch (myRandom.nextInt(3)) {
                case 0:
                    endCell = drawGrid[0][mySize.y - 1];
                    g2.setColor(Color.RED);
                    g2.fillRect((int) endCell.getPosition().getX(), (int) endCell.getPosition().getY(), myLineLength, myLineLength);
                    g2.setColor(Color.BLACK);
                    endCell.setPlayer(8);
                    break;
                case 1:
                    endCell = drawGrid[mySize.x - 1][mySize.y - 1];
                    g2.setColor(Color.RED);
                    g2.fillRect((int) endCell.getPosition().getX(), (int) endCell.getPosition().getY(), myLineLength, myLineLength);
                    g2.setColor(Color.BLACK);
                    endCell.setPlayer(8);
                    break;
                case 2:
                    endCell = drawGrid[mySize.x - 1][0];
                    g2.setColor(Color.RED);
                    g2.fillRect((int) endCell.getPosition().getX(), (int) endCell.getPosition().getY(), myLineLength, myLineLength);
                    g2.setColor(Color.BLACK);
                    endCell.setPlayer(8);
                    break;
            }
            wentThrough++;
        }
        //West = 8, South = 4, East = 2, North = 1
        for (int x = 0; x < mySize.getX(); x++) {
            for (int y = 0; y < mySize.getY(); y++) {
                walls.set(drawGrid[x][y].getWalls());
                player = drawGrid[x][y].getPlayer();
                switch (player) {
                    case 1:
                        break;
                    case 2:
                        drawVisited(x, y, g2);
                        break;
                    case 4:
                        drawOccupied(x, y, g2);
                        break;
                }
                switch (walls.get()) {
                    case 15:
                        drawWest(x, y, g2);
                        drawSouth(x, y, g2);
                        drawEast(x, y, g2);
                        drawNorth(x, y, g2);
                        break;
                    case 14:
                        drawWest(x, y, g2);
                        drawSouth(x, y, g2);
                        drawEast(x, y, g2);
                        break;
                    case 13:
                        drawWest(x, y, g2);
                        drawSouth(x, y, g2);
                        drawNorth(x, y, g2);
                        break;
                    case 12:
                        drawWest(x, y, g2);
                        drawSouth(x, y, g2);
                        break;
                    case 11:
                        drawWest(x, y, g2);
                        drawEast(x, y, g2);
                        drawNorth(x, y, g2);
                        break;
                    case 10:
                        drawWest(x, y, g2);
                        drawEast(x, y, g2);
                        break;
                    case 9:
                        drawWest(x, y, g2);
                        drawNorth(x, y, g2);
                        break;
                    case 8:
                        drawWest(x, y, g2);
                        break;
                    case 7:
                        drawSouth(x, y, g2);
                        drawEast(x, y, g2);
                        drawNorth(x, y, g2);
                        break;

                    case 6:
                        drawSouth(x, y, g2);
                        drawEast(x, y, g2);
                        break;
                    case 5:
                        drawSouth(x, y, g2);
                        drawNorth(x, y, g2);
                        break;
                    case 4:
                        drawSouth(x, y, g2);
                        break;
                    case 3:
                        drawEast(x, y, g2);
                        drawNorth(x, y, g2);
                        break;
                    case 2:
                        drawEast(x, y, g2);
                        break;
                    case 1:
                        drawNorth(x, y, g2);
                        break;
                }
            }
        }
    }

    public void keyTyped(KeyEvent e) {
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public void keyPressed(KeyEvent e) {
        char id = e.getKeyChar();
        switch (id) {
            case 'w':
                moveNorth();
                break;
            case 'a':
                moveWest();
                break;
            case 's':
                moveSouth();
                break;
            case 'd':
                moveEast();
                break;
        }
        if (drawGrid[(int) endCell.getCellLocation().getX()][(int) endCell.getCellLocation().getY()].getPlayer() == 4) {
            JOptionPane.showMessageDialog(this, "You Win!");
            System.exit(0);
        }
        this.repaint();
    }

    public void keyReleased(KeyEvent e) {
       char id = e.getKeyChar();
       switch (id) {
           case 'w':
               moveNorth();
               break;
           case 'a':
               moveWest();
               break;
           case 's':
               moveSouth();
               break;
           case 'd':
               moveEast();
               break;
       }
       if (drawGrid[(int) endCell.getCellLocation().getX()][(int) endCell.getCellLocation().getY()].getPlayer() == 4) {
           JOptionPane.showMessageDialog(this, "You Win!");
       }
       this.repaint();
    }
//W = 8;S = 4;E = 2;N = 1

    private void moveNorth() {
        switch (currentCell.getWalls()) {
            case 14:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
            case 12:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
            case 10:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
            case 8:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
            case 6:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
            case 4:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
            case 2:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
            case 0:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y + 1];
                currentCell.setPlayer(4);
                break;
        }
    }

    private void moveWest() {
        switch (currentCell.getWalls()) {
            case 7:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;

            case 6:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 5:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 4:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 3:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 2:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 1:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 0:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x - 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
        }
    }

    private void moveSouth() {
        switch (currentCell.getWalls()) {
            case 11:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
            case 10:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
            case 9:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
            case 8:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
            case 3:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
            case 2:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
            case 1:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
            case 0:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x][currentCell.getCellLocation().y - 1];
                currentCell.setPlayer(4);
                break;
        }
    }

    private void moveEast() {
        switch (currentCell.getWalls()) {
            case 13:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 12:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 9:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 8:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 5:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 4:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 1:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;
            case 0:
                currentCell.setPlayer(2);
                currentCell = drawGrid[currentCell.getCellLocation().x + 1][currentCell.getCellLocation().y];
                currentCell.setPlayer(4);
                break;

        }
    }
}
