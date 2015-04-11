/**
 * This Node class is designed to contain an Object and point to another Node.
 *
 * Author: Saharath Kleips
 * Date: 12/12/12
 * All Rights Reserved ©
 */
public class Node {
    private Object n;       //The value this Node will hold.
    private Node next;      //The value of the next Node this Node will hold.

    /**
     * Constructor method for Class Node.
     * @param n     The Object value to be contained.
     */
    public Node(Object n) {
        this.n = n;
        this.next = null;
    }

    /**
     * Constructor method for Class Node.
     * @param n     The Object value to be contained.
     * @param next  The next node the current node will point to.
     */
    public Node(Object n, Node next) {
        this.n = n;
        this.next = next;
    }

    /**
     *  The getter method for variable n of type Object.
     * @return      The Object value contained within the current Node.
     */
    public Object getValue()
    {
        return this.n;
    }

    /**
     * The setter method for variable n of type Object.
     * @param n     The Object value to be contained within the current Node.
     */
    public void setValue(Object n)
    {
        this.n = n;
    }

    /**
     * The getter method for variable next of type Node.
     * @return      The Node value contained within the current Node.
     */
    public Node getNext()
    {
        return this.next;
    }

    /**
     * The setter method for variable next of type Node.
     * @param newNext       The Node value to be contained within the current Node.
     * @return              The Node value contained within the current Node.
     */
    public Node setNext(Node newNext)
    {
        this.next = newNext;
        return this.next;
    }
}
