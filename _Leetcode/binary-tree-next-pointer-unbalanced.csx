/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    
    // prev - in the next level, previous pointer we have that needs a .next
    // leftmost - when we go into a next level (prev == null); we use this to track leftmost node
    Node prev, leftmost;
    
    public Node Connect(Node root) {
        if (root == null)
            return root;
        
        // For first level, root is leftmost since it's alone
        leftmost = root;
        
        // curr tracks the fronting node at parent level
        Node curr = leftmost;
        
        // We will make sure leftmost tracks FIRST child (not necessarily the left) in next node always, so we loop until it is null - null means we are done
        while (leftmost != null) // Loop per level
        {
            // prev tracks the just recent child on the children level
            // curr tracks the on top of parent on the parent level
            this.prev = null; // Every level, we reset this
            curr = leftmost; // Start
            
            // We reset this, because it'll be set in processChild
            // If there is no Child and nothing is set, this null breaks us out of the while loop
            leftmost = null;
            
            // Iterate in the current level thanks to the next pointers
            while (curr != null)
            {
                // Process both children and also update prev and leftmost in here
                processChild(curr.left);
                processChild(curr.right);
                
                // Move
                curr = curr.next;
            }
        }
        return root;
    }
    
    // As a parent (with nexts established), we setup the child with all the next links here
    public void processChild (Node child)
    {
        if (child != null)
        {
            // If we have a prev, we're going through a level
            if (prev != null)
            {
                prev.next = child; // Point prev to this child
            } else { // First child in level
                leftmost = child; // Point for upcoming
            }
            prev = child; // Move along
        }
    }
}