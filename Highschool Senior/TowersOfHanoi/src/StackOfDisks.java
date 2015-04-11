import java.util.ArrayList;

/**
 *  StackOfDisks is designed to hold a stack of disks and represents a "Tower" of Hanoi.
 *  It provides methods for putting Disks onto the stack and popping disks off of the stack.
 *
 * Author: Saharath Kleips
 * Date: 01/09/13
 * All Rights Reserved ©
 */
public class StackOfDisks {
    private ArrayList<Disk> listDisks; //Creates a new ArrayList of type Disk

    /**
     *  A default constructor that initializes StackOfDisks
     */
    public StackOfDisks()
    {
        listDisks = new ArrayList<Disk>();  //Initializes the listDisks ArrayList to a new ArrayList
    }

    /**
     * This method will put a disk into the first index of the ArrayList and push other Disks
     * over one index. The method will not return anything upon adding the Disk into the
     * ArrayList.
     * @param disk  The Disk that needs to be pushed into the ArrayList
     * @see Disk
     */
    public void pushDisk(Disk disk)
    {
        listDisks.add(0, disk);
    }

    /**
     * This method will remove the Disk from the first index, return it, and shift all other
     * Disks one index left. The class will not keep a copy of the removed data one it has
     * been popped.
     * @return Disk     The Disk that was in the first index of the ArrayList.
     * @see Disk
     */
    public Disk popDisk()
    {
        Disk temporaryDisk = listDisks.get(0);
        listDisks.remove(0);
        return temporaryDisk;
    }
}
