using System;
using System.Collections.Generic;

var value = "\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)";
Console.WriteLine(MatchingBrackets.IsPaired(value));

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
        Console.WriteLine(cleaned);
        return flag;
    }
}
