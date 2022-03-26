using System;
using System.Collections.Generic;

namespace LinkedList
{
    // Node Class
    public class Node
    {
        public int data; // Data in current node
        public Node next; // Next node
        public Node(int i) // Constructor
        {
            this.data = i; 
            this.next = null; // Initialize next node to null
        }
        public void Print() // Print entire chain
        {
            if (this.next != null)
            {
                Console.Write($"| {this.data} |->");
                this.next.Print(); // Recurse
            } else {
                Console.Write($"| {data} ||\n");
            }
        }
        public void AddToEnd(int data)
        {
            if (this.next == null) // At the end
            {
                this.next = new Node(data); // Add new node
            } else {
                this.next.AddToEnd(data); // Recurse
            }
        }
        public void AddSorted(int data)
        {
            if (this.next == null)
            {
                this.next = new Node(data);
            } else if (data < this.next.data) // In the correct spot
            {
                var temp = new Node(data);
                temp.next = this.next; // Point to next node
                this.next = temp; // Point to new node
            } else {
                this.next.AddSorted(data); // Recurse
            }
        }
        // Note that it is guaranteed that prevNode is not null
        public bool RemoveIfExists(int data, Node prevNode)
        {
            if (this.data == data) // Found
            {
                prevNode.next = this.next; // Point prev node to next node - removing this node from chain
                return true;
            } else if (this.data != data & this.next == null) // At the end, still not found
            {
                return false;
            } else
            {
                return this.next.RemoveIfExists(data, this); // Recurse
            }
        }
    }
    
    // List of Nodes Class
    public class MyList
    {
        public Node headNode; // Head node
        public MyList()
        {
            this.headNode = null; // Initialize head node to null
        }
        public void AddToStart(int data)
        {
            if (this.headNode == null)
            {
                this.headNode = new Node(data); // Add new node
            } else {
                var tempNode = new Node(data); // Create new node
                tempNode.next = this.headNode; // Set next node to current head node
                this.headNode = tempNode; // Set head node to new node
            }
        }
        public void AddToEnd(int data)
        {
            if (this.headNode == null)
            {
                this.headNode = new Node(data); // Add new node
            } else {
                this.headNode.AddToEnd(data); // Add via Node Class
            }
        }
        public void AddSorted(int data)
        {
            if (this.headNode == null)
            {
                this.headNode = new Node(data); // Add new node
            } else if (this.headNode.data > data) // If data is smaller than head
            {
                AddToStart(data); // Add to start
            } else {
                this.headNode.AddSorted(data); // Add via Node Class
            }
        }
        public bool RemoveIfExists(int data)
        {
            if (this.headNode == null)
            {
                return false; // List is empty
            } else if (this.headNode.data == data) // Found at head
            {
                this.headNode = this.headNode.next;
                return true;
            } else { // Not found at head
                return this.headNode.next.RemoveIfExists(data, this.headNode); // Remove via Node Class
            }
        }
        public void Print()
        {
            if (this.headNode != null)
            {
                this.headNode.Print(); // Print via Node Class
            }
        }
        public List<int> GetValues()
        {
            var list = new List<int>();
            if (this.headNode == null)
            {
                return list;
            }
            list.Add(this.headNode.data); // Add head node
            var currNode = this.headNode.next;
            while (currNode != null)
            {
                list.Add(currNode.data); // Add next node
                currNode = currNode.next; // Move to next node
            }
            return list;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            list.AddSorted(9);
            list.AddSorted(5);
            list.AddSorted(7);
            list.AddSorted(11);
            list.AddSorted(13);
            list.Print();

            // Get values
            var values = list.GetValues();
            Console.WriteLine(string.Join(", ", values));

            // Start removing
            list.RemoveIfExists(9); // In the middle
            list.Print();
            list.RemoveIfExists(13); // In the end
            list.Print();
            list.RemoveIfExists(5); // Head
            list.Print();
            list.RemoveIfExists(11); 
            list.RemoveIfExists(7); 
            list.RemoveIfExists(99); // Should not error
            
            values = list.GetValues(); // Should not error
            
            list.Print(); // Empty list
        }
    }
}