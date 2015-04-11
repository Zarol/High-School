/**
 * Created with IntelliJ IDEA. User: 295893 Date: 2/5/13 Time: 9:23 AM To change this template use File | Settings |
 * File Templates.
 */
public class Main {

    /**
     *  Sorting Template:
     *  Provides a main method for access to the sorting menu
     *
     * @param  args  The command line arguments - not used
     */
    public static void main(String[] args)
    {
        Sorts testMerge = new Sorts();

        System.out.println("Filling list a");
        int[] a = testMerge.fillArray();
        System.out.println();
        System.out.println("Filling list b");
        int[] b = testMerge.fillArray();

        int[] c = new int[a.length + b.length];

        testMerge.selectionSort(a);
        testMerge.selectionSort(b);
        testMerge.merge(a,b,c);

        System.out.println();
        System.out.println("list a:  ");;
        testMerge.screenOutput(a);
        System.out.println();
        System.out.println();
        System.out.println("list b:  ");;
        testMerge.screenOutput(b);
        System.out.println();
        System.out.println();
        System.out.println("list c:  ");;
        testMerge.screenOutput(c);
        System.out.println();
    }
}
