using System;

static class LogLine
{
    // Parse the string into two parts
    public static string[] Parse(string logLine)
    {
        var parts = logLine.Split(':');
        // Trim whitespace from second part
        parts[1] = parts[1].Trim();
        // replace '[' and ']' with empty string, and lowercase 
        parts[0] = parts[0].Replace("[", "").Replace("]", "").ToLower();

        return parts;
    }

    // INPUT: [ERROR]: Invalid operation
    // OUTPUT: Invalid operation
    public static string Message(string logLine)
    {
        return Parse(logLine)[1];
    }
    // INPUT: [ERROR]: Invalid operation
    // OUTPUT: error
    public static string LogLevel(string logLine)
    {
        return Parse(logLine)[0];
    }
    // INPUT: [ERROR]: Invalid operation
    // OUTPUT: Invalid operation (error)
    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }

    // MAIN FOR TEST
    // public static void Main(string[] args)
    // {   
    //     // Console.WriteLine(Parse("[ERROR]: Invalid operation")[0]);
    //     // Console.WriteLine(Parse("[ERROR]: Invalid operation")[1]);
    //     Console.WriteLine(Message("[ERROR]: Invalid operation"));
    //     Console.WriteLine(LogLevel("[ERROR]: Invalid operation"));
    //     Console.WriteLine(Reformat("[ERROR]: Invalid operation"));
    // }
}
