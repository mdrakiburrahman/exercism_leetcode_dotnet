using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

// [9,9,9,9,9,9,9]
ListNode h1 = new ListNode(9);
h1.next = new ListNode(9);
h1.next.next = new ListNode(9);
h1.next.next.next = new ListNode(9);
h1.next.next.next.next = new ListNode(9);
h1.next.next.next.next.next = new ListNode(9);
h1.next.next.next.next.next.next = new ListNode(9);

// [9,9,9,9]
ListNode h2 = new ListNode(9);
h2.next = new ListNode(9);
h2.next.next = new ListNode(9);
h2.next.next.next = new ListNode(9);

// [8,9,9,9,0,0,0,1]
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
        return h3;
    }
}