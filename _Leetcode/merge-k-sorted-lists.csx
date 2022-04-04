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
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode head = new ListNode();
        ListNode tail = head;

        int l = LowestNonNullIndex(lists);
        
        while (l != -1) // Non-null ListNodes exist in list
        {
            tail.next = lists[l]; // Point to next lowest
            lists[l] = lists[l].next; // Move list head along
            tail = tail.next; // Move tail to new tail
            l = LowestNonNullIndex(lists); // Get next index
        }
        return head.next; // Shift head once from placeholder
    }
    
    // Returns the index of the ListNode that has the lowest itneger value, filters null ListNodes
    // -1 means everything is null
    public int LowestNonNullIndex (ListNode[] lists)
    {
        int lowest = int.MaxValue;
        int lowest_index = -1;
        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null && lists[i].val < lowest)
            {
                lowest = lists[i].val;
                lowest_index = i;
            }
        }
        return lowest_index;
    }
}