using System;
using System.Collections.Generic;

public static class WordCount
{
    public static string CleanWord(string input)
    {
        string output = "";

        // Remove empty strings and trim front and back
        char[] charsToTrim = {',', '.', ' ', '!', '?', ':' , '\''};
        input  = input.TrimStart(charsToTrim).TrimEnd(charsToTrim).ToLower();
        
        foreach(char c in input)
        {
             if (Char.IsLetterOrDigit(c) || c == '\'') // Trim foreign characters, except apostrophe
                output += c;
        }
        return output;
    }
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var result = new Dictionary<string, int>();

        // Split phrase by delimiters
        string[] whitesplit = (phrase.Split(' ', '\t', '\n', ','));

        string clean = "";
        
        foreach (string s in whitesplit)
        {
            clean = CleanWord(s);
            if (!string.IsNullOrEmpty(clean))
            {
                
                // Add to dictionary or increment
                if (result.ContainsKey(clean))
                {
                    result[clean]++;
                }
                else
                {
                    result.Add(clean, 1);
                }
            }
        }
        return result;
    }
}