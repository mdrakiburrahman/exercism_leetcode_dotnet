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