/**
 * Created with IntelliJ IDEA. User: 295893 Date: 12/7/12 Time: 9:07 AM To change this template use File | Settings |
 * File Templates.
 */
import sun.security.x509.CertAttrSet;

import java.util.Random;
import java.util.*;
import java.io.*;
public class Main {

    public static void main(String[] args) throws IOException
    {
        int entry = 4;
        Random Random = new java.util.Random();

        if (entry == 0)
        {
            Node[] test = new Node[7];
            for( int i = 0; i < test.length; i++)
            {
                test[i] = new Node(Random.nextInt(), null);
            }
            for(int i = 0; i < 7; i++)
            {
                System.out.print("Node:[" + test[i] + "] ");
                System.out.print("Value:[" + test[i].getValue() + "] ");
                System.out.println("---> [" + test[i].getNext() + "] ");
            }
        }


        else if (entry == 1)
        {
            int elements = 5;
            LinkedList testList = new LinkedList();

            System.out.println("Initial List");
            for(int i = 0; i < elements; i++)
            {
                testList.addNode(new Node(i * 10));
            }

            for(int i = 0; i < testList.getSize(); i++)
            {
                System.out.println(testList.getNode(i).getValue() + " " + testList.getNode(i).getNext());
            }

            System.out.println();
            System.out.print("Removed: ");
            Node removed = testList.removeNode(2);
            System.out.println(removed.getValue() + " " + removed.getNext() + "\n");

            System.out.println("New List");
            for(int i = 0; i < testList.getSize(); i++)
            {
                System.out.println(testList.getNode(i).getValue() + " " + testList.getNode(i).getNext());
            }

        }


        else if (entry == 2)
        {
            LinkedList artistList = new LinkedList();
            LinkedList playlistList = new LinkedList();

            File artistFile = new File("S:/Apps/CS/DATA/JPWard_Assign/stream/Artists.txt");
            File playlistFile = new File("S:/Apps/CS/DATA/JPWard_Assign/stream/Playlists.txt");

            Scanner scanner = new Scanner(artistFile);

            while (scanner.hasNext() == true)
            {
                artistList.addNode(new Node(scanner.nextLine()));
            }

            scanner = new Scanner(playlistFile);
            while (scanner.hasNext() == true)
            {
                playlistList.addNode(new Node(scanner.nextLine()));
            }

            scanner.close();

            System.out.println("Artist List...");
            for( int i = 0; i < artistList.getSize(); i++ )
            {
                System.out.print(artistList.getNode(i) + " = ");
                System.out.print(artistList.getNode(i).getValue() + " --> ");
                if(artistList.getNode(i).getNext() == null)
                    System.out.println("End of File...");
                else
                    System.out.println(artistList.getNode(i).getNext());
            }
            System.out.println();
            System.out.println("Playlist List...");
            for( int i = 0; i < playlistList.getSize(); i++ )
            {
                System.out.print(playlistList.getNode(i) + " = ");
                System.out.print(playlistList.getNode(i).getValue() + " --> ");
                if(playlistList.getNode(i).getNext() == null)
                    System.out.println("End of File...");
                else
                    System.out.println(playlistList.getNode(i).getNext());
            }
        }
        else if (entry == 3)
        {
            LinkedList artistList = new LinkedList();
            LinkedList playlistList = new LinkedList();

            File artistFile = new File("S:/Apps/CS/DATA/JPWard_Assign/stream/Artists.txt");
            File playlistFile = new File("S:/Apps/CS/DATA/JPWard_Assign/stream/Playlists.txt");

            Scanner scanner = new Scanner(artistFile);

            while (scanner.hasNext() == true)
            {
                artistList.addNode(new Node(scanner.nextLine()));
            }

            scanner = new Scanner(playlistFile);
            while (scanner.hasNext() == true)
            {
                playlistList.addNode(new Node(scanner.nextLine()));
            }

            scanner.close();

            System.out.println("Artist List");
            artistList.formattedPrint();
            System.out.println("\nPlaylist List");
            playlistList.formattedPrint();
        }
        else if (entry == 4)
        {
            LinkedList artistList = new LinkedList();
            LinkedList playlistList = new LinkedList();
            File artistFile = new File("S:/Apps/CS/DATA/JPWard_Assign/stream/Artists.txt");
            File playlistFile = new File("S:/Apps/CS/DATA/JPWard_Assign/stream/Playlists.txt");
            Scanner scanner = new Scanner(artistFile);
            while (scanner.hasNext() == true)
                artistList.addNode(new Node(scanner.nextLine()));
            scanner = new Scanner(playlistFile);
            while (scanner.hasNext() == true)
                playlistList.addNode(new Node(scanner.nextLine()));

            boolean exit = false;
            boolean correctInput = false;
            boolean correctInput2 = false;
            boolean correctInput3 = false;
            scanner = new Scanner(System.in);
            char userInput;
            String userString;
            int userValue;

            System.out.println("Hello! Playlist and Artist List has been preloaded!");
            while (exit == false)
            {
                System.out.println("You may preform the following operations: " +
                        "[L]ist, [A]dd, [R]emove, [D]elete All, [E]xit");
                userInput = ' ';
                userString = "";
                userValue = 0;
                scanner = new Scanner(System.in);
                userInput = scanner.nextLine().charAt(0);
                switch (userInput)
                {
                    case 'L':
                        scanner = new Scanner(System.in);
                        System.out.println("Would you like list: [P]laylist, [A]rtist, [B]ack");
                        userInput = scanner.nextLine().charAt(0);
                        while (correctInput == false)
                        {
                            switch (userInput)
                            {
                                case 'P':
                                    playlistList.formattedPrint();
                                    System.out.println();
                                    correctInput = true;
                                    break;
                                case 'A':
                                    artistList.formattedPrint();
                                    System.out.println();
                                    correctInput = true;
                                    break;
                                case 'B':
                                    correctInput = true;
                                    break;
                                default:
                                    System.out.println("Please input a proper character (P, A, B).");
                                    correctInput = false;
                                    break;
                            }
                        }
                        correctInput = false;
                        break;
                    case 'A':
                        scanner = new Scanner(System.in);
                        System.out.println("Which list would you like to add to: [P]laylist, [A]rtist, [B]ack");
                        userInput = scanner.nextLine().charAt(0);
                        while (correctInput == false)
                        {
                            switch (userInput)
                            {
                                case 'P':
                                    System.out.print("Please enter the value to add: ");
                                    userString = scanner.nextLine();
                                    System.out.println("Would you like to: [R]eplace, [E]xpand, [B]ack");
                                    userInput = scanner.nextLine().charAt(0);
                                    while (correctInput2 == false)
                                    {
                                        switch (userInput)
                                        {
                                            case 'R':
                                                System.out.println("Please enter the index from: 0 to "
                                                        + (playlistList.getSize() - 1));
                                                userValue = scanner.nextInt();
                                                while (correctInput3 == false)
                                                {
                                                    if (userValue >= 0 && userValue <= (playlistList.getSize() - 1))
                                                    {
                                                        playlistList.replaceNode(new Node(userString),userValue);
                                                        System.out.println("Value[" + userString + "] was added to " +
                                                            "Index[" + userValue + "] of Playlist list.");
                                                        correctInput3 = true;
                                                    }
                                                    else if (userValue == -1)
                                                    {
                                                        correctInput3 = true;
                                                    }
                                                    else
                                                    {
                                                        System.out.println("Invalid. \"-1\" to go back.");
                                                        correctInput3 = false;
                                                    }
                                                }
                                                correctInput3 = false;
                                                correctInput2 = true;
                                                break;
                                            case 'E':
                                                playlistList.addNode(new Node(userString));
                                                System.out.println("Value[" + userString + "] was expanded to " +
                                                        "the end of Playlist list.");
                                                correctInput2 = true;
                                                break;
                                            case 'B':
                                                correctInput2 = true;
                                                break;
                                            default:
                                                System.out.println("Please input a proper character (R, E, B).");
                                                correctInput2 = true;
                                                break;
                                        }
                                    }
                                    correctInput2 = false;
                                    correctInput = true;
                                    break;
                                case 'A':
                                    System.out.print("Please enter the value to add: ");
                                    userString = scanner.nextLine();
                                    System.out.println("Would you like to: [R]eplace, [E]xpand, [B]ack");
                                    userInput = scanner.nextLine().charAt(0);
                                    while (correctInput2 == false)
                                    {
                                        switch (userInput)
                                        {
                                            case 'R':
                                                System.out.println("Please enter the index from: 0 to "
                                                        + (artistList.getSize() - 1));
                                                userValue = scanner.nextInt();
                                                while (correctInput3 == false)
                                                {
                                                    if (userValue >= 0 && userValue <= (artistList.getSize() - 1))
                                                    {
                                                        artistList.replaceNode(new Node(userString),userValue);
                                                        System.out.println("Value[" + userString + "] was added to " +
                                                                "Index[" + userValue + "] of Artist list.");
                                                        correctInput3 = true;
                                                    }
                                                    else if (userValue == -1)
                                                    {
                                                        correctInput3 = true;
                                                    }
                                                    else
                                                    {
                                                        System.out.println("Invalid. \"-1\" to go back.");
                                                        correctInput3 = false;
                                                    }
                                                }
                                                correctInput3 = false;
                                                correctInput2 = true;
                                                break;
                                            case 'E':
                                                artistList.addNode(new Node(userString));
                                                System.out.println("Value[" + userString + "] was expanded to " +
                                                        "the end of Artist list.");
                                                correctInput2 = true;
                                                break;
                                            case 'B':
                                                correctInput2 = true;
                                                break;
                                            default:
                                                System.out.println("Please input a proper character (R, E, B).");
                                                correctInput2 = true;
                                                break;
                                        }
                                    }
                                    correctInput2 = false;
                                    correctInput = true;
                                    break;
                                case 'B':
                                    correctInput = true;
                                    break;
                                default:
                                    System.out.println("Please input a proper character (P, A, B).");
                                    correctInput = false;
                                    break;
                            }
                        }
                        correctInput = false;
                        break;
                    case 'R':
                        scanner = new Scanner(System.in);
                        System.out.println("Which list would you like to remove from: [P]laylist, [A]rtist, [B]ack");
                        userInput = scanner.nextLine().charAt(0);
                        while (correctInput == false)
                        {
                            switch (userInput)
                            {
                                case 'P':
                                    System.out.println("Please enter the index you would like to remove from: 0 to "
                                            + (playlistList.getSize() - 1));
                                    userValue = scanner.nextInt();
                                    while (correctInput2 == false)
                                    {
                                        if (userValue >= 0 && userValue <= (playlistList.getSize() - 1))
                                        {
                                            System.out.println("Would you like to: Remove and [K]eep List Size, " +
                                                    "Remove and [C]ontract List, [B]ack");
                                            scanner = new Scanner(System.in);
                                            userInput = scanner.nextLine().charAt(0);
                                            switch (userInput)
                                            {
                                                case 'K':
                                                    System.out.println("Value["
                                                            + playlistList.removeNode(userValue).getValue() + "] " +
                                                            "was removed from Index[" + userValue + "] of Playlist list.");
                                                    correctInput2 = true;
                                                    break;
                                                case 'C':
                                                    System.out.println("Value["
                                                            + playlistList.removeShiftNode(userValue).getValue() + "] " +
                                                            "was removed from Index[" + userValue + "] of Playlist list.");
                                                    correctInput2 = true;
                                                    break;
                                                case 'B':
                                                    correctInput2 = true;
                                                    break;
                                                default:
                                                    System.out.println("Please input a proper character (K, C, B).");
                                                    correctInput2 = false;
                                                    break;
                                            }
                                        }
                                        else if (userValue == -1)
                                        {
                                            correctInput2 = true;
                                        }
                                        else
                                        {
                                            System.out.println("Invalid. \"-1\" to go back.");
                                            correctInput2 = false;
                                        }
                                    }
                                    correctInput2 = false;
                                    correctInput = true;
                                    break;
                                case 'A':
                                    System.out.println("Please enter the index you would like to remove from: 0 to "
                                            + (artistList.getSize() - 1));
                                    userValue = scanner.nextInt();
                                    while (correctInput2 == false)
                                    {
                                        if (userValue >= 0 && userValue <= (artistList.getSize() - 1))
                                        {
                                            System.out.println("Would you like to: Remove and [K]eep List Size, " +
                                                    "Remove and [C]ontract List, [B]ack");
                                            scanner = new Scanner(System.in);
                                            userInput = scanner.nextLine().charAt(0);
                                            switch (userInput)
                                            {
                                                case 'K':
                                                    System.out.println("Value["
                                                            + artistList.removeNode(userValue).getValue() + "] " +
                                                            "was removed from Index[" + userValue + "] of Artist list.");
                                                    correctInput2 = true;
                                                    break;
                                                case 'C':
                                                    System.out.println("Value["
                                                            + artistList.removeShiftNode(userValue).getValue() + "] " +
                                                            "was removed from Index[" + userValue + "] of Artist list.");
                                                    correctInput2 = true;
                                                    break;
                                                case 'B':
                                                    correctInput2 = true;
                                                    break;
                                                default:
                                                    System.out.println("Please input a proper character (K, C, B).");
                                                    correctInput2 = false;
                                                    break;
                                            }
                                        }
                                        else if (userValue == -1)
                                        {
                                            correctInput2 = true;
                                        }
                                        else
                                        {
                                            System.out.println("Invalid. \"-1\" to go back.");
                                            correctInput2 = false;
                                        }
                                    }
                                    correctInput2 = false;
                                    correctInput = true;
                                    break;
                                case 'B':
                                    correctInput = true;
                                    break;
                                default:
                                    System.out.println("Please input a proper character (P, A, B).");
                                    correctInput = false;
                                    break;
                            }
                        }
                        correctInput = false;
                        break;
                    case 'D':
                        scanner = new Scanner(System.in);
                        System.out.println("Which list would you like to delete: [P]laylist, [A]rtist, B[O]th, [B]ack");
                        userInput = scanner.nextLine().charAt(0);
                        while (correctInput == false)
                        {
                            switch (userInput)
                            {
                                case 'P':
                                    System.out.println("Please enter: [C]onfirmation. [B]ack");
                                    userInput = scanner.nextLine().charAt(0);
                                    while (correctInput2 == false)
                                    {
                                        switch (userInput)
                                        {
                                            case 'C':
                                                playlistList.deleteAll();
                                                System.out.println("Playlist list has been deleted.");
                                                correctInput2 = true;
                                                break;
                                            case 'B':
                                                correctInput2 = true;
                                                break;
                                            default:
                                                System.out.println("Please input a proper character (C, B).");
                                                correctInput2 = false;
                                                break;
                                        }
                                    }
                                    correctInput2 = false;
                                    correctInput = true;
                                    break;
                                case 'A':
                                    System.out.println("Please enter: [C]onfirmation. [B]ack");
                                    userInput = scanner.nextLine().charAt(0);
                                    while (correctInput2 == false)
                                    {
                                        switch (userInput)
                                        {
                                            case 'C':
                                                artistList.deleteAll();
                                                System.out.println("Artist list has been deleted.");
                                                correctInput2 = true;
                                                break;
                                            case 'B':
                                                correctInput2 = true;
                                                break;
                                            default:
                                                System.out.println("Please input a proper character (C, B).");
                                                correctInput2 = false;
                                                break;
                                        }
                                    }
                                    correctInput2 = false;
                                    correctInput = true;
                                    break;
                                case 'O':
                                    System.out.println("Please enter: [C]onfirmation. [B]ack");
                                    userInput = scanner.nextLine().charAt(0);
                                    while (correctInput2 == false)
                                    {
                                        switch (userInput)
                                        {
                                            case 'C':
                                                playlistList.deleteAll();
                                                artistList.deleteAll();
                                                System.out.println("Playlist & Artist list has been deleted.");
                                                correctInput2 = true;
                                                break;
                                            case 'B':
                                                correctInput2 = true;
                                                break;
                                            default:
                                                System.out.println("Please input a proper character (C, B).");
                                                correctInput2 = false;
                                                break;
                                        }
                                    }
                                    correctInput2 = false;
                                    correctInput = true;
                                    break;
                                case 'B':
                                    correctInput = true;
                                    break;
                                default:
                                    System.out.println("Please input a proper character (P, A, B).");
                                    correctInput = false;
                                    break;
                            }
                        }
                        correctInput = false;
                        break;
                    case 'E':
                        exit = true;
                        break;
                    default:
                        System.out.println("Please input a proper character (L, A, R, D, E).");
                        break;
                }
            }
        }

    }
}
