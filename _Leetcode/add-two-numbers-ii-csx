using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

// [7,2,3,3]
ListNode h1 = new ListNode(7);
h1.next = new ListNode(2);
h1.next.next = new ListNode(4);
h1.next.next.next = new ListNode(3);

// [5,6,4]
ListNode h2 = new ListNode(5);
h2.next = new ListNode(6);
h2.next.next = new ListNode(4);

// [7,8,0,7]
ListNode h3 = sol.AddTwoNumbers(h1, h2);

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
    public ListNode AddTwoNumbers(ListNode h1, ListNode h2) {
        h1 = ReverseList(h1);
        h2 = ReverseList(h2);

        int rem = 0;
        int sum = 0;

        ListNode h3 = new ListNode();
        ListNode curr = h3;

        while (h1 != null || h2 != null || rem != 0) {
            sum = rem;

            if (h1 != null)
            {
                sum += h1.val;
                h1 = h1.next;
            }
            if (h2 != null)
            {
                sum += h2.val;
                h2 = h2.next;
            }

            curr.val = sum % 10;
            rem = sum / 10;

            if (h1 != null || h2 != null || rem != 0)
            {
                curr.next = new ListNode();
                curr = curr.next;
            }
        }
        return ReverseList(h3);
    }
    public ListNode ReverseList(ListNode head) {
        if (head == null || head.next == null)
            return head;
        
        ListNode newHead = ReverseList(head.next);
        
        head.next.next = head; // Make the next node point backwards
        head.next = null; // Set to null, next stack call with make it point to parent like so^
            
        return newHead;
    }
}