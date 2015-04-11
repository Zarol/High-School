import javax.swing.*;

/**
 * Created with IntelliJ IDEA. User: 295893 Date: 4/15/13 Time: 9:23 AM To change this template use File | Settings |
 * File Templates.
 */
public class Window extends JFrame {
    /**
     * Constructor Class
     */
    public Window()
    {
        Draw _draw = new Draw();
        add(_draw);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(_draw.OPTIMAL_WIDTH, _draw.OPTIMAL_HEIGHT);
        setLocationRelativeTo(null);
        setTitle("Snake");
        setResizable(false);
        setVisible(true);
    }
}
