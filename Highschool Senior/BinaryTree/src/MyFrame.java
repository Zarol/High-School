/**
 * Created with IntelliJ IDEA. User: 295893 Date: 3/4/13 Time: 9:18 AM To change this template use File | Settings |
 * File Templates.
 */
import javax.swing.*;
import java.awt.*;
public class MyFrame extends JFrame {
    private TreeNode TreeNode;

    /**
     * Constructor method for a canvas to draw the tree.
     * @param treeNode
     */
    public MyFrame(TreeNode treeNode)
    {
        super("Tree Structure");
        setContentPane(new DrawPane());
        setSize(800,800);
        setVisible(true);
        TreeNode = treeNode;
    }

    /**
     * Class that will draw the tree which extends JPanel.
     */
    class DrawPane extends JPanel
    {
        /**
         * The overridden draw method.
         * @param g
         */
        public void paintComponent(Graphics g)
        {
            paintComponent(g,TreeNode,300,50, 0);
        }

        /**
         * Helper method to paint the Tree.
         * @param g The graphics component of the JFrame.
         * @param node  The Node being drawn.
         * @param x The x-position of the Node.
         * @param y The y-position of the Node.
         * @param depth The level/depth of the Node.
         */
        private void paintComponent(Graphics g, TreeNode node, int x, int y, int depth)
        {
            x += depth;
            if (node.getLeft() == null && node.getRight() == null)
            {
                depth -= 20;
                g.drawString(node.getValue().toString(),x,y);

                return;
            }
            if (node.getLeft() != null)
            {
                g.drawLine(x+5,y,x-50+depth,y+50);
                paintComponent(g,node.getLeft(),x - 50,y + 50, depth);
            }
            if (node.getRight() != null)
            {
                depth += 20;
                g.drawLine(x+5,y,x+50+depth,y+50);
                g.drawString(node.getValue().toString(),x,y);

                paintComponent(g,node.getRight(),x +50,y + 50, depth);
            }
            return;
        }
    }
}
