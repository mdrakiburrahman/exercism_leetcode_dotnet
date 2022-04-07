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
    public Node Connect(Node root) {
        if (root == null)
            return root;
        helper(root.left, root, true);
        helper(root.right, root, false);
        return root;        
    }
    public void helper(Node root, Node dad, bool left)
    {
        if (root == null)
            return;
        if (dad == null)
            return;
        if (left)
            root.next = dad.right;
        if (!left && dad.next != null)
            root.next = dad.next.left;
        helper(root.left, root, true);
        helper(root.right, root, false);        
    }
}