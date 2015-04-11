/**
 * Created with IntelliJ IDEA. User: 295893 Date: 4/16/13 Time: 9:18 AM To change this template use File | Settings |
 * File Templates.
 */
import java.util.*;
public class Main {
    public static void main(String[] args)
    {
        Stack myStack = new Stack();
        Scanner myScanner = new Scanner(System.in);
        int userInput = -1;
        do
        {
            System.out.print("Type '1' to push, '2' to pop, '3' to display: ");
            userInput = myScanner.nextInt();
            switch (userInput)
            {
                case 1:
                    System.out.print("Enter the value to push: ");
                    myStack.push(new TreeNode(myScanner.nextInt(),null,null));
                    break;
                case 2:
                    System.out.println("The value has been popped: " + myStack.pop().getValue().toString());
                    break;
                case 3:
                    System.out.println("Displaying Values...");
                    myStack.display();
                    break;
                default:
                    userInput = -1;
                    break;
            }
        } while ( userInput != -1 );
        System.out.println("Thank you for using.");
    }
}
