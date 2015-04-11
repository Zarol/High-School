/**
 * Created with IntelliJ IDEA. User: 295893 Date: 4/16/13 Time: 9:02 AM To change this template use File | Settings |
 * File Templates.
 */
import java.util.*;
public class Queue {
    ArrayList queue;

    /**
     * Creates a new Queue
     */
    public Queue() {
        queue = new ArrayList();
    }

    /**
     * Pushes a TreeNode onto the queue
     * @param newTreeNode   The TreeNode to be enqueued.
     */
    public void Enqueue(TreeNode newTreeNode) {
        queue.add(newTreeNode);
    }

    /**
     * Pops the TreeNode from the queue
     * @return  The TreeNode that was dequeued.
     */
    public TreeNode Dequeue() {
        return (TreeNode)queue.remove(0);
    }

    /**
     * Displays the Queue
     */
    public void display()
    {
        for( int i = 0; i < queue.size(); i++)
        {
            System.out.println(((TreeNode)queue.get(i)).getValue().toString());
        }
    }
}
