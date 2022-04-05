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
    List<int> l = new List<int> ();
    public IList<int> InorderTraversal(TreeNode root) {
        if (root == null)
            return l;
        
        InorderTraversal(root.left);
        l.Add(root.val);
        InorderTraversal(root.right);
        
        return l;
    }
}

// Iterative
// Time: O(n)
// Space: O(n)
public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> res = new List<int> ();
        Stack st = new Stack ();
        
        TreeNode curr = root;
        
        while (curr != null || st.Count != 0) // if either is true we have work left to do
        {
            // In order - iterate all the way down+left
            while (curr != null)
            {
                st.Push(curr);
                curr  = curr.left;
            }
            curr = (TreeNode)st.Pop(); // Next item to process from Stack
            res.Add(curr.val);
            curr = curr.right; // Iterate right
        }
        return res;
    }
}