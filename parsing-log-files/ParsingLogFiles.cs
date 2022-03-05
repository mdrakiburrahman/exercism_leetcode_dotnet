using System;
using System.Text.RegularExpressions;
using System.Linq;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        string pattern = "(^\\[TRC\\]? |^\\[DBG\\]? |^\\[INF\\]? |^\\[WRN\\]? |^\\[ERR\\]? |^\\[FTL\\]? )";
        if (Regex.IsMatch(text, pattern))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public string[] SplitLogLine(string text)
    {
        string pattern = "\\<(\\^.*?|\\*.*?|=.*?|-.*?)\\>";
        string[] substrings = Regex.Split(text, pattern, RegexOptions.ExplicitCapture);    // Split on patterns explicitly

        string[] result = new string[] {}; // For filtering out the actual patterns

        foreach(string s in substrings)
        {
            if (!Regex.IsMatch(s, pattern)) // If no match on pattern, add into results
            {
                result = result.Concat(new string[] {s}).ToArray();
            }
        }

        return result;
    }

    public int CountQuotedPasswords(string lines)
    {
        int count = 0;
        foreach (string line in lines.Split(Environment.NewLine))
        {
            if (Regex.IsMatch(line, "\"(.*?)\"")) // Match between quotes
            {
                if (Regex.IsMatch(line, "[Pp][Aa][Ss][Ss][Ww][Oo][Rr][Dd]")) // Match password in any permutation
                {
                    count++;
                }   
            }
        }
        return count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, "end-of-line[0-9]*", String.Empty);
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] result = new string[] {};
        string prefix;
        foreach (string line in lines)
        {
            var myMatch = Regex.Match(line, "password[\\w]+", RegexOptions.IgnoreCase); // Get match of password in any permutation followed by any word character
            prefix = myMatch.Success ? myMatch.Value : "--------"; // If match is Successful, append to prefix, else use default
            result = result.Concat(new string[] {prefix + ": " + line}).ToArray();
        }
        return result;
    }
}
