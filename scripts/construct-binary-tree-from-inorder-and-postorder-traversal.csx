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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        if (postorder.Count() == 0 && inorder.Count() == 0)
            return null;
        
        // We know postorder[0] is guaranteed to be root of subarray
        TreeNode root = new TreeNode(postorder[postorder.Length-1]);
        
        // Where to split both arrays at root
        int mid = Array.FindIndex(inorder, item => item == root.val);
        
        // Create left and right subtrees
        // po[0:mid], io[0:mid]
        root.left = BuildTree(inorder.Skip(0).Take(mid).ToArray(), postorder.Skip(0).Take(mid).ToArray());
        
        // po[mid:length-1], io[mid+1:]
        root.right = BuildTree(inorder.Skip(mid+1).Take(inorder.Length-mid-1).ToArray(), postorder.Skip(mid).Take(postorder.Length-1-mid).ToArray());
        
        return root;
    }
}