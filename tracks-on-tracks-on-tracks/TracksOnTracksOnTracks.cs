using System;
using System.Collections.Generic;
using System.Linq;

// Console.WriteLine($"1: {String.Join(", ", Languages.NewList())}");
// List<string> myLanguages = Languages.GetExistingLanguages();
// Console.WriteLine($"2: {String.Join(", ", myLanguages)}");
// Console.WriteLine($"3: {String.Join(", ", Languages.AddLanguage(myLanguages, "VBA"))}");
// Console.WriteLine($"4: Count {Languages.CountLanguages(myLanguages)}");
// Console.WriteLine($"5: Elm? {Languages.HasLanguage(myLanguages, "Elm")}");
// Console.WriteLine($"5: Golang? {Languages.HasLanguage(myLanguages, "Golang")}");
// Console.WriteLine($"6: Forward: {String.Join(", ", myLanguages)}");
// Console.WriteLine($"7: Exciting? {Languages.IsExciting(myLanguages)}");
// Console.WriteLine($"6: Reverse: {String.Join(", ", Languages.ReverseList(myLanguages))}");
// Console.WriteLine($"7: Exciting? {Languages.IsExciting(myLanguages)}");
// Console.WriteLine($"8: Remove: {String.Join(", ", Languages.RemoveLanguage(myLanguages, "Clojure"))}");
// Console.WriteLine($"8: Remove: {String.Join(", ", Languages.RemoveLanguage(myLanguages, "Elm"))}");
// Console.WriteLine($"9: Unique? {Languages.IsUnique(myLanguages)}");
// Console.WriteLine($"9: Unique? {Languages.IsUnique(new List<string> { "C#", "Elm", "C#"})}");

public static class Languages
{   
    private static List<string> languages = new List<string>();

    public static List<string> NewList()
    {
        languages = new List<string> {};
        return languages;
    }

    public static List<string> GetExistingLanguages()
    {
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        return languages;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        bool isExciting = false;

        if (languages.Count != 0) // Not empty
        {
            // First element is C#
            if (languages[0] == "C#")
            {
                isExciting = true;
            }
            // The second item on the list is C# and the list contains either two or three languages. 
            else if (languages[1] == "C#" && (languages.Count == 2 || languages.Count == 3))
            {
                isExciting = true;
            }
        }
        return isExciting;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        return languages.Distinct().Count() == languages.Count; // Using Linq
    }
}
