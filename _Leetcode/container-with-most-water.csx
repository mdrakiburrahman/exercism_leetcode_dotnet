/*

Brute force
public class Solution {
    public int MaxArea(int[] height) {
        int max = int.MinValue;
        int curr = 0;
        for (int i = 0; i < height.Length; i++)
        {
            for (int j = i+1; j < height.Length; j++)
            {
                curr = Math.Min(height[i], height[j]) * (j-i);
                if (curr > max)
                    max = curr;
            }
        }
        return max;
    }
}
*/

public class Solution {
    public int MaxArea(int[] height) {
        int max = 0;
        int l = 0;
        int r = height.Length-1;
        
        while (l < r)
        {
            max = Math.Max(max, Math.Min(height[l], height[r]) * (r-l)); // Take the bigger one
            // Move shorter bar in with hope of finding a bigger bar
            if (height[l] < height[r])
            {
                l++;
            } else {
                r--;
            }
        }
        return max;
    }
}