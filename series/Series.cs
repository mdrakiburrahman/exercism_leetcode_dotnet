using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string s, int n)
    {
        var result = new List<string>();

        // Error handling
        if (n > s.Length || n <= 0)
        {
            throw new ArgumentException("Slice length is too large");
        }

        int start = 0;
        int end = n;
        
        while (end <= s.Length)
        {
            result.Add(s.Substring(start, n));
            start++;
            end++;
        }
        return result.ToArray();
    }
}