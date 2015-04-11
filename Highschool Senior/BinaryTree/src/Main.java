/**
 * Created with IntelliJ IDEA. User: 295893 Date: 2/26/13 Time: 9:34 AM To change this template use File | Settings |
 * File Templates.
 */
import java.util.Scanner;
public class Main {
    public static void main(String[] args)
    {
        int[] Integers = new int[12];
        Integers[0] = 54;
        Integers[1] = 32;
        Integers[2] = 21;
        Integers[3] = 88;
        Integers[4] = 3;
        Integers[5] = 99;
        Integers[6] = 17;
        Integers[7] = 77;
        Integers[8] = 82;
        Integers[9] = 29;
        Integers[10] = 44;
        Integers[11] = 66;
        BinaryTree TestTreeBuilder = new BinaryTree(Integers);
        TestTreeBuilder.PrintCanvas();
        System.out.println("Inorder Traversal");
        TestTreeBuilder.inorder(TestTreeBuilder.GetTree());
        System.out.println();
        System.out.println("Preorder Traversal");
        TestTreeBuilder.preorder(TestTreeBuilder.GetTree());
        System.out.println();
        System.out.println("Preorder Traversal");
        TestTreeBuilder.postorder(TestTreeBuilder.GetTree());
        System.out.println();
        System.out.println("By Level");
        TestTreeBuilder.levelorder(TestTreeBuilder.GetTree());
        System.out.println();
        Scanner scanner = new Scanner(System.in);
        System.out.print("Please enter the INTEGER to find: ");
        int userInput = scanner.nextInt();
        TreeNode found = TestTreeBuilder.find(TestTreeBuilder.GetTree(), userInput);
        if (found != null)
            System.out.println("FOUND!");
        else
            System.out.println("Not found :[");
        testDelete(TestTreeBuilder);
    }
    public static void testDelete(BinaryTree temp)
    {
        int idToDelete;
        boolean success;
        Scanner scanner = new Scanner(System.in);

        System.out.println("Testing delete algorithm...");
        System.out.print("Enter Id value to delete: ");
        idToDelete = scanner.nextInt();
        temp.delete(idToDelete);
        System.out.println(idToDelete + " was deleted");
    }

}
