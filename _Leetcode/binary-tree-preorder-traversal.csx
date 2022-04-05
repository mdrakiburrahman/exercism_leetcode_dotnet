/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
// Recursive
// Time: O(n)
// Space: O(n)
public class Solution {
    
    List<int> l = new List<int>();
    
    public IList<int> PreorderTraversal(TreeNode root) {
        // Base case
        if (root == null)
            return l;
        l.Add(root.val);

        // Recurse
        PreorderTraversal(root.left);
        PreorderTraversal(root.right);
        return l;
    }
}

// Iterative
// Time: O(n)
// Space: O(n) // The output list

public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> l = new List<int>();
        Stack st = new Stack();
        
        if (root == null)
            return l;
        
        st.Push(root);
        TreeNode node;                    

        while (st.Count != 0)
        {
            node = (TreeNode)st.Pop();
            l.Add(node.val); // Add root - 1
            
            if (node.right != null)
                st.Push(node.right); // Stack is LIFO - this comes out 3
            
            if (node.left != null)
                st.Push(node.left); // This comes out 2, i.e. pre-order
        }
        return l;
    }
}