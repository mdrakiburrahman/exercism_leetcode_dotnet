/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

/*
Stack based
Time = O(2n) = O(n) - because we have to backtrack from the end
Space = O(n) - because we are not using any extra space
*/
// public class Solution {
//     public ListNode RemoveNthFromEnd(ListNode head, int n) {        
//         // Handle edges
//         if (head.next == null && n == 1)
//             return null;
        
//         // Iterate till end of list
//         Stack st = new Stack();
//         ListNode Node = head;
//         while(Node != null)
//         {
//             st.Push(Node);
//             Node = Node.next;
//         }
        
//         ListNode Prev, Curr;
//         int count = 0;
        
//         while (count != n-1) // Backtrack till one off
//         {
//             st.Pop(); // Pop till n-1
//             count++;
//         }
        
//         Curr = (ListNode)st.Pop(); // Pop n
        
//         // If Stack is empty - that means we were asked to remove the first item
//         if (st.Count == 0)
//             return head.next;
        
//         Prev = (ListNode)st.Pop(); // Pop n+1
//         Prev.next = Curr.next; // Point Prev to n-1
        
//         return head;
//     }
// }

// Time: O(n) - one pass thanks to 2 pointers
// Space: O(1) - no extra space asides from 2 pointers

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {     
        ListNode l, f; // leader, follower
        f = head;
        for (int i = 0; i < n; i++)
        {
            f = f.next;
        }
        
        if (f == null)
            return head.next; // n = length of list, remove first item
            
        l = head;
        while(f.next != null) // We get f to the last node
        {
            f = f.next;
            l = l.next;
        }
        l.next = l.next.next; // Skip over n
            
        return head;
    }   
}