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
public class Solution {
    // Bottom up
    public int MaxDepth(TreeNode root) {
        if (root == null)
            return 0;
        
        int left_max = MaxDepth(root.left);
        int right_max = MaxDepth(root.right);
        
        return Math.Max(left_max, right_max) + 1;
    }
}