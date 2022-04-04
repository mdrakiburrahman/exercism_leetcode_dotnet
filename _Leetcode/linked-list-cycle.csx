/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */

// Iterative
// Time: O(n)
// Space: O(n)
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null)
            return false;
        var set = new HashSet<ListNode>();
        set.Add(head);
        ListNode NextNode = head.next;
        while (NextNode != null)
        {
            if(set.Contains(NextNode))
                return true;
            set.Add(NextNode);
            NextNode = NextNode.next;
        }
        return false;
    }
}

// Tortoise and Haire
// Time: O(n)
// Space: O(1)
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null)
            return false;
        ListNode slow = head;
        ListNode fast = head.next;
        // Fast will get to the end first - if there is an end
        while(fast != null && fast.next != null) //If both these are true, we're not at the end yet
        {
            slow = slow.next; // One step
            fast = fast.next.next; // Two steps
            if (fast == slow)
                return true; // Collision
        }
        return false;
    }
}