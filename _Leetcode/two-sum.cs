public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var Dict = new Dictionary<int,int>() {};
                
        for(int i = 0; i < nums.Length; i++)
        {
            // If complement is there, return
            if (Dict.ContainsKey(target - nums[i]))
            {
                return new int[] {i, Dict[target - nums[i]]};
            }
            // Add number and index
            if (!Dict.ContainsKey(nums[i]))
            {
                Dict.Add(nums[i], i);
                //Console.WriteLine($"{nums[i]}, {Dict[nums[i]]}");
            }
        }
        return new int[] {0,0}; // Shouldn't get to here since solution is guaranteed
    }
}