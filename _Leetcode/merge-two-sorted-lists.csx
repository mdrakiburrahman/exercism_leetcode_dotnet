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

// My long solution
// public class Solution {
//     public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
       
//         // Handle nulls
//         if (list1 == null || list2 == null)
//         {
//             if (list1 == null)
//             {
//                 return list2;
//             } else if (list2 == null)
//             {
//                 return list1;
//             }
//         }
        
//         ListNode c_1; // Checkpoint for list1
//         ListNode c_2; // Checkpoint for list2
//         ListNode sortedNode; // Head for newlist
//         ListNode nextNode; // Next Node for newlist
        
//         // Figure out which list has the lower value
//         // 1. Compare list1.val and list2.val
//         // 2. sortedNode = smaller one
//         // 3. c_n = sortedNode.next, c_other = listother
//         // 4. sortedNode.next = null for fresh start
        
//         if (list1.val <= list2.val)   
//         {
//             sortedNode = list1;
//             c_1 = sortedNode.next;
//             c_2 = list2;
//         } else {
//             sortedNode = list2;
//             c_1 = list1;
//             c_2 = sortedNode.next;
//         }
//         sortedNode.next = null;
        
//         nextNode = sortedNode; // We will iterate on this
        
//         bool flag = true;
        
//         // Loop until both c_1 and c_2 become null; we're at the end
//         while(flag)
//         {   
//             if (c_1 != null && c_2 != null) // Both lists still contain items
//             {
//                 if (c_1.val <= c_2.val) // c_1 is smaller
//                 {
//                     var tuple = IterateNode(nextNode, c_1);
//                     nextNode = tuple.Item1;
//                     c_1 = tuple.Item2;
//                 } else {                // c_2 is smaller
//                     var tuple = IterateNode(nextNode, c_2);
//                     nextNode = tuple.Item1;
//                     c_2 = tuple.Item2;
//                 }
//             } else if (c_1 == null && c_2 != null) // list1 has ended, list2 has not ended
//             {
//                 nextNode.next = c_2; // Just point to next head and end it
//                 flag = false;
//             } else if (c_1 != null && c_2 == null) // list1 has not ended, list2 has ended   
//             {
//                 nextNode.next = c_1;
//                 flag = false;
//             } else if (c_1 == null && c_2 == null) // Both lists have ended
//             {
//                 flag = false;
//             }
//         }
       
//         // Console.WriteLine("New list: ");
//         // Printer(sortedNode);
        
//        return sortedNode; 
//     }
    
//     public Tuple<ListNode, ListNode> IterateNode(ListNode nextNode, ListNode c_n)
//     {
//         nextNode.next = c_n;
//         c_n = c_n.next;
//         nextNode = nextNode.next;
//         nextNode.next = null;
//         return new Tuple<ListNode, ListNode>(nextNode, c_n);
//     }
    
//     public void Printer(ListNode Node)
//     {
//         while (Node != null)
//         {
//             Console.WriteLine($"val: {Node.val}, next: {Node.next}");
//             Node = Node.next;
//         }
//     }
// }

// Leetcode solution
// Complexity: O(l1 + l2)
// Space: O(1)
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode head = new ListNode();
        ListNode tail = head;
       
        while(l1 != null && l2 != null)
        {
            if (l1.val < l2.val)
            {
                tail.next = l1;
                l1 = l1.next;
            } else {
                tail.next = l2;
                l2 = l2.next;
            }
            tail = tail.next;
        }
        // One of the lists is empty now, point tail to the remaining list containing items
        tail.next = l1 == null ? l2 : l1;
        
        return head.next; // Move head to beginning
    }
}