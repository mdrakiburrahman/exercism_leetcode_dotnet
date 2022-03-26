using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public List<T> List { get; } // List of items in the Linked List
    private int _index; // Index of the current item in the Linked List
    public SimpleLinkedList(T value)
    {
        this.List = new List<T> { value }; // Create a list of type T with the value passed in
    }
    public SimpleLinkedList(IEnumerable<T> values)
    {
        this.List = values.ToList(); // Convert to list since we know it's already an IEnumerable<T>
    }
    public T Value // Get current node's value
    { 
        get
        {
           var val = List[_index];
           _index = 0; // Reset index, otherwise it will keep incrementing during the "next" iteration since we are changing index
            return val;
        } 
    }
    public SimpleLinkedList<T> Next
    { 
        get
        {
            _index++; // Increment the index
            return _index >= List.Count ? null : this; // Return null if we're at the end of the list, else return reference to self
        } 
    }
    public SimpleLinkedList<T> Add(T value)
    {
        List.Add(value);
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator() // Enumerable
    {
       return GetEnumerator(); // Grabs the Enumerator<T>
    }

    public IEnumerator<T> GetEnumerator() // Enumerator
    {
        return List.GetEnumerator(); // A list comes built in with an IEnumerator<T>
    }
}