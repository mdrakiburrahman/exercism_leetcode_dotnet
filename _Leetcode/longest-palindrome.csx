using System;
using System.Linq;

Solution sol = new Solution();
string result;

// result = sol.LongestPalindrome("nxabaxzcbc");
// Console.WriteLine($"Longest: {result}");
// result = sol.LongestPalindrome("babad");
// Console.WriteLine($"Longest: {result}");
// result = sol.LongestPalindrome("cbbd");
// Console.WriteLine($"Longest: {result}");
// result = sol.LongestPalindrome("naabbaa");
// Console.WriteLine($"Longest: {result}");
// result = sol.LongestPalindrome("bb");
// Console.WriteLine($"Longest: {result}");

public class Solution {
    public string LongestPalindrome(string s) {
        string longestPalindrome = "";
        string oddCandidate, evenCandidate;

        for (int i = 0; i < s.Length; i++) // Loop left to right
        {
            oddCandidate = GetPalindrome(s, i, true);
            evenCandidate = GetPalindrome(s, i, false);
            if (oddCandidate.Length > longestPalindrome.Length)
            {
                longestPalindrome = oddCandidate;
            }
            if (evenCandidate.Length > longestPalindrome.Length)
            {
                longestPalindrome = evenCandidate;
            }
        }
        return longestPalindrome;
    }

    public string GetPalindrome(string s, int i, bool odd)
    {
        string longest = "";
        int offset = 0;
        
        if (odd)
        {
            longest = s[i].ToString(); // The character itself is a palindrome in odd case
            offset = 1;

            if (i == 0 || i == s.Length-1) // At the edgs of the string
            {
                return longest; // Return character itself
            }
        } else {
            if (i == 0) // At the left edge of the string
            {
                return longest; // Return character itself
            }
        }

        bool onStreak = true;
        int distance = 1;
        int left, right, length;

        while (onStreak)
        {
            left = i-distance;
            right = i+distance+offset;
            length = right-left;
            if (left >= 0 && right <= s.Length)
            {
                // Console.WriteLine($"We're at: {s.Substring(left, length)}");
                if (s[left] == s[right-1])
                {
                    // Console.WriteLine("Palindrome!");
                    longest = s.Substring(left, length);
                } else
                {
                    // Console.WriteLine("Not Palindrome!");
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