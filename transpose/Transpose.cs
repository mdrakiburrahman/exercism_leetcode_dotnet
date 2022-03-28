using System;

public static class Transpose
{
    public static string String(string s)
    {
        if (s == "")
        {
            return "";
        }
        var input = s.Split('\n');
        var rows = s.Split('\n').Length;
        int cols = 0;
        foreach (var c in input)
        {
            if (c.Length > cols)
            {
                cols = c.Length;
            }
        }
        // Output string
        string output = "";
        // Loop through each column and go right on each row
	    // If no character found, if upcoming rows in that column have characters - check downward and pad with space
        string word = "";
        bool hasChar = false;
        for (int c = 0; c < cols; c++) // Loop through columns
        {
            for (int r = 0; r < rows; r++) // Loop through rows
            {
                if (c > input[r].Length - 1) // If we are past the end of the column for this row
                {
                    // Check if any of the next rows have a valid character
                    for (int i = r + 1; i < rows; i++)
                    {
                        if (input[i].Length > c)
                        {
                            hasChar = true;
                            break;
                        }
                    }
                    // if hasChar, pad with space
                    if (hasChar)
                    {
                        word += " ";
                        hasChar = false; // Reset
                    }
                } else // Not past the end of the row - add character as is
                {
                    word += input[r][c];
                }
            }
            output += word + "\n";
            word = ""; // Reset
        }
        return output[output.Length - 1] == '\n' ? output.Substring(0, output.Length - 1) : output; // Remove last newline
    }
}