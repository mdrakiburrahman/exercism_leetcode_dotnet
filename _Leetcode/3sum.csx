// Brute Force

// public class Solution {
//     public IList<IList<int>> ThreeSum(int[] nums) {
        
//         Array.Sort(nums);
        
//         var tripleList = new List<IList<int>>();
        
//         for (int i=0; i < nums.Length; i++)
//         {
//             for (int j=i+1; j < nums.Length; j++)
//             {
//                 for (int k=j+1; k < nums.Length; k++)
//                 {
//                     if ((nums[i] + nums[j] + nums[k] == 0) && i!=j && i!=k && j!=k )
//                     {
//                         var sol = new List<int> { nums[i], nums[j], nums[k] };
//                         sol.Sort();
//                         if (!ListExists(tripleList, sol))
//                             tripleList.Add(sol);
//                     }
//                 }
//             }   
//         }

//         return tripleList;        
//     }
    
//     public bool ListExists(List<IList<int>> tripleList, List<int> sol)
//     {
//         foreach(List<int> l in tripleList)
//         {
//             if (Enumerable.SequenceEqual(sol, l))
//             {
//                 return true;
//             }
//         }
//         return false;
//     }
// }

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        // Sort array, shouldn't be more than O(N)
        Array.Sort(nums);
        var res = new List<IList<int>>();
        // Loop until nums[i] > 0;  because there's no way higher values will add to 0
        for (int i=0; i < nums.Length && nums[i] <= 0; i++)
        {
            if (i == 0 || nums[i] != nums[i-1]) // Gets to second one iff first one not true, so no error
            {
                sums(nums, i, res);
            }   
        }
        return res;        
    }
    
    public void sums (int[] nums, int i, List<IList<int>> res)
    {
        // For the given value of i, generate lo and hi pointers
        int lo = i + 1;
        int hi = nums.Length - 1;
        
        while (lo < hi)
        {
            int sum = nums[i] + nums [lo] + nums[hi];
            if (sum < 0)
            {
                lo++; // Move lo forward
            } else if (sum > 0)
            {
                hi--; // Move high back
            } else {  // Matches 0
                res.Add(new List<int> { nums[i], nums[lo], nums[hi] }); // Add to result
                // Move both to avoid duplicates
                lo++;
                hi--;
                // Move lo up to avoid duplicates with previous
                while (lo < hi && nums[lo] == nums[lo-1])
                    lo++;
            }
        }
    }
}

var s = new Solution();
Console.WriteLine(s.ThreeSum(new int[] {-1,0,1,2,-1,-4}));