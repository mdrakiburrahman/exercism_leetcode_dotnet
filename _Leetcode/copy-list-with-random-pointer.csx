/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    
    Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    
    public Node CopyRandomList(Node root) {
        
        if (root == null)
            return root;
        
        if (visited.ContainsKey(root))
            return visited[root];

        var newRoot = new Node(root.val);
        // We add the newRoot into the dict by reference.
        visited.Add(root, newRoot);
        
        // Recursively grab and update, the beauty is our dict reference above is also getting updated since value is by reference
        newRoot.next = CopyRandomList(root.next);
        newRoot.random = CopyRandomList(root.random);
        
        return newRoot;
    }
}