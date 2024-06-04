using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;
/*
 * Custom Circular Linked List Class (slightly altered from singly linked list class used in COSC3407 Assignment 2 Question 5)
*/
namespace CircularLinkedList
{
    public class CircularLinkedList
    {
        int capacity;
        int size;
        public Node? head = null;
        public CircularLinkedList(int capacity) // initlializes Circular linked list with user desired amount of nodes
        {
            this.capacity = capacity;
            FillList();
        }

        // fills circular linked list nodes with values of either 0 or 1
        private void FillList()
        {
            Random rand = new Random();
            while (Size() != capacity)
            {
                Add(rand.Next(0,2));
            }
        }

        public bool Add(int item)
        {

            if (head == null)
            {
                head = new Node(item);
                head.next = head;
            }
            else
            {
                if (Size() == capacity)
                {
                    return false;
                }
                else
                {
                    Node currNode = head;
                    Node addNode = new Node(item);
                    for (int j = 0; j < Size(); j++)
                    {
                        if (currNode.next == head)
                        {
                            addNode.next = currNode.next;
                            currNode.next = addNode;
                            return true;
                        }
                        else
                        {
                            currNode = currNode.next;
                        }
                    }
                }
            }
            return true;
        }
        public bool IsFull()
        {
            return Size() == capacity;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
        public int Size()
        {
            int counter = 0; //initializes a counter to 0

            if (head == null) //if the head is null, returns the initial 0 of the counter
            {
                return counter;
            }
            else
            {
                Node curr = head; //sets the curr points to the head and the counter to 1
                counter = 1;

                while (curr.next != head) // while the next value in the list is not null, its adds one to the counter, then increases the curr pointer 1 spot.
                {
                    counter += 1;
                    curr = curr.next;
                }
            }
            return counter;
        }
        public int Remove()
        {
            int saveVal;
            if (IsEmpty())
            {
                return -1;
            }
            else
            {
                Node? currNode = head;
                for (int i = 0; i < Size(); i++) //iterates through the list with the currNode. 
                {
                    if (head.next == head)
                    {
                        saveVal = currNode.value;
                        head = null;
                        return saveVal;
                    }
                    else if (currNode.next.next == head)
                    {
                        saveVal = currNode.next.value;
                        currNode.next = head;
                        return saveVal;
                    }
                    else
                    {
                        currNode = currNode?.next;
                    }
                }
            }
            return -1;
        }

        public void PrintLinkedList()
        {
            Node currNode = head;
            for (int i = 0; i < Size(); i++)
            {
                if (currNode == head)
                {
                    Console.WriteLine("Head(index 0) = " + currNode.value);
                    currNode = currNode.next;
                }
                else
                {
                    Console.WriteLine($"{i} = " + currNode.value + ",");
                    if (currNode.next != head)
                    {
                        currNode = currNode.next;
                    }
                    else
                    {
                        Console.WriteLine($"End of the line. next val is the head  (head = {currNode.next.value})");
                        break;
                    }
                }

            }
            Console.WriteLine();
        }


        // Victimize implements the Second Chance Algorithm
        // we loop through every value in the list. 
        // If the value at user specifed index is 0, we change it to 1
        // if 1, we change it to 0 and check if the next node has a value of 1 or 0
        // and apply the same logic
        public void Victimize(int[] victimArr)
        {
            Node currNode = head;
            int counter = 0;
            for (int i = 0; i < victimArr.Length; i++)
            {
                while (true)
                {
                    if(counter == victimArr[i])
                    {
                        if(currNode.value == 0)
                        {
                            Console.WriteLine($"Changed value at index {counter} from 0 to 1"); // these Console writes show which index got altered and to what. Written for ease of trace.
                            currNode.value = 1;
                            break;
                        }
                        else
                        {
                            while (currNode.value != 0)
                            {
                                Console.WriteLine($"Changed value at index {counter} from 1 to 0");
                                currNode.value = 0;
                                currNode = currNode.next;
                                counter++;
                            }
                            Console.WriteLine($"Changed value at index {counter} from 0 to 1");
                            currNode.value = 1;
                            break;
                        }
                    }
                    else
                    {
                        currNode = currNode.next;
                        counter++;
                    }
                    if (counter == capacity)
                    {
                        counter = 0;
                    }
                }
            }
        }
    }
}
