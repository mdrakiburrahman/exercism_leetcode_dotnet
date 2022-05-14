using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

// var height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
// 6
// var height = new int[] { 4, 2, 0, 3, 2, 5 };
// 9
// var height = new int[] { 4, 2, 3};
// 1
var height = new int[] { 5, 4, 1, 2};
// 1
var volume = sol.Trap(height);
Console.WriteLine($"Water volume: {volume}");

public class Solution {
     public int Trap(int[] height) {
       var left_max = new int[height.Length];
       var right_max = new int[height.Length];

        var curr_max = 0;
        for (int i = 0; i < height.Length; i++) {
            if (height[i] > curr_max) {
                curr_max = height[i];
            }
            left_max[i] = curr_max;
        }

        curr_max = 0;
        for (int i = height.Length - 1; i >= 0; i--) {
            if (height[i] > curr_max) {
                curr_max = height[i];
            }
            right_max[i] = curr_max;
        }

        int water = 0;
        for (int i = 0; i < height.Length; i++) {
            water += Math.Min(left_max[i], right_max[i]) - height[i];
        }
        
        return water;
    }
}