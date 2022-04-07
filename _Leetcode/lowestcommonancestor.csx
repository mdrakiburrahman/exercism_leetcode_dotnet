/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    
    TreeNode lowestAncestor;
    int best_depth;
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
            return null;
        
        // Start off assuming root if we find nothing better
        lowestAncestor = root;
        best_depth = 0;
        
        // Recursion will update if better answer is found
        RootHasVal(root, p.val, q.val, 0);
        
        return lowestAncestor;
    }
    
    public bool RootHasVal(TreeNode root, int p, int q, int depth)
    {
        if (root == null)
            return false;
        
        // Check current node - if any found, set true
        bool curr = root.val == p || root.val == q;
        
        // Recurse
        bool left = RootHasVal(root.left, p, q, depth + 1);
        bool right = RootHasVal(root.right, p, q, depth + 1);
        
        // If at least 2/3 true - we found a good candidate
        if (left && right || left && curr || curr && right)
            
            if (depth > best_depth) // Beat previous score
                lowestAncestor = root;   
        
        // True if any of the three are true - so we can use this info up the call stack
        // We only update answer based on high score so this is fine
        return left || right || curr;
    }
}