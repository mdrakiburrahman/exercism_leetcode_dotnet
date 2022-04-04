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
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {        
        // Handle edges
        if (head.next == null && n == 1)
            return null;
        
        // Iterate till end of list
        Stack st = new Stack();
        ListNode Node = head;
        while(Node != null)
        {
            st.Push(Node);
            Node = Node.next;
        }
        
        ListNode Prev, Curr;
        int count = 0;
        
        while (count != n-1) // Backtrack till one off
        {
            st.Pop(); // Pop till n-1
            count++;
        }
        
        Curr = (ListNode)st.Pop(); // Pop n
        
        // If Stack is empty - that means we were asked to remove the first item
        if (st.Count == 0)
            return head.next;
        
        Prev = (ListNode)st.Pop(); // Pop n+1
        Prev.next = Curr.next; // Point Prev to n-1
        
        return head;
    }
}