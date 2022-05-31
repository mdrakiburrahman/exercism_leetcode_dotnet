using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

// [2147483647]
// TreeNode r1 = new TreeNode(2147483647, null, null);

// Console.WriteLine($"r1: {sol.IsValidBST(r1)}");

// [1, 1]
TreeNode r2 = new TreeNode(1, null, null);
r2.left = new TreeNode(1, null, null);

Console.WriteLine($"r2: {sol.IsValidBST(r2)}");


/**
 * Definition for a binary tree node.
*/
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
 

// T: O(N)
// S: O(N) (Recursion stack with a skewed BST - straight line)
public class Solution {
    public bool IsValidBST(TreeNode root) {
        return ValidateBST(root, null, null); // Because Int32 bounds are included in this question - so we start off with null as bounds and update for children
    }

    public bool ValidateBST(TreeNode root, int? min, int? max) {
        if (root == null) {
            return true;
        }
        if ((min != null && root.val <= min) || (max != null && root.val >= max)) {
            return false;
        }
        return ValidateBST(root.left, min, root.val) && ValidateBST(root.right, root.val, max);
    }
}j