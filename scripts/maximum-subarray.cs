public class Solution {
    public int MaxSubArray(int[] nums) {
        int currentSum = nums[0];
        int maxSum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            // If nums[i] is greater than currentSum, throw currentSum away since it's holding us back
            currentSum = Math.Max(nums[i], nums[i] + currentSum);
            maxSum = Math.Max(currentSum, maxSum);
        }
        return maxSum;
    }
}