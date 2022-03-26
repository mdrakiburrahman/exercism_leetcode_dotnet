using System.Linq;
using Xunit;
using System;
using System.Collections.Generic;
using LinkedList;

public class SimpleLinkedListTests
{
    [Fact]
    public void Add_single_item_start()
    {
        var list = new MyList();
        list.AddToStart(1);
        Assert.Equal(new List<int>() {1}, list.GetValues());
    }
    [Fact]
    public void Add_couple_item_end()
    {
        var list = new MyList();
        list.AddToStart(1);
        list.AddToEnd(2);
        Assert.Equal(new List<int>() {1, 2}, list.GetValues());
    }
    [Fact]
    public void Add_several_sorted()
    {
        var list = new MyList();
        list.AddSorted(9);
        list.AddSorted(5);
        list.AddSorted(7);
        list.AddSorted(11);
        list.AddSorted(13);
        Assert.Equal(new List<int>() {5, 7, 9, 11, 13}, list.GetValues());
    }
    [Fact]
    public void Add_remove_empty()
    {
        var list = new MyList();
        // Add
        list.AddSorted(9);
        list.AddSorted(5);
        list.AddSorted(7);
        list.AddSorted(11);
        list.AddSorted(13);
        // Remove out of order
        list.RemoveIfExists(9);
        list.RemoveIfExists(13);
        list.RemoveIfExists(5);
        list.RemoveIfExists(11); 
        list.RemoveIfExists(7); 
        list.RemoveIfExists(99); 
        Assert.Equal(new List<int>(), list.GetValues());
    }
}