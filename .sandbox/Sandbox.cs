using System;
using System.Linq;

Solution sol = new Solution();
string result;

result = sol.LongestPalindrome("nxabaxzcbc");
Console.WriteLine($"Longest: {result}");
result = sol.LongestPalindrome("babad");
Console.WriteLine($"Longest: {result}");
result = sol.LongestPalindrome("cbbd");
Console.WriteLine($"Longest: {result}");
result = sol.LongestPalindrome("naabbaa");
Console.WriteLine($"Longest: {result}");

public class Solution {
    public string LongestPalindrome(string s) {
        string longestPalindrome = "";
        string oddCandidate, evenCandidate;

        for (int i = 0; i < s.Length; i++) // Loop left to right
        {
            oddCandidate = GetLongestOddPalindrome(s, i);
            evenCandidate = GetLongestEvenPalindrome(s, i);
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

    public string GetLongestOddPalindrome(string s, int i)
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
    public string GetLongestEvenPalindrome(string s, int i)
    {
        string longest = ""; // Start with even palindrome
        
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
            right = i+distance;
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

    public string GetPalindrome(string s, int i, bool even)
    {
        string longest = "";
        int offset = 0;
        
        if (even)
        {
            
        }
    }
}