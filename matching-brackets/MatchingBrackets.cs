using System;
using System.Collections.Generic;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var flag = false;
        string cleaned = "";
        var match = new List<char>() {'[', ']', '(', ')', '{', '}'};

        foreach(char c in input)
        {
            if (match.Contains(c))
            {
                cleaned += c;
            }
        }
        return flag;
    }
}
