using System;
using System.Linq;

char[] s1 = { 't','h','e',' ','s','k','y',' ','i','s',' ','b','l','u','e' };
Solution sol = new Solution();
sol.ReverseWords(s1);
Console.WriteLine(string.Join("", s1));

char[] s2 = { 'a' };
sol.ReverseWords(s2);
Console.WriteLine(string.Join("", s2));

char[] s3 = { 'a',' ','b',' ','c',' ','d',' ','e' };
sol.ReverseWords(s3);
Console.WriteLine(string.Join("", s3));

char[] s4 = { 'h','i'};
sol.ReverseWords(s4);
Console.WriteLine(string.Join("", s4));

public class Solution {
    public void ReverseWords(char[] s) {
        ReversePartOfArray(s, 0, s.Length - 1);
        ReverseEachValidWord(s);
    }

    public void ReversePartOfArray(char[] s, int start, int end)
    {
        while (start < end)
        {
            char temp = s[start];
            s[start] = s[end];
            s[end] = temp;
            start++;
            end--;
        }
    }

    public void ReverseEachValidWord(char[] s)
    {
        int start = 0, end = 0;

        while (start < s.Length)
        {
            while (end < s.Length && s[end] != ' ')
            {
                end++; // Get to end of next valid word
            }

            ReversePartOfArray(s, start, end - 1);
            start = end + 1;
            end = start;
        }
    }
}