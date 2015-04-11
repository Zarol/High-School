import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.util.Timer;
import javax.swing.*;
/**
 * Created with IntelliJ IDEA. User: 295893 Date: 4/15/13 Time: 9:00 AM To change this template use File | Settings |
 * File Templates.
 */
public class Draw extends JPanel implements ActionListener {
    private final int WIDTH = 600;
    private final int HEIGHT = 600;
    private final int ICO_SIZE = 30;

    private final int BOARD_WIDTH = WIDTH / ICO_SIZE;
    private final int BOARD_HEIGHT = HEIGHT / ICO_SIZE;

    public final int OPTIMAL_WIDTH = BOARD_WIDTH * ICO_SIZE + ICO_SIZE;
    public final int OPTIMAL_HEIGHT = BOARD_HEIGHT * ICO_SIZE + ICO_SIZE;

    private int Board[][] = new int[BOARD_WIDTH][BOARD_HEIGHT];

    private Image ImgPowerUp;
    private Image ImgSnakeHead;
    private Image ImgSnakeBody;
    private Image ImgBackground;

    private GameLogic GameLogic;

    /**
     * Constructor Class
     */
    public Draw()
    {
        GameLogic = new GameLogic(this, Board);
        addKeyListener(new TAdapter(GameLogic));
        setBackground(Color.black);
        setFocusable(true);

        ImageIcon imgIcoPowerUp = new ImageIcon(this.getClass().getResource("PowerUp.png"));
        ImgPowerUp = imgIcoPowerUp.getImage();
        ImageIcon imgIcoSnakeHead = new ImageIcon(this.getClass().getResource("SnakeHead.png"));
        ImgSnakeHead = imgIcoSnakeHead.getImage();
        ImageIcon imgIcoSnakeBody = new ImageIcon(this.getClass().getResource("SnakeBody.png"));
        ImgSnakeBody = imgIcoSnakeBody.getImage();
        ImageIcon imgIcoBackground = new ImageIcon(this.getClass().getResource("Background.png"));
        ImgBackground = imgIcoBackground.getImage();


        new javax.swing.Timer(500, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                repaint();
            }
        }).start();
    }

    /**
     * Initializes the Grid
     * @param newBoard  The board to be initialized
     */
    public void SetGrid(int[][] newBoard)
    {
        Board = newBoard;
    }

    /**
     * Any action performed in the applet
     * @param e The action event
     */
    public void actionPerformed(ActionEvent e)
    {
        repaint();
    }

    /**
     * The method that handles all drawing to the applet
     * @param g The graphics device that should be used
     */
    public void paint(Graphics g)
    {
        GameLogic.DoLogic();
        super.paint(g);

        g.drawImage(ImgBackground, 0, 0, OPTIMAL_WIDTH, OPTIMAL_HEIGHT, this);

        for (int xBoard = 0; xBoard < BOARD_HEIGHT; xBoard++)
        {
            for (int yBoard = 0; yBoard < BOARD_HEIGHT; yBoard++)
            {
                switch (Board[xBoard][yBoard])
                {
                    case 0: //Nothing
                        break;
                    case 1: //Body
                        g.drawImage(ImgSnakeBody,xBoard * ICO_SIZE, yBoard * ICO_SIZE, ICO_SIZE, ICO_SIZE, this);
                        break;
                    case 2: //Head
                        g.drawImage(ImgSnakeHead,xBoard * ICO_SIZE, yBoard * ICO_SIZE, ICO_SIZE, ICO_SIZE, this);
                        break;
                    case 3: //Power Up
                        g.drawImage(ImgPowerUp,xBoard * ICO_SIZE, yBoard * ICO_SIZE, ICO_SIZE, ICO_SIZE, this);
                        break;
                }
            }
        }

        Toolkit.getDefaultToolkit().sync();
        g.dispose();
    }
}
