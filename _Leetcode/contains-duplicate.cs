public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var l = new Dictionary<int, bool>();
        for (int i = 0; i <= nums.Length - 1; i++)
        {
            if(l.ContainsKey(nums[i]))
            {
                return true;
            } else {
                l.Add(nums[i], true);
            }
        }
        return false;
    }
}