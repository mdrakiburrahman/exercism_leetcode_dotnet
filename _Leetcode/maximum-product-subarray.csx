using System;

// Brute force - find all permutations

// public class Solution {
//     public int MaxProduct(int[] nums) {
//         int max = int.MinValue;
//         int curr = int.MinValue;
//         for (int i=0; i < nums.Length; i++)
//         {
//             curr = nums[i]; // Reset
//             max = Math.Max(max, curr);
//             for(int j = i+1; j < nums.Length; j++)
//             {
//                 curr *= nums[j];
//                 max = Math.Max(max, curr);
//             }
//         }  
//         return max;
//     }
// }

public class Solution {
    public int MaxProduct(int[] nums) {
        int max = nums[0];
        int min = nums[0];
        int curr = nums[0];
        int highest = max;
        
        // Kadane’s Algorithm
        // But we keep track of min since we can flip anytime
        for(int i = 1; i < nums.Length; i++)
        {
            curr = nums[i];
            
            /* There's 3 things we can really do:
            1. Swap to using curr
            2. Multiply current-streak max via curr, see what we get
            3. Multiply current-streak min via curr, see what we get
            
            From there, we update our highest score
            */
            
            int temp_max = Math.Max(curr, Math.Max(curr * max, curr * min)); // temp_max so we can use previous max in min
            min = Math.Min(curr, Math.Min(curr * max, curr * min));      
            max = temp_max;
            
            highest = Math.Max(max, highest); // It's the actual max so far or what we previously stored
        }
        return highest;
    }
}

var s = new Solution();

Console.WriteLine(s.MaxProduct(new int[] {2,3,-2,4}));
Console.WriteLine(s.MaxProduct(new int[] {-2, 0, -1}));
Console.WriteLine(s.MaxProduct(new int[] {-2}));
Console.WriteLine(s.MaxProduct(new int[] {-4,-3}));
Console.WriteLine(s.MaxProduct(new int[] {-2, 3, -4}));

/*
[2,3,-2,4]
[-2,0,-1]
[-2]
[-4,-3]
[-2,3,-4]
*/