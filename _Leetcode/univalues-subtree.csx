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

// Time: O(n)
// Space: O(1)

public class Solution {
    public int count = 0;
    public int CountUnivalSubtrees(TreeNode root) {
        helper(root);
        return count;
    }
    
    public Tuple<bool, int> helper(TreeNode root)
    {
        // Null cannot be U.S.
        if (root == null)
        {
            return Tuple.Create(true, int.MinValue); // We report true to parent but down count the null
        }
        
        // Leaf is always U.S.
        if (root.right == null && root.left == null)
        {
            count++;
            return Tuple.Create(true, root.val);
        }
        
        // Check left and right
        var left = helper(root.left);
        var right = helper(root.right);
        
        Console.WriteLine($"root: {root.val}");
        Console.WriteLine($"left: <{left.Item1}, {left.Item2}>");
        Console.WriteLine($"right: <{right.Item1}, {right.Item2}>");
        
        // If left and right, and the value matches, we have a U.S. at the root
        if(left.Item1 && right.Item1) // If both children report not false
        {
            // If reported values match or are int.MinValue (only one child to root)
            if ((left.Item2 == root.val || left.Item2 == int.MinValue) && (right.Item2 == root.val || right.Item2 == int.MinValue))
            {
                count++;
                return Tuple.Create(true, root.val);   
            }
        }
            
        return Tuple.Create(false, int.MinValue);
    }
}