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
    public ListNode ReverseList(ListNode head) {
        if (head == null || head.next == null)
            return head;
        
        ListNode newHead = ReverseList(head.next);
        
        head.next.next = head; // Make the next node point backwards
        head.next = null; // Set to null, next stack call with make it point to parent like so^
            
        return newHead;
    }
}