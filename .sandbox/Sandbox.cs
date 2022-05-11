using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
var result = sol.GroupAnagrams(strs);
Console.WriteLine($"Result: {result}");

strs = new string[] { "" };
result = sol.GroupAnagrams(strs);
Console.WriteLine($"Result: {result}");

strs = new string[] { "a" };
result = sol.GroupAnagrams(strs);
Console.WriteLine($"Result: {result}");


public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var result = new List<IList<string>>();
        var sorted = new string[strs.Length];
        // Sort each string
        for (int i = 0; i < strs.Length; i++)
        {
            sorted[i] = string.Concat(strs[i].OrderBy(c => c));
        }
        // Create a Dictionary, string -> List<string>
        var dict = new Dictionary<string, List<string>>();    
        // Populate Dictionary
        for (int i = 0; i < sorted.Length; i++)
        {
            // Key is the sorted string, value is the original string added to the list
            if (!dict.ContainsKey(sorted[i]))
            {
                dict.Add(sorted[i], new List<string>());
                dict[sorted[i]].Add(strs[i]);
            } else {
                dict[sorted[i]].Add(strs[i]);
            }
        }
        // Populate result from dictionary
        foreach (var key in dict.Keys)
        {
            result.Add(dict[key]);
        }
        return result;
    }
}