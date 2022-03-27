using System;
using System.Collections.Generic;

public class Node<T>
{
    public T data;
    public Node<T> next;
    public Node<T> prev;
    public Node(T i)
    {
        data = i;
        next = null;
        prev = null;
    }
}

public class List<T>
{
    public Node<T> head;
    public Node<T> tail;
    public List()
    {
        // If we ever run into a situation where head OR tail are null, we will use newNode to set both
        head = null;
        tail = null;
    }
}

public class Deque<T>
{
    private List<T> list;

    public Deque()
    {
        list = new List<T>();
    }

    // Inset value at back
    public void Push(T value)
    {
        // Create a new node with value
        Node<T> newNode = new Node<T>(value);
        // Set newNode.prev to tail
        newNode.prev = list.tail;
        // Set newNode.next to null
        newNode.next = null;
        // Set list.tail to newNode since we're pushing at the back
        if (list.tail == null) // Empty list, append in both head and tail
        {
            list.head = newNode;
            list.tail = newNode;
        }
        else // Update previous tail to point next to newNode, and update tail
        {
            list.tail.next = newNode;
            list.tail = newNode;
        }
    }

    // Remove value from back
    public T Pop()
    {
        var value = list.tail.data;

        // Move tail back
        list.tail = list.tail.prev;

        // Check if tail is null - if not, set next to null
        if (list.tail != null)
        {
            list.tail.next = null;

        }
        else
        { // List is now empty
            list.head = null;
        }
        return value;
    }

    // Insert value at front
    public void Unshift(T value)
    {
        // Create a new node with value
        Node<T> newNode = new Node<T>(value);
        // Set newNode.prev to null
        newNode.prev = null;
        // Set newNode.next to head
        newNode.next = list.head;
        // Set list.head to newNode since we're pushing at the front
        if (list.head == null) // Empty list, append in both head and tail
        {
            list.head = newNode;
            list.tail = newNode;
        }
        else // Update previous head to point back to newNode, and update head
        {
            list.head.prev = newNode;
            list.head = newNode;
        }
    }

    // Remove value at front
    public T Shift()
    {
        var value = list.head.data;

        // Move head forward
        list.head = list.head.next;
        
        // Check if head is null - if not set prev to null
        if (list.head != null)
        {
            list.head.prev = null;
        }
        else
        { // List is now empty
            list.tail = null;
        }
        return value;
    }
}