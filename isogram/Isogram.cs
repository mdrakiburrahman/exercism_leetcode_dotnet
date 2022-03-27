using System;
using System.Collections.Generic;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var map = new Dictionary<char, int>();
        foreach (char c in word)
        {
            if (char.IsLetter(c)) // A-Z, a-z
            {
                if (map.ContainsKey(char.ToLower(c)))
                {
                    return false;
                }
                else
                {
                    map.Add(char.ToLower(c), 1);
                }
            }
        }
        return true;
    }
}
