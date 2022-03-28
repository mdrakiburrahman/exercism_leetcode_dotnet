using System;

public static class Bob
{

    public static string preProcess (string s) 
    {
        // Remove leading and trailing spaces
        s = s.Trim();
        return s;
    }

    public static bool isAllUpper(string s)
    {
        bool isAllNumerics = true; // Use to check if everything is a number

        foreach(char c in s)
        {
            // Check if a letter or not
            if (Char.IsLetter(c))
            {
                isAllNumerics = false; // Since we have a letter
                // Check if not upper case
                if (!Char.IsUpper(c))
                {
                    return false;
                }
            }
        }
        // If isAllNumerics is still true, return false since it doens't count as uppercase
        if (isAllNumerics)
        {
            return false;
        }
        return true; // Gets to here if everything is uppercase and not all numbers
    }

    public static string Response(string statement)
    {
        // Pre-process statement
        statement = preProcess(statement);
        // Check for empty string
        if (statement.Length == 0)
        {
            return "Fine. Be that way!";
        }
        // Check if question
        if (statement[statement.Length - 1] == '?')
        {
            // Check if all uppercase
            if (isAllUpper(statement))
            {
                return "Calm down, I know what I'm doing!";
            } else {
                return "Sure.";
            }
        } else // Not a question
        {
            if (isAllUpper(statement))
            {
                return "Whoa, chill out!";
            } else {
                return "Whatever.";
            }
        }
    }
}