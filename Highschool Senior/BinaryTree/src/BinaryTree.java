/**
 * Created with IntelliJ IDEA. User: 295893 Date: 2/26/13 Time: 9:01 AM To change this template use File | Settings |
 * File Templates.
 */
import java.util.*;
public class BinaryTree {
    int[] IntegerList;
    TreeNode IntegerTree;
    String FormattedString = "";
    int[] SortedIntegerList;
    ArrayList<ArrayList<String>> TreeString;
    int counter;

    /**
     * Constructor method for a new binary tree.
     * @param IntegerList   The array of integers to be put into the tree.
     */
    public BinaryTree(int[] IntegerList)
    {
        this.IntegerList = IntegerList;
        this.IntegerTree = new TreeNode(IntegerList[0],null,null);
        CreateTree();
    }

    /**
     * Getter method for this BinaryTree's tree.
     * @return  This BinaryTree's tree.
     */
    public TreeNode GetTree()
    {
        return IntegerTree;
    }

    /**
     * Getter method for the sorted integer array of this BinaryTree.
     * @return  An array of sorted integers from least to greatest of this Binary tree.
     */
    public int[] GetSortedIntegerList()
    {
        SortedIntegerList = new int[IntegerList.length];
        counter = 0;
        SortedIntegerList(IntegerTree);

        return SortedIntegerList;
    }

    /**
     * This method will visually print the BinaryTree.
     */
    public void PrintCanvas()
    {
        new MyFrame(IntegerTree);
    }

    /**
     * Prints the BinaryTree in order from least to greatest.
     * @param temp  The Node to be printed.
     */
    public void inorder(TreeNode temp)
    {
        if (temp != null)
        {
            inorder(temp.getLeft());
            System.out.print(temp.getValue() + " ");
            inorder(temp.getRight());
        }
    }

    /**
     * Prints the BinaryTree in post order.
     * @param temp
     */
    public void postorder(TreeNode temp)
    {
        if (temp != null)
        {
            postorder(temp.getLeft());
            postorder(temp.getRight());
            System.out.print(temp.getValue() + " ");
        }
    }

    /**
     * Prints the BinaryTree in pre order.
     * @param temp
     */
    public void preorder (TreeNode temp)
    {
        if (temp != null)
        {
            System.out.print(temp.getValue() + " ");
            postorder(temp.getLeft());
            postorder(temp.getRight());

        }
    }

    /**
     * Prints the BinaryTree in level order.
     * @param temp
     */
    public void levelorder (TreeNode temp)
    {
        LinkedList<TreeNode> queue = new LinkedList<TreeNode>();
        queue.add(temp);
        while (!queue.isEmpty())
        {
            TreeNode node = queue.removeFirst();
            System.out.print(node.getValue() + " ");
            if (node.getLeft() != null)
                queue.add(node.getLeft());
            if (node.getRight() != null)
                queue.add(node.getRight());
        }
    }

    /**
     * This method will find a given integer if it is within the BinaryTree.
     * @param root  The BinaryTree's root node.
     * @param valueToFind   The integer value to find within the Binary Tree.
     * @return
     */
    public TreeNode find(TreeNode root, Comparable valueToFind)
    {
        TreeNode node = root;

        while (node != null)
        {
            int result = valueToFind.compareTo(node.getValue());
            if (result == 0)
                return node;
            else if (result < 0)
                node = node.getLeft();
            else
                node = node.getRight();
        }
        return null;
    }

    /**
     * Helper method to put all values within the tree into a sorted integer array.
     * @param node  A node's child.
     */
    private void SortedIntegerList(TreeNode node)
    {
        if (node.getLeft() == null && node.getRight() == null)
        {
            SortedIntegerList[counter] = Integer.parseInt(node.getValue().toString());
            counter++;
            return;
        }
        if (node.getLeft() != null)
        {
            SortedIntegerList(node.getLeft());
        }
        if (node.getRight() != null)
        {
            SortedIntegerList[counter] = Integer.parseInt(node.getValue().toString());
            counter++;
            SortedIntegerList(node.getRight());
        }
        return;
    }

    /**
     * Helper method to put this BinaryTree's integer list into a Binary Tree.
     */
    private void CreateTree()
    {
        for (int i = 1; i < IntegerList.length; i++)
        {
            boolean escape = false;
            TreeNode selectedNode = IntegerTree;
            do
            {
                switch (DecideDirection(IntegerList[i],selectedNode))
                {
                    case 1: //Right
                        TreeNode tempNodeR = selectedNode;
                        selectedNode = selectedNode.getRight();
                        if (selectedNode == null)
                        {
                            tempNodeR.setRight(new TreeNode(IntegerList[i],null,null));
                            //selectedNode = selectedNode.getRight();
                            escape = true;
                        }
                        else
                            escape = false;
                        break;
                    case -1:    //Left
                        TreeNode tempNodeL = selectedNode;
                        selectedNode = selectedNode.getLeft();
                        if (selectedNode == null)
                        {
                            tempNodeL.setLeft(new TreeNode(IntegerList[i],null,null));
                            //selectedNode = selectedNode.getLeft();
                            escape = true;
                        }
                        else
                            escape = false;
                        break;
                }
            } while (escape == false);
        }
    }

    /**
     * Helper method to decide if the value is smaller or greater than the current node.
     * @param Value The value to check.
     * @param Node  The Node to check the value on.
     * @return  Right (1) if the value is greater, Left (-1) if the value is smaller.
     */
    private int DecideDirection(int Value, TreeNode Node)
    {
        if (Value > Integer.parseInt(Node.getValue().toString()))
            return 1; //Right
        else
            return -1; //Left
    }

    public void delete(Comparable target)
// post: deletes a node with data equal to target, if present,
//       preserving binary search tree property
    {
        IntegerTree = deleteHelper(IntegerTree, target);
    }

    private TreeNode deleteHelper(TreeNode node, Comparable target)
// pre : node points to a non-empty binary search tree
// post: deletes a node with data equal to target, if present,
//       preserving binary search tree property
    {
        if (node == null)
            throw new NoSuchElementException();

        else if (target.compareTo(node.getValue()) == 0)
        {
            return deleteTargetNode(node);
        }
        else if (target.compareTo(node.getValue()) < 0)
        {
            node.setLeft(deleteHelper(node.getLeft(), target));
            return node;
        }
        else //target.compareTo(root.getValue()) > 0
        {
            node.setRight(deleteHelper(node.getRight(), target));
            return node;
        }
    }

    private TreeNode deleteTargetNode(TreeNode target)
// pre : target points to node to be deleted
// post: target node is deleted preserving binary search tree property
    {
        if (target.getRight() == null)
        {
            return target.getLeft();
        }
        else if (target.getLeft() == null)
        {
            return target.getRight();
        }
        else if (target.getLeft().getRight() == null)
        {
            target.setValue(target.getLeft().getValue());
            target.setLeft(target.getLeft().getLeft());
            return target;
        }
        else // left child has right child
        {
            TreeNode marker = target.getLeft();
            while (marker.getRight().getRight() != null)
                marker = marker.getRight();

            target.setValue(marker.getRight().getValue());
            marker.setRight(marker.getRight().getLeft());
            return target;
        }
    }


}
