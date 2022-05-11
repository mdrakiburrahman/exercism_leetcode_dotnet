using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
var result = sol.GroupAnagrams(strs);
// Console.WriteLine($"Longest: {result}");

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var result = new List<IList<string>>();
        
        // Sort each string
        for (int i = 0; i < strs.Length; i++)
        {
            strs[i] = string.Concat(strs[i].OrderBy(c => c));
        }
        // Sort the array
        Array.Sort(strs);

        // Group the array
        List<string> group = new List<string>();
        for (int i = 0; i < strs.Length; i++)
        {
            if (i != 0 )
            {
                if (strs[i] != strs[i-1]) // String has changed, add new group
                {
                    result.Add(group);
                    group = new List<string>();
                    group.Add(strs[i]);
                } else {
                    group.Add(strs[i]);
                }
            } else { // First in list - add it in a new group
                group = new List<string>();
                group.Add(strs[i]);
            }
        }
        // If group is not empty, add it to the result
        if (group.Count > 0)
        {
            result.Add(group);
        }
        return result;
    }
}