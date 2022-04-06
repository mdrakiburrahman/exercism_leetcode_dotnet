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
    int count = 0;
    public int CountUnivalSubtrees(TreeNode root) {
        if (root == null)
            return 0;
        
        if (root.left == null && root.right == null)
            return 1; // Single node, is leaf
        
        bool left = helper(root.left, root.val);
        bool right = helper(root.right, root.val);
        
        if (left && right && root.left.val == root.val && root.right.val == root.val)
        {
            count++;
        }
        
        return count;
    }
    public bool helper(TreeNode root, int val)
    {
        if(root == null)
            return false;
        
        if (root.right == null && root.left == null) // leaf
        {
            count++;
            return true;
        }

        Console.WriteLine($"{root.val} == {val}");
        
        bool left = true;
        if (root.left != null)
            left = helper(root.left, val);
        
        bool right = true;
        if (root.right != null)
            right = helper(root.right, val);
        
        if (left && right && root.val == val)
        {
            count++;
            return true;
        }
        return false;
    }
}


// Bookmark April 8th night: https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/538/