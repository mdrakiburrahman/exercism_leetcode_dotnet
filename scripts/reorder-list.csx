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

// Time = O(n)
// Space = O(n)

public class Solution {
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null)
            return;
            
        // Fill up stack so we can empty backwards
        Stack st = new Stack();
        ListNode p2 = head;
        int n = 0;
        while (p2 != null)
        {
            st.Push(p2);
            p2 = p2.next;
            n++;
        }
        
        // n contains the length of the list now
        ListNode p1 = head.next;    // One from head
        p2 = (ListNode)st.Pop();    // From back
        ListNode temp = head;
        
        bool flag = true; // Flag to switch back and forth
        for(int i = 0; i < n; i++)
        {
            if (flag)
            {
                temp.next = p2; 
                temp = temp.next;
                p2 = (ListNode)st.Pop(); // Shift p2 back
                
                flag = false;
            } else {
                temp.next = p1;
                temp = temp.next;
                p1 = p1.next;  // Shift p1 forward
                
                flag = true;
            }
        }
        temp.next = null; // Last node 
    }
}