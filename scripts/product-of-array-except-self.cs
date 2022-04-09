public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var answer = new int[nums.Length]; // [0, ..., 0]
        
        // Calculate left products
        answer[0] = 1; // Nothing to the left
        
        for(int i = 1; i < nums.Length; i++) // Left to right
        {
            answer[i] = answer[i-1] * nums[i-1]; 
        }        
        
        var R = 1; // Running product from right
        
        for (int i = nums.Length-1; i >= 0; i--) // Right to left
        {
            answer[i] = answer[i] * R;
            R = nums[i] * R;
        }
        return answer;
    }
}