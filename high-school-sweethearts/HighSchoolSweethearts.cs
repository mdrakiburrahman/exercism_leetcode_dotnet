using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA.PadLeft(29)} ♡ {studentB.PadRight(29)}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
                string topHalf = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **";
        string bottomHalf = @"
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    return(topHalf + "\n" + $"**{"L. G.".PadLeft(10)}  +  {"P. R.".PadRight(10)}**" + bottomHalf);
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        // Convert hours to 2 decimal place, then force german culture
        return string.Format("{0} and {1} have been dating since {2} - that's {3} hours", studentA, studentB, start.ToString("dd.MM.yyyy"), hours.ToString("n2", CultureInfo.GetCultureInfo("de")));
    }
}
