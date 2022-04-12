using System.Text.RegularExpressions;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null)
            return "";
        
        string s = "";
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count != 0)
        {
            // Check if everything in queue is null
            // If so, we are at the end and left with null leaves
            bool allNull = true;
            foreach (TreeNode n in q)
            {
                if (n != null) // Not at the end
                {
                    allNull = false;
                    break;
                }
            }
            
            if (!allNull)
            {
                TreeNode temp = q.Dequeue();
                if (temp != null)
                {
                    s += temp.val.ToString() + ",";
                    q.Enqueue(temp.left);
                    q.Enqueue(temp.right);
                } else {
                    s += "null,";
                }
            } else {
                break;
            }
        }
        
        s = s.Substring(0, s.Length-1); // Remove trailing comma
        
        return s;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        string[] nodes = Regex.Split(data, ",");       
        
        if (nodes.Length == 1 && (nodes[0] == "null"|| string.IsNullOrEmpty(nodes[0])))
            return null;
        
        if (nodes.Length == 1 && nodes[0] != "null")
            new TreeNode(Int32.Parse(nodes[0]));
        
        Dictionary<int, TreeNode> cache = new Dictionary<int, TreeNode>(); // [index, TreeNode]
        
        int left = 0, right = 0; // Pointers
        
        TreeNode n = new TreeNode(Int32.Parse(nodes[left]));
        TreeNode newHead = n;
        cache[left] = n; // Cache
        
        right = left + 1;
        
        while (right < nodes.Length)
        {
            n = cache[left]; // Initiate loop
   
            if (nodes[right] != "null")
            {
                n.left = new TreeNode(Int32.Parse(nodes[right]));
                cache[right] = n.left;
            } else {
                cache[right] = null;
            }
            
            right++;
            
            if (right < nodes.Length && nodes[right] != "null") // [1, 2] can error, so we check if right is OOB.
            {
                n.right = new TreeNode(Int32.Parse(nodes[right]));
                cache[right] = n.right;
            } else {
                cache[right] = null;
            }
            
            right++;
            left++;
            
            while (left < nodes.Length && nodes[left] == "null") // left goes to next non-null for next loop
            {   
                left++;   
            }
            
        }
    
        return newHead;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));