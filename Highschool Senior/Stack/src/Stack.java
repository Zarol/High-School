/**
 * Created with IntelliJ IDEA. User: 295893 Date: 4/16/13 Time: 9:02 AM To change this template use File | Settings |
 * File Templates.
 */
public class Stack {
    TreeNode root;

    /**
     * Creates a new Stack
     */
    public Stack() {
        root = new TreeNode(null, null, null);
    }

    /**
     * Pushes a TreeNode onto the stack
     * @param newTreeNode   The TreeNode to be pushed.
     */
    public void push(TreeNode newTreeNode) {
        TreeNode temp = root;
        if (temp.getValue() == null)
        {
            root = newTreeNode;
        }
        else
        {
            while (temp.getRight() != null)
            {
                temp = temp.getRight();
            }
            temp.setRight(newTreeNode);
        }
    }

    /**
     * Pops the TreeNode from the stack
     * @return  The TreeNode that was popped.
     */
    public TreeNode pop() {
        TreeNode temp = root;
        TreeNode returnNode = null;
        while (temp.getRight() != null)
        {
            if (temp.getRight().getRight() == null)
            {
                returnNode = temp.getRight();
                temp.setRight(null);
                break;
            }
            else
                temp = temp.getRight();
        }
        return returnNode;
    }

    /**
     * Displays the stack
     */
    public void display()
    {
        TreeNode temp = root;
        while (temp.getRight() != null)
        {
            System.out.print(temp.getValue().toString() + " ");
            temp = temp.getRight();
        }
        System.out.print(temp.getValue().toString() + " ");
        System.out.println();
    }
}
