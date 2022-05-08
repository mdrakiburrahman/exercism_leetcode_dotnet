using System;
using System.Linq;

Solution sol = new Solution();
string result;

result = sol.LongestPalindrome("babad");
Console.WriteLine($"Longest: {result}");
result = sol.LongestPalindrome("cbbd");
Console.WriteLine($"Longest: {result}");

public class Solution {
    public string LongestPalindrome(string s) {
        string longestPalindrome = "";
        string candidate = "";
        for (int i = 0; i < s.Length; i++) // Loop left to right
        {
            candidate = GetLongestPalindrome(s, i);
            if (candidate.Length > longestPalindrome.Length)
            {
                longestPalindrome = candidate;
            }
        }

        return longestPalindrome;
    }

    public string GetLongestPalindrome(string s, int i)
    {
        string longest = s[i].ToString(); // The character itself is a palindrome
        
        if (i == 0 || i == s.Length-1) // At the edge of the string
        {
            return longest; // Return character itself
        }

        bool onStreak = true;
        int distance = 1;
        int left, right, length;

        while (onStreak)
        {
            left = i-distance;
            right = i+distance+1;
            length = right-left;
            if (left >= 0 && right <= s.Length)
            {
                Console.WriteLine($"We're at: {s.Substring(left, length)}");
                if (s[left] == s[right-1])
                {
                    Console.WriteLine("Palindrome!");
                    longest = s.Substring(left, length);
                } else
                {
                    Console.WriteLine("Not Palindrome!");
                    onStreak = false;
                }
            } else {
                onStreak = false;
            }
            distance++;
        }

        return longest;
    } 
}