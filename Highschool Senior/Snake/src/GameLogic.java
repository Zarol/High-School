import javax.swing.*;
import java.awt.*;
import java.util.PriorityQueue;
import java.util.*;

/**
 * Created with IntelliJ IDEA. User: 295893 Date: 4/30/13 Time: 9:03 AM To change this template use File | Settings |
 * File Templates.
 */
public class GameLogic {
    Draw Base;
    int[][] Board;

    private LinkedList direction, tempDirection;
    private LinkedList snake, tempSnake;
    private int snakeLength;
    private Point headLocation;

    /**
     * Constructor Class
     * @param Base  Applet to draw to
     * @param Board The board of the game
     */
    public GameLogic(Draw Base, int[][] Board)
    {
        this.Base = Base;
        this.Board = Board;
        InitializeSnake();
    }

    /**
     * Initializes all the variable for the game
     */
    private void InitializeSnake()
    {
        direction = new LinkedList();
        tempDirection = new LinkedList();
        snake = new LinkedList();
        tempSnake = new LinkedList();
        snakeLength = 4;
        headLocation = new Point(4,4);

        snake.add(2);   //Add Head
        direction.add(2);
        for (int i = 1; i < snakeLength; i++)
        {
            snake.add(1);   //Add Body
            direction.add(2);
        }

        Board[headLocation.x][headLocation.y] = 2;
        switch (Opposite(direction.indexOf(0)))
        {
            case 0: //Add Body Up
                for (int i = 1; i < snakeLength; i++)
                {
                    Board[headLocation.x][headLocation.y - i] = 1;
                }
                break;
            case 1: //Add Body Right
                for (int i = 1; i < snakeLength; i++)
                {
                    Board[headLocation.x + i][headLocation.y] = 1;
                }
                break;
            case 2: //Add Body Down
                for (int i = 1; i < snakeLength; i++)
                {
                    Board[headLocation.x][headLocation.y + i] = 1;
                }
                break;
            case 3: //Add Body Left                                                                 `
                for (int i = 1; i < snakeLength; i++)
                {
                    Board[headLocation.x - i][headLocation.y] = 1;
                }
                break;
            default:
                break;
        }
        Base.SetGrid(Board);
    }

    /**
     * Does Logic
     */
    public void DoLogic()
    {
        for(int x = 0; x < Board.length; x++)
            for (int y = 0; y < Board.length; y++)
            {
                if (Board[x][y] == 2)
                    headLocation = new Point(x,y);
            }
        if (headLocation.y >= Board.length - 1)
        {
            System.exit(0);
        }
        Point moveLocation = headLocation;
        while (snake.isEmpty() == false)
        {
            tempSnake.add(snake.peek());
            tempDirection.add(direction.peek());
            Point displace = DisplaceDirection(Integer.parseInt(direction.poll().toString()));
            Board[moveLocation.x][moveLocation.y] = 0;
            Board[moveLocation.x + displace.x][moveLocation.y + displace.y] = Integer.parseInt(snake.poll().toString());
            moveLocation.x -= displace.x;
            moveLocation.y -= displace.y;
        }
        while (tempSnake.isEmpty() == false)
        {
            snake.add(tempSnake.poll());
        }
        while (tempDirection.isEmpty() == false)
        {
            direction.add(tempDirection.poll());
        }
    }

    /**
     * Determines how much to displace the snake based on direction
     * @param direction
     * @return
     */
    private Point DisplaceDirection(int direction)
    {
        Point displace = new Point();
        switch (direction)
        {
            case 0: //Up
                displace.y = -1;
                break;
            case 1: //Right
                displace.x = 1;
                break;
            case 2: //Down
                displace.y = 1;
                break;
            case 3: //Left
                displace.x = -1;
                break;
            default:
                break;
        }
        return displace;
    }

    /**
     * Sets the direction variable
     * @param direction
     */
    public void setDirection(int direction)
    {
        this.direction.set(0, direction);
    }

    /**
     * Determines the opposite direction
     * @param direction The direction that needs to be opposite'd
     * @return  The opposite direction
     */
    private int Opposite(int direction)
    {
        switch (direction)
        {
            case 0: //Up
                return 2;
            case 1: //Right
                return 3;
            case 2: //Down
                return 0;
            case 3: //Left
                return 1;
            default:
                return -1;
        }
    }
}
