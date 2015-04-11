/**
 * TowersOfHanoi is designed to emulate the puzzle "Towers of Hanoi" and solve it.
 *
 * Author: Saharath Kleips
 * Date: 01/09/13
 * All Rights Reserved ©
 */
public class TowersOfHanoi {
    private static int timesSolved = 0;     //The amount of times the solution method is iterated
    private StackOfDisks towerOne, towerTwo, towerThree;        //The 3 towers in the puzzle
    private int numberOfDisks;      //The total number of disks in the puzzle

    /**
     * A default constructor that initializes TowersOfHanoi
     */
    public TowersOfHanoi()
    {
        this.towerOne = new StackOfDisks();
        this.towerTwo = new StackOfDisks();
        this.towerThree = new StackOfDisks();
        this.numberOfDisks = 4;
        this.addInitialDisks(numberOfDisks);
    }

    /**
     * Class constructor specifying the number of disks in the Towers of Hanoi problem
     */
    public TowersOfHanoi(int numberOfDisks)
    {
        this.towerOne = new StackOfDisks();
        this.towerTwo = new StackOfDisks();
        this.towerThree = new StackOfDisks();
        this.numberOfDisks = numberOfDisks;
        this.addInitialDisks(this.numberOfDisks);
    }

    /**
     * This method is part of the Towers of Hanoi initialization process. It creates the specified
     * number of Disks into the first Tower of Hanoi. This method should only be called after
     * a Constructor method has been called. This method does not reset the problem, it simply
     * adds the required number of Disks to begin the problem.
     * @param numberOfDisks The total number of disks within the Towers of Hanoi problem
     * @see StackOfDisks
     * @see Disk
     */
    private void addInitialDisks(int numberOfDisks)
    {
        //The for loop starts at max and decreases to put the largest size Disk on the bottom of the stack
        for(int i = numberOfDisks; i > 0; i--)
        {
            towerOne.pushDisk(new Disk(i));
        }
    }

    /**
     * This method determines which solution method to use. This method should only be called once after
     * the Towers of Hanoi problem has been initialized. The solution will mutate the current data and
     * should only be called when there is no need or the original problem and a solution is requested.
     */
    public void solve()
    {
        this.move(this.numberOfDisks,this.towerOne,this.towerTwo,this.towerThree);
    }

    /**
     * This method provides a recursive solution to the three tower version of the Towers of Hanoi
     * with any number of Disks. This method is designed to mutate each tower representation and should
     * only be called once. It will return nothing but will solve the Towers of Hanoi adhering to
     * its rules all the way through and will only exit with the final result.
     * @param numberOfDisks The number of disks within the entire Towers of Hanoi problem
     * @param towerOne  The first StackOfDisks represented as the first Tower of Hanoi
     * @param towerTwo  The second StackOfDisks represented as the second Tower of Hanoi
     * @param towerThree    The third StackOfDisks represented as the third Tower of Hanoi
     * @see StackOfDisks
     * @see Disk
     */
    private void move(int numberOfDisks, StackOfDisks towerOne, StackOfDisks towerTwo, StackOfDisks towerThree)
    {
        //If n = 1
            //disk = tower1.pop
            //tower3.push(disk)
        //else
            //move(n-1,t1,t3,t2)
            //move(1,t1,t2,t3)
            //move(n-1,t2,t1,t3)
        //end
        timesSolved++;
        System.out.println(timesSolved);
        if(numberOfDisks == 1)
        {
            Disk temporaryDisk = towerOne.popDisk();
            towerThree.pushDisk((temporaryDisk));
        }
        else
        {
            move(numberOfDisks - 1, towerOne, towerThree, towerTwo);
            move(1,towerOne,towerTwo,towerThree);
            move(numberOfDisks - 1, towerTwo, towerOne, towerThree);
        }
    }

    /**
     * This method generates a graphical representation of the current status of the Towers of Hanoi.
     * This graphical representation will be displayed as ASCII values and outputted
     * to the console. Each tower along with its disks will be displayed.
     */
    private void displayTowers()
    {
        //IMPLEMENT IT.
        int value1 = 0;
        int value2 = 0;
        int value3 = 0;
        for(int i = 0; i < this.numberOfDisks; i++)
        {
            System.out.println("---" + value1 + "---" + value2 + "---" + value3 + "---");
        }
    }

    /**
     * This method returns the first Tower of Hanoi represented by a StackOfDisks.
     * @return StackOfDisks     The first tower in the puzzle.
     */
    public StackOfDisks getTowerOne() {
        return towerOne;
    }

    /**
     * This method returns the second Tower of Hanoi represented by a StackOfDisks.
     * @return StackOfDisks     The second tower in the puzzle.
     */
    public StackOfDisks getTowerTwo() {
        return towerTwo;
    }

    /**
     * This method returns the third Tower of Hanoi represented by a StackOfDisks.
     * @return StackOfDisks     The third tower in the puzzle.
     */
    public StackOfDisks getTowerThree() {
        return towerThree;
    }

    /**
     * This method returns the total number of disks within this version of the problem.
     * @return int      The total number of disks within the puzzle.
     */
    public int getNumberOfDisks() {
        return numberOfDisks;
    }
}
