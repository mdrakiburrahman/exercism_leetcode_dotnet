public class Solution {
    public int Search(int[] nums, int target) {
        if (nums[0] < nums[nums.Length - 1]) // Not rotated - call Binary Search as usual
            return BinarySearch(nums, 0, nums.Length-1, target);
            
        // Find Pivot index
        int pivot = FindPivot(nums, 0, nums.Length-1);
        
        // Binary search the half array based on Pivot
        if (nums[pivot] <= target & target <= nums[nums.Length-1]) // Look right-half
        {
            return BinarySearch(nums, pivot, nums.Length-1, target);
        } else {
            return BinarySearch(nums, 0, pivot-1, target);
        }
        return -1; // Unsuccessful
    }
    
    // Finds index of rotation Pivot, or -1 if not rotated
    public int FindPivot(int[] arr, int L, int H)
    {
        if (H == L)
            return L;
        
        int M = (L+H) / 2;
        
        if (arr[M] > arr[M+1])
            return M+1;
        
        if (arr[M] < arr[M-1])
            return M;
        
        if (arr[L] > arr[M])
            return FindPivot(arr, L, M-1);
            
        if (arr[L] < arr[M])
            return FindPivot(arr, M+1, H);
            
        return -1;
    }
    
    // Returns index of Target - or -1
    public int BinarySearch(int [] arr, int L, int H, int target)
    {
        int M = 0;
        // https://en.wikipedia.org/wiki/Binary_search_algorithm
        while (L <= H)
        {
            M = (L+H)/2;      
            if (arr[M] < target)
            {
                L = M+1; // Look right
            } else if (arr[M] > target)
            {
                H = M-1; // Look left
            } else {
                return M; // On Target
            }            
        }
        return -1; // Unsuccessful
    }
}