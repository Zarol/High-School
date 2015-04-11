/**
 * Created with IntelliJ IDEA. User: 295893 Date: 2/26/13 Time: 9:00 AM To change this template use File | Settings |
 * File Templates.
 */
public class TreeNode {
    private Object value;
    private TreeNode left;
    private TreeNode right;

    /**
     * Creates a new TreeNode
     * @param initValue The Node's value.
     * @param initLeft  The Node's left Node.
     * @param initRight The Node's right Node.
     */
    public TreeNode(Object initValue, TreeNode initLeft,
                    TreeNode initRight)
    {
        value = initValue;
        left = initLeft;
        right = initRight;
    }

    /**
     * Getter method for the Node's value.
     * @return  This Node's value.
     */
    public Object getValue()
    {
        return value;
    }

    /**
     * Getter method for the Node's left Node.
     * @return  This Node's left Node.
     */
    public TreeNode getLeft()
    {
        return left;
    }

    /**
     * This Node's right Node.
     * @return
     */
    public TreeNode getRight()
    {
        return right;
    }

    /**
     * Setter method for the Node's value.
     * @param theNewValue   This Node's new value.
     */
    public void setValue(Object theNewValue)
    {
        value = theNewValue;
    }

    /**
     * Setter method for the Node's left Node.
     * @param theNewLeft    This Node's new left Node.
     */
    public void setLeft(TreeNode theNewLeft)
    {
        left = theNewLeft;
    }

    /**
     * Setter method for the Node's right Node.
     * @param theNewRight   This Node's new right Node.
     */
    public void setRight(TreeNode theNewRight)
    {
        right = theNewRight;
    }
}
