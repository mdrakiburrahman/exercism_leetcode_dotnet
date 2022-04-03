public class Solution {
    public int MaxProfit(int[] prices) {
        int low = int.MaxValue; // Start at a high number to override
        int high = 0;
        int profit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            if(prices[i] < low)
            {
                low = prices[i];
                high = 0; // The moment we update low, high resets
                
            } else if (prices[i] > high)
            {
                high = prices[i];
            }
            if (high - low > profit)
            {
                profit = high - low;
            }
        }
        return profit;
    }
}