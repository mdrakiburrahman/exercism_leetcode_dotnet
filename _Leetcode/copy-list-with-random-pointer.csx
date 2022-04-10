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

// Recursive
// Time Complexity: O(n)
// Space Complexity: O(n) - for our dictionary
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

// Iterative
// Time Complexity: O(n) - our while loop
// Space Complexity: O(n) - for our dictionary

public class Solution {
    
    Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    
    public Node CopyRandomList(Node root) {
        if (root == null)
            return null;
        
        var oldNode = root;                    // Iter node - original
        var newNode = new Node(oldNode.val);   // Iter node - new
        visited.Add(oldNode, newNode);
        
        while (oldNode != null)
        {
            newNode.next = getCached(oldNode.next);
            newNode.random = getCached(oldNode.random);
            
            oldNode = oldNode.next;
            newNode = newNode.next;
        }
        
        return visited[root]; // Return the new root
    }
    
    public Node getCached(Node node)
    {
        if (node == null)
            return null;
        
        if (visited.ContainsKey(node))
        {
            return visited[node];
        } else {
            var newNode = new Node(node.val);
            visited.Add(node, newNode);
            return newNode;
        }
        return null;
    }
}
