/**
 *  Disk is designed to hold all the properties of a Disk within the Towers of Hanoi problem.
 *  The only property of a Disk is it's size in relation to other disks as represented
 *  with an integer value. A low integer value represents a small disk and a large integer
 *  value represents a large disk.
 *
 * Author: Saharath Kleips
 * Date: 01/09/13
 * All Rights Reserved ©
 */
public class Disk {
    private int size; //Declares the size of disk in relation to others

    /**
     *  Class constructor specifying the size of the Disk in relation to other Disks
     */
    public Disk(int size)
    {
        this.size = size;
    }

    /**
     * This method returns the size of the Disk in relation to other Disks.
     * @param
     * @return int
     */
    public int getSize()
    {
        return this.size;
    }

}
