public class Solution {
    public int FindMin(int[] nums) {
        // Not rotated
        if (nums[0] < nums[nums.Length-1])
            return nums[0];
        
        // Find pivot and return
        int pivot = FindPivot(nums, 0, nums.Length-1);
        return nums[pivot];
    }
    
    public int FindPivot(int[] arr, int L, int H)
    {
        if(H < L) // Error-handling
            return -1;
        if (H == L) // At pivot
            return L;
        
        int M = (L+H)/2; // Split array in half
        
        // Case: Found pivot on the right
        // e.g. [.., 7, 0, ...]
        //           ^
        //           |
        //           M
        if (arr[M] > arr[M+1])
        {
            return M+1;
        }
        
        // Case: Sitting on the pivot
        // e.g. [.., 7, 0, ...]
        //              ^
        //              |
        //              M
        if (arr[M-1] > arr[M]) 
        {
            return M;
        }
        
        // Note: No "pivot on the left" because number could always be smaller!
        
        // e.g. [5, ... , 6, ...]
        //       ^        ^
        //       |        |
        //       L        M
        if (arr[M] > arr[L])
            return FindPivot(arr, M+1, H); // Pivot on the left somewhere
        
        // e.g. [9, ..., 0, ... , 6, ...]
        //       ^                ^
        //       |                |
        //       L                M
        if (arr[M] < arr[L])
            return FindPivot(arr, L, M-1); // Pivot on the left somewhere   
        
        return -1;
    }
}
var s = new Solution();
Console.WriteLine(s.FindMin(new int[] {2,3,4,5,1}));