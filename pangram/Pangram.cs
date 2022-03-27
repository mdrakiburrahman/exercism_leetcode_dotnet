using System;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        // turn input into lowercase
        input = input.ToLower();

        // array to store flags
        var flags = new bool[123-97];

        // loop over string and store flags
        foreach(char c in input)
        {
            if(char.IsLetter(c))
            {
                flags[c - 97] = true;
            }
        }

        // loop over flags, if any are false, return false
        foreach(bool b in flags)
        {
            if(!b)
            {
                return false;
            }
        }
        return true; 
    }
}
