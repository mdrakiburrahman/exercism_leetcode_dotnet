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
    List<int> res = new List<int> ();
    public IList<int> PostorderTraversal(TreeNode root) {
        // Base case
        if (root == null)
            return res;
        
        // Incremental work
        PostorderTraversal(root.left); // Visit left
        PostorderTraversal(root.right); // Visit right
        res.Add(root.val); // Visit node
        
        return res;
    }
}

// https://www.youtube.com/watch?v=Zv14sK2kvtQ
// https://www.youtube.com/watch?v=xLQKdq0Ffjg
// Complicated!

// Iterative
// Time: O(n)
// Space: O(n)

public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> res = new List<int> ();
        Stack st = new Stack();
        
        TreeNode curr = root;
        TreeNode prev = null; // Pointing to previous
        while (curr != null || st.Count != 0)
        {
            if (curr != null)
            {
                st.Push(curr); 
                curr = curr.left;
            } else
            {
                TreeNode temp = ((TreeNode)st.Peek()).right; // Check for right child in top of stack
                if (temp == null) // Right child is empty
                {
                    temp = (TreeNode)st.Pop();
                    res.Add(temp.val);
                    while(st.Count != 0 && temp == ((TreeNode)st.Peek()).right)
                    {
                        temp = (TreeNode)st.Pop();
                        res.Add(temp.val);
                    }
                } else {
                    curr = temp;
                }
            }
        }
        return res;
    }
}