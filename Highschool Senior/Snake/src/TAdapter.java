import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

/**
 * Created with IntelliJ IDEA. User: 295893 Date: 4/15/13 Time: 9:18 AM To change this template use File | Settings |
 * File Templates.
 */
public class TAdapter extends KeyAdapter {
    GameLogic GameLogic;

    /**
     * Constructor Class
     * @param GameLogic
     */
    public TAdapter(GameLogic GameLogic)
    {
        this.GameLogic = GameLogic;
    }

    /**
     * Handles all key events
     * @param e What the key event is
     */
    public void keyPressed(KeyEvent e) {
        switch (e.getKeyCode())
        {
            case KeyEvent.VK_UP:
                //GameLogic.setDirection(0);
                break;
            case KeyEvent.VK_RIGHT:
                //GameLogic.setDirection(1);
                break;
            case KeyEvent.VK_DOWN:
                GameLogic.setDirection(2);
                break;
            case KeyEvent.VK_LEFT:
                //GameLogic.setDirection(3);
                break;
        }
    }
}
