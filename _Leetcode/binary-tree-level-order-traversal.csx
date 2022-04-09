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
    List<IList<int>> levels = new List<IList<int>> ();
    
    public IList<IList<int>> LevelOrder(TreeNode root) {
        if (root == null)
            return levels;
        
        helper(root, 0); // Start at level zero
        return levels;
    }
    
    public void helper (TreeNode node, int level) {
        // Check if current level is present
        if (levels.Count == level) // zero index
            levels.Add(new List<int>());
        // Add current node to level
        (levels[level]).Add(node.val);
        // Recurse next level children
        if (node.left != null) // Since return is void we do the null check here
            helper(node.left, level + 1);
        if (node.right != null) // Since return is void we do the null check here
            helper(node.right, level + 1);        
    }
}

// Iterative
// Time: O(n) 
// Space: O(n) - the output of ints

public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        Queue<TreeNode> Q = new Queue<TreeNode>(); // Tracking level entries
        List<IList<int>> l = new List<IList<int>> (); // Result

        if (root == null)
            return l;

        int curr_level = 0; // Start from top, this will track the level we're in now
        Q.Enqueue(root);

        while (Q.Count != 0)
        {
            if(l.Count != curr_level + 1) // No list item for current level node values
                l.Add(new List<int>());

            int level_length = Q.Count; // Number of elements in current level to process

            // Dequeue current level values, but not beyond that
            // We're going to be adding next level in queue so level_length is a snapshot
            for (int i = 0; i < level_length; i++)
            {
                TreeNode node = (TreeNode)Q.Dequeue();
                l[curr_level].Add(node.val);
                
                if (node.left != null)
                    Q.Enqueue(node.left);
                if (node.right != null)
                    Q.Enqueue(node.right);
            }
            curr_level++; // Process next level
        }
        
        return l;
    }
}