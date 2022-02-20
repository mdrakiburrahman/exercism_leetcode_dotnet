using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter)
    {
        return str.Split(delimiter)[1];
    }

    public static string SubstringBetween(this string str, string first, string second)
    {
        return str.Split(first)[1].Split(second)[0];
    }
    
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }

    // MAIN FOR TEST
    // public static void Main(string[] args)
    // { 
    //     var log = "[INFO]: File Deleted.";
    //     Console.WriteLine($"SubstringAfter: {log.SubstringAfter(": ")}"); // => returns "File Deleted."
    //     Console.WriteLine($"SubstringBetween: {log.SubstringBetween("[", "]")}"); // => returns "INFO"

    //     log = "[ERROR]: Missing ; on line 20.";
    //     Console.WriteLine($"Message: {log.Message()}"); // => returns "Missing ; on line 20."
    //     Console.WriteLine($"LogLevel: {log.LogLevel()}"); // => returns "ERROR"
    // }
}