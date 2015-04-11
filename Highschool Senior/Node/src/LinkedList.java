/**
 * This LinkedList class is designed to hold an array of Node that will point to the next Node in the array.
 *
 * Author: Saharath Kleips
 * Date: 12/12/12
 * All Rights Reserved ©
 */
public class LinkedList {
    private Node[] array;       //The array that will hold all the Nodes within LinkedList.
    private int size;           //The size of array.

    /**
     * Default constructor for Class LinkedList
     */
    public LinkedList()
    {
        this.size = 0;
        this.array = new Node[size];
        this.initialize();
    }

    /**
     * Constructor for Class LinkedList
     * @param size      The specified size of the list.
     */
    public LinkedList (int size)
    {
        this.size = size;
        this.array = new Node[size];
        this.initialize();
    }

    /**
     * Constructor helper method to initialize the Node array within LinkedList.
     */
    private void initialize()
    {
        for(int i = 0; i < size; i++)
        {
            this.array[i] = new Node(0,null);
        }
        this.createLink();
    }

    /**
     * This method will dynamically expand the list and add a Node to the end of that list.
     * @param n     The Node to be added to the end of the list.
     */
    public void addNode(Node n)
    {
        this.expandList();
        this.array[size - 1] = n;
        this.createLink(size - 2);
    }

    /**
     * This method will insert the value of Node at an index and push all other Nodes right.
     * @param n         The new Node that will be inserted
     * @param index     The index of the Node to be inserted
     */
    public void insertNode(Node n, int index)
    {
        //TO BE IMPLEMENTED
    }

    /**
     * This method will replace the value of Node at an index with a new Node.
     * @param n         The new Node that will be replacing.
     * @param index     The index of the Node that wishes to be replaced.
     */
    public void replaceNode(Node n, int index)
    {
        this.array[index].setValue(n.getValue());
    }

    /**
     * This method will remove the last Node in the list and shrink the list.
     * @return      The Node that is removed.
     */
    public Node removeNode()
    {
        Node returned =  this.array[this.size - 1];
        this.array[this.size - 1] = null;
        contractList();
        createLink(size - 1);

        return returned;
    }


    /**
     * This method will remove the Node at an index and retain the size of the list.
     * @param index     The index of the Node to be removed.
     * @return          The Node that is removed.
     */
    public Node removeNode(int index)
    {
        Node returned = new Node(this.array[index].getValue(),this.array[index].getNext());
        this.array[index].setValue("");
        return returned;
    }

    /**
     * This method will remove the Node at an index and shift the list.
     * @param index     The index of the Node to be removed.
     * @return          The Node that is removed.
     */
    public Node removeShiftNode(int index)
    {
        Node returned = new Node(this.array[index].getValue(),this.array[index].getNext());
        this.array[index] = null;
        contractList();
        createLink(index - 1);

        return returned;
    }

    /**
     * This method will set all data within the list to null.
     */
	public void deleteAll()
	{
		this.array = new Node[1];
        this.size = 1;
        initialize();
	}

    /**
     * The getter method for the array of Node within the list.
     * @return  All Nodes within the list as an array.
     */
	public Node[] getAllNodes()
	{
		return this.array;
	}

    /**
     * The getter method for a Node at a specific index of type Node.
     * @param index         The index of the node within the list.
     * @return              The entire Node at the specified index.
     */
    public Node getNode(int index)
    {
        return this.array[index];
    }

    /**
     * The getter method for variable size of type int.
     * @return      The total number of indexes within the list.
     */
    public int getSize()
    {
        return this.size;
    }


    public void formattedPrint()
    {
        int valueFormat = 1;
        for(int i = 0; i < this.size; i++)
        {
            int temp = array[i].getValue().toString().length() + 2;
            if(temp > valueFormat)
                valueFormat = temp + 2;
        }
        int indexFormat = 7;
        for(int i = 0; i < this.size; i++)
        {
            int temp = ("" + i).length() + 2;
            if(temp > indexFormat)
                indexFormat = temp + 2;
        }
        int nodeFormat = 6;
        for(int i = 0; i < this.size; i++)
        {
            int temp = array[i].toString().length() + 2;
            if(temp > nodeFormat)
                nodeFormat = temp + 2;
        }


        System.out.print(String.format("%1$-" + indexFormat + "s", "Index"));
        System.out.print(String.format("%1$-" + nodeFormat + "s", "Node"));
        System.out.print(String.format("%1$-" + valueFormat + "s", "Value"));
        System.out.print("Pointer");
        System.out.println();
        for( int i = 0; i < this.size; i++)
        {
            System.out.print(String.format("%1$-" + indexFormat + "s", "[" + i + "]"));
            System.out.print(String.format("%1$-" + nodeFormat + "s", "[" + array[i] + "]"));
            System.out.print(String.format("%1$-" + valueFormat + "s", "[" + array[i].getValue() + "]"));
            System.out.print("[" + array[i].getNext() + "]");
            System.out.println();
        }
    }

    /**
     * This method will set every Node's pointer within the list to the next Node within that list.
     */
    private void createLink()
    {
        for(int i = 0; i < this.array.length; i++)
        {
            if (i == this.array.length - 1)
            {
                this.array[i].setNext(null);
            }
            else
            {
                this.array[i].setNext(array[i+1]);
            }
        }
    }

    /**
     * This method will set the specified Node's pointer to the next Node within the list.
     * @param index      The index of the Node to create the pointer for.
     */
    private void createLink(int index)
    {
        if ( index < 0)
        {

        }
        else if (index == this.array.length - 1)
        {
            this.array[index].setNext(null);
        }
        else
        {
            this.array[index].setNext(this.array[index+1]);
        }
    }

    /**
     * This method will increase the size of the array, allowing for more Nodes to be held.
     */
    private void expandList()
    {
        Node[] temp1 = this.array;
        Node[] temp2 = new Node[this.size + 1];

        for(int i = 0; i < this.size; i++)
        {
            temp2[i] = temp1[i];
        }

        this.array = temp2;
        this.size++;
    }

    /**
     * This method will decrease the size of the list based off empty Nodes.
     */
    private void contractList()
    {

        //REWORK TO CONTRACT BASED ON ALL NULL NODES
        //IF NULL -> SHIFT LEFT
        //LOOP UNTIL NO NULL
        Node[] temp1 = this.array;
        Node[] temp2 = new Node[this.size - 1];
        int index = -1;

        for(int i = 0; i < this.size; i++)
        {
            if (temp1[i] == null)
            {
                //Do not increase
            }
            else
            {
                index++;
                temp2[index] = temp1[i];
            }
        }
        this.array = temp2;
        this.size--;
    }
}
