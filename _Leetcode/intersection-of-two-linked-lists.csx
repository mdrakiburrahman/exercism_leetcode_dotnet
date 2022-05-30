using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

// Intersection point
// [8, 4, 5]
ListNode h3 = new ListNode(8);
h3.next = new ListNode(4);
h3.next.next = new ListNode(5);

// [4, 1, h3]
ListNode h1 = new ListNode(4);
h1.next = new ListNode(1);
h1.next.next = h3;

// [5, 6, 1, h3]
ListNode h2 = new ListNode(5);
h2.next = new ListNode(6);
h2.next.next = new ListNode(1);
h2.next.next.next = h3;

// [h3]
ListNode c1 = sol.GetIntersectionNode(h1, h2);

/**
 * Definition for singly-linked list.
**/
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
public class Solution {

    // T: O( N + M )
    // S: O( 1 )
    public ListNode GetIntersectionNode(ListNode h1, ListNode h2) {
        ListNode p1 = h1;
        ListNode p2 = h2;  
        while (p1 != p2){
            p1 = p1 == null ? h2 : p1.next;
            p2 = p2 == null ? h1 : p2.next;
        }
        return p1;
    }
    
    // T: O( N + M )
    // S: O(N or M)
    
    // public ListNode GetIntersectionNode(ListNode h1, ListNode h2) {
    //     // Null checks
    //     if (h1 == null || h2 == null)
    //         return null;
        
    //     // Loop over h1 and cache it in a dictionary
    //     var dict = new Dictionary<ListNode, bool>();

    //     ListNode curr = h1;
    //     while (curr != null)
    //     {
    //         dict[curr] = true;
    //         curr = curr.next;
    //     }

    //     // Loop over h2 and check if any of the nodes are the dictionary - if so return it
    //     curr = h2;

    //     while (curr != null)
    //     {
    //         if (dict.ContainsKey(curr))
    //         {
    //             return curr;
    //         } else {
    //             curr = curr.next;
    //         }
    //     }

    //     // No intersections found
    //     return null;
    // }
}