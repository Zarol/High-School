/**
 * Created with IntelliJ IDEA. User: 295893 Date: 2/5/13 Time: 9:16 AM To change this template use File | Settings |
 * File Templates.
 */
import java.util.*;
public class Sorts {

    private long steps;

    /**
     * Default Constructor
     */
    Sorts()
    {
        steps = 0;
    }

    /**
     * Gets the amount of steps an algorithm takes to sort
     * @return  The amount of steps an algorithm takes to sort.
     */
    public long getStepCount()
    {
        return steps;
    }

    /**
     * Sets the amount of steps it takes to sort a list
     * @param stepCount The amount of steps it takes.
     */
    public void setStepCount(int stepCount)
    {
        steps = stepCount;
    }

    /**
     * This method will sort a list using bubble sort.
     * Larger numbers will be pushed to the top of the list until the list is sorted.
     * @param list A list of integers to be sorted.
     */
    public void bubbleSort(int[] list)
    {
        boolean flag = true;
        int temp;

        while (flag)
        {
            flag = false;
            for(int i = 0; i < list.length - 1; i++)
            {
                if (list[i] > list[i+1])
                {
                    temp = list[i];
                    list[i] = list[i+1];
                    list[i + 1] = temp;
                    flag = true;
                    steps++;
                }
            }
        }
    }

    /**
     * This method will sort a list using insertion sort.
     * Smaller numbers are removed from the list, and the list is shifted over until
     * it is not smaller than the left number. It "inserts" it into the right spot.
     * @param list
     */
    public void insertionSort(int[] list)
    {
        for (int outer = 1; outer < list.length; outer++)
        {
            int position = outer;
            int key = list[position];
            while (position > 0 && list[position-1] > key)
            {
                list[position] = list[position-1];
                position--;
            }
            list[position] = key;
        }
    }

    /**
     * This method will recursively sort a list using merge sort.
     * The list is broken down into smaller sub-sections and then sorted
     * with respect to the smaller list. The smaller lists are then merged
     * back together.
     * @param a The list of integers.
     * @param first The first index of the array.
     * @param last  The last index of the array.
     */
    public void mergeSort(int[] a, int first, int last)
    {
        int mid;
        int temp;

        if (first == last)
        {
            if (first + 1 == last)
            {
                if (a[first] > a[last])
                {
                    swap (a, first, last);
                }
            }

        }
        else
        {
            mid = (first + last) / 2;
            mergeSort(a, first, mid);
            mergeSort(a, mid+1, last);
            merge(a,first,mid,last);
        }
    }

    /**
     * This method will merge different parts of an array.
     * @param numbers   The array of integers.
     * @param first The first index of the array.
     * @param mid   The middle index of the array.
     * @param last  The last index of the array.
     */
    void merge(int numbers[], int first, int mid, int last)
    {
        int APart = first;
        int BPart = mid + 1;
        int CPart = first;
        int Total = last - first + 1;
        int temp;
        boolean finishA = false;
        boolean  finishB = false;
        int list[] = new int[numbers.length];
        for( int i = 0; i < numbers.length; i++)
        {
            list[i] = numbers[i];
        }

        for (temp = 1; temp <= Total; temp++)
        {
            if (finishA)
            {
                list[CPart] = numbers[BPart];
                BPart++;
            }
            else if (finishB)
            {
                list[CPart] = numbers[APart];
                APart++;
            }
            else if (numbers[APart] < numbers[BPart])
            {
                list[CPart] = numbers[APart];
                APart++;
            }
            else
            {
                list[CPart] = numbers[BPart];
                BPart++;
            }
            CPart++;
            if (APart > mid)
            {
                finishA = true;
            }
            if (BPart > last)
            {
                finishB = true;
            }
        }

        for (temp = first; temp <= last; temp++)
        {
            numbers[temp] = list[temp];
        }

    }

    /**
     * This method will recursively sort an array using quick sort.
     * A pivot point will be selected and numbers of the left and right
     * bound will be compared to each other until they can be swapped
     * with each other.
     * @param a The array of integers.
     * @param first The first index of the array.
     * @param last  The last index of the array.
     */
    public void quickSort(int[] a, int first, int last)
    {
        int index = quickSortHelper(a, first, last);
        if (first < index - 1)
            quickSort(a, first, index - 1);
        if (index < last)
            quickSort(a, index, last);
    }

    /**
     * Helper method designed to do the actual pivoting of quick sort.
     * @param a The array of integers.
     * @param left  The first index of the array.
     * @param right The last index of the array.
     * @return
     */
    private int quickSortHelper(int[] a, int left, int right)
    {
        int i = left;
        int j = right;
        int temp;
        int pivotPoint = a[(left + right) / 2];

        while (i <= j)
        {
            while (a[i] < pivotPoint)
                i++;
            while (a[j] > pivotPoint)
                j--;
            if (i <= j)
            {
                temp = a[i];
                a[i] = a[j];
                a[j] = temp;
                i++;
                j--;
            }
        }
        return i;
    }

    /**
     * This method will sort an array using selection sort.
     * The list is divided into two parts and will pick the smallest
     * value to place into the first part of the list.
     * @param list  The array of integers.
     */
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

    /**
     * Helper method designed to swap two indexes in a list.
     * @param list  The list of integers.
     * @param A The value of the first integer.
     * @param B The value of the second integer.
     */
    private void swap(int list[], int A, int B)
    {
        int C = list[A];
        list[A] = list[B];
        list[B] = C;
    }

    /**
     * Fills the array to be used in sorting.
     * @return A randomly filled array of integers.
     */
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
