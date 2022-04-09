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
    public bool IsSymmetric(TreeNode root) {
        if (root == null)
            return true;
        
        if (root.left == null && root.right == null)
            return true;
        
        if (root.left == null && root.right != null)
            return false;
        
        if (root.left != null && root.right == null)
            return false;
        
        return checkSymmetric(root.left, root.right);
    }
    public bool checkSymmetric(TreeNode yin, TreeNode yang)
    {
        // Base case
        if (yin == null && yang == null)
            return true;
        
        if (yin == null && yang != null)
            return false;
        
        if (yin != null && yang == null)
            return false;
        
        if (yin.val == yang.val)
        {
            bool left = checkSymmetric(yin.right, yang.left);
            bool right = checkSymmetric(yin.left, yang.right);
            
            return left && right;
        } 
        return false;       
    }
}