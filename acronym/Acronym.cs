using System;
using System.Collections.Generic;

public static class Acronym
{
    public static List<string> SplitString(string s)
    {
        List<string> result = new List<string>();
        // First split on '-'
        foreach(string word in s.Split('-'))
        {
            // Then split on ' '
            foreach(string subword in word.Split(' '))
            {
                result.Add(subword);
            }
        }
        return result;
    }

    public static string GetFirstAlphaNumeric(string s)
    {
        foreach(char c in s)
        {
            if(Char.IsLetterOrDigit(c))
            {
                return c.ToString().ToUpper();
            }
        }
        return "";
    }

    public static string Abbreviate(string s)
    {
        string result = "";
        // Split s on '-' and ' '
        List<string> words = SplitString(s);
        foreach(string word in words)
        {
            string firstAlphaNumeric = GetFirstAlphaNumeric(word); // Get the first alpha numeric character
                result += firstAlphaNumeric;
        }
        return result;
    }
}