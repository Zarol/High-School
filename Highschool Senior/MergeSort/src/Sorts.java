/**
 * Created with IntelliJ IDEA. User: 295893 Date: 2/5/13 Time: 9:16 AM To change this template use File | Settings |
 * File Templates.
 */
import java.util.*;
public class Sorts {

    public void selectionSort(int[] list)
    {
        int min, temp;

        for (int outer = 0; outer < list.length - 1; outer++)
        {
            min = outer;
            for (int inner = outer + 1; inner < list.length; inner++)
            {
                if (list[inner] < list[min])
                {
                    min = inner;
                }
            }
            //swap(list[outer], list[flag]);
            temp = list[outer];
            list[outer] = list[min];
            list[min] = temp;
        }
    }

    public void merge(int[] a, int[] b, int[] c)
    {
        int indexA = 0, indexB = 0;
        for(int i = 0; i < c.length; i++)
        {
            if (indexA >= a.length)
            {
                c[i] = b[indexB];
                indexB++;
            }
            else if(indexB >= b.length)
            {
                c[i] = a[indexA];
                indexA++;
            }
            else if(a[indexA] < b[indexB])
            {
                c[i] = a[indexA];
                indexA++;
            }
            else
            {
                c[i] = b[indexB];
                indexB++;
            }
        }
    }

    public int[] fillArray()
    {
        Scanner console = new Scanner(System.in);

        System.out.println();
        System.out.print("How many numbers do you wish to generate? ");
        int numInts = console.nextInt();

        int[] temp = new int[numInts];

        System.out.print("Largest integer to generate? ");
        int largestInt = console.nextInt();

        Random randGen = new Random();

        for (int loop = 0; loop < temp.length; loop++)
        {
            temp[loop] = randGen.nextInt(largestInt) + 1;
        }

        return temp;
    }

    /**
     *  prints out the contents of the array in tabular form, 20 columns
     */
    public void screenOutput(int[] temp)
    {
        for (int loop = 0; loop < temp.length; loop++)
        {
            if (loop % 15 == 0)
            {
                System.out.println();
            }
            System.out.print(temp[loop] + " ");
        }
        System.out.println();
    }
}
