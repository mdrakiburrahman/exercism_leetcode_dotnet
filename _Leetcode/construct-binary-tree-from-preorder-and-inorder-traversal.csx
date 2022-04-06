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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if (preorder.Count() == 0 && inorder.Count() == 0)
            return null;
        
        // We know preorder[0] is guaranteed to be root of subarray
        TreeNode root = new TreeNode(preorder[0]);
        
        // Where to split both arrays
        int mid = Array.FindIndex(inorder, item => item == root.val);
        
        int preorder_length = preorder.Length;
        int inorder_length = inorder.Length;
        
        // Create left and right subtrees
        root.left = BuildTree(preorder.Skip(1).Take(mid).ToArray(), inorder.Skip(0).Take(mid).ToArray());
        root.right = BuildTree(preorder.Skip(mid+1).Take(preorder_length-mid-1).ToArray(), inorder.Skip(mid+1).Take(inorder_length-mid-1).ToArray());
        
        return root;
    }
}