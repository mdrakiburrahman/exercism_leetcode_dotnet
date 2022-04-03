public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var answer = new int[nums.Length]; // [0, ..., 0]
        var numZeros = 0; // Counter for zeros
        int totalProduct = 1;
        // Loop over to get products, ignore zero - deal seperately
        foreach(int n in nums)
        {
            if (n != 0)
            {
                totalProduct *= n;
            } else {
                numZeros++;
            }
        }
        // Special case of multiple zeros
        if (numZeros >= 2)
        {
            return answer; // [0, ..., 0]
        }
        // Fill up answer, numZeros <= 1 going forward;
        for(int i = 0; i < nums.Length; i++)
        {
            if (numZeros != 0) // Have that one zero
            {
               if (nums[i] == 0) // That one zero
                {
                    answer[i] = totalProduct; // Product as is
                } 
                // Else, keep everything as zero
            } else { 
                // No zeros in our array, deal with as usual
                answer[i] = (int)((double)totalProduct * System.Math.Pow(nums[i], -1));
            }
        }
        return answer;
    }
}